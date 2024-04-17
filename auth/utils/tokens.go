package utils

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
	accessToken := GenerateAccessToken(userId)
	refreshToken := GenerateRefreshToken(userId)

	AttachAccessTokenToResponse(c, accessToken)
	AttachRefreshTokenToResponse(c, refreshToken)
}

func GenerateAccessToken(userId uint) *TokenInfo {
	securityConfig := config.GetSecurityConfig()
	subject := strconv.Itoa(int(userId))

	accessTokenInfo := generateToken(securityConfig.AccessTokenExpiration, securityConfig.AccessTokenSecret, subject)

	if accessTokenInfo == nil {
		return nil
	}

	return accessTokenInfo
}

func AttachAccessTokenToResponse(c *gin.Context, accessTokenInfo *TokenInfo) {
	if accessTokenInfo == nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": "Could not generate access token"})
		return
	}

	c.IndentedJSON(http.StatusOK, accessTokenInfo)
}

func GenerateRefreshToken(userId uint) *TokenInfo {
	securityConfig := config.GetSecurityConfig()
	subject := strconv.Itoa(int(userId))

	refreshTokenInfo := generateToken(securityConfig.RefreshTokenInspiration, securityConfig.RefreshTokenSecret, subject)

	if refreshTokenInfo == nil {
		return nil
	}

	models.DB.Create(&models.RefreshToken{
		Token:      refreshTokenInfo.token,
		Expiration: refreshTokenInfo.expiration,
		UserId:     userId,
	})

	return refreshTokenInfo
}

func AttachRefreshTokenToResponse(c *gin.Context, refreshTokenInfo *TokenInfo) {
	serverConfig := config.GetServerConfig()
	c.SetCookie("token", refreshTokenInfo.token, int(refreshTokenInfo.expiration), "/api/auth", serverConfig.Host, false, true)
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
