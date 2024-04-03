package utils

import (
	"auth/config"
	"github.com/dgrijalva/jwt-go"
	"log"
	"time"
)

func GenerateToken(email string) (*string, error) {
	securityConfig := config.GetSecurityConfig()

	payload := jwt.MapClaims{
		"sub": email,
		"exp": time.Now().Add(securityConfig.AccessTokenExpiration).Unix(),
	}

	token := jwt.NewWithClaims(jwt.SigningMethodHS256, payload)
	signedToken, err := token.SignedString(securityConfig.Secret)

	if err != nil {
		log.Fatal(err)
		return nil, err
	}

	return &signedToken, nil
}
