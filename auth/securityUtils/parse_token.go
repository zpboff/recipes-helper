package securityUtils

import (
	"auth/models"
)

func ParseToken(tokenString string, secretKey []byte) (claims *models.Claims, err error) {
	token, err := jwt.ParseWithClaims(tokenString, &models.Claims{}, func(token *jwt.Token) (interface{}, error) {
		return secretKey, nil
	})

	if err != nil {
		return nil, err
	}

	claims, ok := token.Claims.(*models.Claims)

	if !ok {
		return nil, err
	}

	return claims, nil
}
