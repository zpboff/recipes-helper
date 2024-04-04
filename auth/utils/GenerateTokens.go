package utils

import (
	"auth/config"
	"auth/models"
	"github.com/dgrijalva/jwt-go"
	"github.com/gin-gonic/gin"
	"strconv"
	"time"
)

func AttachToken(c *gin.Context, userId uint64) {
	securityConfig := config.GetSecurityConfig()
	subject := strconv.Itoa(int(userId))

	accessTokenExpirationTime := time.Now().Add(securityConfig.AccessTokenExpiration).Unix()

	accessTokenClaims := &jwt.StandardClaims{
		Subject:   subject,
		ExpiresAt: accessTokenExpirationTime,
	}

	accessToken := jwt.NewWithClaims(jwt.SigningMethodHS256, accessTokenClaims)
	accessTokenString, accessTokenError := accessToken.SignedString(securityConfig.AccessTokenSecret)

	if accessTokenError != nil {
		c.JSON(500, gin.H{"error": "Could not generate token"})
		return
	}

	refreshTokenExpiration := time.Now().Add(securityConfig.RefreshTokenInspiration).Unix()

	refreshTokenClaims := &jwt.StandardClaims{
		Subject:   subject,
		ExpiresAt: refreshTokenExpiration,
	}

	refreshToken := jwt.NewWithClaims(jwt.SigningMethodHS256, refreshTokenClaims)
	refreshTokenString, refreshTokenErr := refreshToken.SignedString(securityConfig.RefreshTokenSecret)

	if refreshTokenErr != nil {
		c.JSON(500, gin.H{"error": "Could not generate token"})
		return
	}

	models.DB.Create(&models.RefreshToken{
		Expiration: refreshTokenExpiration,
		UserId:     userId,
	})

	c.SetCookie("token", refreshTokenString, int(refreshTokenExpiration), "/", "localhost", false, true)

	c.JSON(200, gin.H{"token": accessTokenString})
}
