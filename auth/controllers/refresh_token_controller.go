package controllers

import (
	"auth/config"
	"auth/models"
	"auth/utils"
	"github.com/gin-gonic/gin"
	"github.com/golang-jwt/jwt/v5"
)

func RefreshToken(c *gin.Context) {
	serverConfig := config.GetServerConfig()
	token, err := c.Cookie("token")

	if err != nil || token == "" {
		c.Status(401)
		return
	}

	parsedToken, err := jwt.ParseWithClaims(token, &jwt.RegisteredClaims{}, func(token *jwt.Token) (interface{}, error) {
		return token, nil
	})

	if err != nil || parsedToken == nil {
		c.Status(401)
		return
	}

	var refreshToken *models.RefreshToken
	models.DB.First(&refreshToken, "token = ?", token)

	if refreshToken == nil {
		c.Status(401)
		return
	}

	utils.GenerateAccessToken(c, refreshToken.UserId)
	c.SetCookie("token", refreshToken.Token, int(refreshToken.Expiration), "/api/auth", serverConfig.Host, false, true)

	c.Status(200)
}
