package utils

import (
	"github.com/golang-jwt/jwt/v5"
)

func ParseToken(tokenString string, secretKey []byte) (claims *jwt.RegisteredClaims, err error) {
	token, err := jwt.ParseWithClaims(tokenString, &jwt.RegisteredClaims{}, func(token *jwt.Token) (interface{}, error) {
		return secretKey, nil
	})

	if err != nil {
		return nil, err
	}

	claims, ok := token.Claims.(*jwt.RegisteredClaims)

	if !ok {
		return nil, err
	}

	return claims, nil
}
