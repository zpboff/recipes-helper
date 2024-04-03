package utils

import (
	"auth/config"
	"auth/models"
	"github.com/dgrijalva/jwt-go"
	"github.com/gin-gonic/gin"
	"log"
	"time"
)

func AttachToken(c *gin.Context, email string) {
	securityConfig := config.GetSecurityConfig()

	expirationTime := time.Now().Add(securityConfig.AccessTokenExpiration).Unix()

	claims := &models.Claims{
		StandardClaims: jwt.StandardClaims{
			Subject:   email,
			ExpiresAt: expirationTime,
		},
	}

	token := jwt.NewWithClaims(jwt.SigningMethodHS256, claims)
	signedToken, err := token.SignedString(securityConfig.Secret)

	if err != nil {
		log.Fatal(err)
		return
	}

	if err != nil {
		c.JSON(500, gin.H{"error": "Could not generate token"})
		return
	}

	c.SetCookie("token", signedToken, int(expirationTime), "/", "localhost", false, true)
	c.JSON(200, gin.H{"token": token})
}
