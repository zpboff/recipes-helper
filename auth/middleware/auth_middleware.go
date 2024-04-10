package middleware

import (
	"github.com/gin-gonic/gin"
	"github.com/golang-jwt/jwt/v5"
)

func AuthMiddleware() gin.HandlerFunc {
	return func(c *gin.Context) {
		accessToken := c.GetHeader("Authorization")

		if accessToken == "" {
			handleNonAuthorized(c)
			return
		}

		token, err := jwt.ParseWithClaims(accessToken, &jwt.RegisteredClaims{}, func(token *jwt.Token) (interface{}, error) {
			return token, nil
		})

		if err != nil || !token.Valid {
			handleNonAuthorized(c)
			return
		}

		_, ok := token.Claims.(*jwt.RegisteredClaims)

		if !ok {
			handleNonAuthorized(c)
			return
		}

		c.Next()
	}
}

func handleNonAuthorized(c *gin.Context) {
	c.AbortWithStatusJSON(401, gin.H{"error": "Unauthorized"})
	return
}
