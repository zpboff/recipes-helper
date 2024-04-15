package securityUtils

import (
	"auth/config"
	"auth/models"
	"github.com/gin-gonic/gin"
	"github.com/golang-jwt/jwt/v5"
	"net/http"
	"strconv"
	"time"
)

type TokenInfo struct {
	token      string
	expiration int64
}

func GenerateTokens(c *gin.Context, userId uint) {
	securityConfig := config.GetSecurityConfig()
	serverConfig := config.GetServerConfig()
	subject := strconv.Itoa(int(userId))

	refreshTokenInfo := generateToken(securityConfig.RefreshTokenInspiration, securityConfig.RefreshTokenSecret, subject)

	if refreshTokenInfo == nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Could not generate refresh token"})
		return
	}

	models.DB.Create(&models.RefreshToken{
		Token:      refreshTokenInfo.token,
		Expiration: refreshTokenInfo.expiration,
		UserId:     userId,
	})

	accessTokenInfo := generateToken(securityConfig.AccessTokenExpiration, securityConfig.AccessTokenSecret, subject)

	if accessTokenInfo == nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Could not generate access token"})
		return
	}

	c.SetCookie("token", refreshTokenInfo.token, int(refreshTokenInfo.expiration), "/api/auth", serverConfig.Host, false, true)

	c.IndentedJSON(http.StatusOK, accessTokenInfo)
}

func generateToken(duration time.Duration, secret string, subject string) *TokenInfo {
	tokenExpiration := time.Now().Add(duration)

	tokenClaims := &jwt.RegisteredClaims{
		Subject: subject,
		ExpiresAt: &jwt.NumericDate{
			Time: tokenExpiration,
		},
	}

	token := jwt.NewWithClaims(jwt.SigningMethodHS256, tokenClaims)
	tokenString, refreshTokenErr := token.SignedString(secret)

	if refreshTokenErr != nil {
		return nil
	}

	return &TokenInfo{
		token:      tokenString,
		expiration: tokenExpiration.Unix(),
	}
}
