package config

import (
	"log"
	"os"
	"strconv"
	"time"
)

type SecurityConfig struct {
	AccessTokenExpiration   time.Duration
	RefreshTokenInspiration time.Duration
	AccessTokenSecret       string
	RefreshTokenSecret      string
	PasswordCost            int
}

var securityConfig *SecurityConfig

func GetSecurityConfig() *SecurityConfig {
	if securityConfig != nil {
		return securityConfig
	}

	err := TryLoadConfigFile(".server.env")

	if err != nil {
		return nil
	}

	accessTokenExpiration, accessTokenExpirationParsingError := strconv.Atoi(os.Getenv("SECURITY_ACCESS_TOKEN_EXPIRATION"))

	if accessTokenExpirationParsingError != nil {
		log.Fatal("Incorrect access token expiration value")
	}

	refreshTokenExpiration, refreshTokenExpirationParsingError := strconv.Atoi(os.Getenv("SECURITY_REFRESH_TOKEN_EXPIRATION"))

	if refreshTokenExpirationParsingError != nil {
		log.Fatal("Incorrect refresh token expiration value")
	}

	accessTokenSecret := os.Getenv("SECURITY_ACCESS_SECRET")

	if accessTokenSecret == "" {
		log.Fatal("Incorrect access token secret value")
	}

	refreshTokenSecret := os.Getenv("SECURITY_ACCESS_SECRET")

	if refreshTokenSecret == "" {
		log.Fatal("Incorrect refresh token secret value")
	}

	passwordCost, passwordCostParsingError := strconv.Atoi(os.Getenv("SECURITY_PASSWORD_COST"))

	if passwordCostParsingError != nil {
		log.Fatal("Incorrect password cost value")
	}

	securityConfig = &SecurityConfig{
		AccessTokenExpiration:   time.Duration(accessTokenExpiration) * time.Minute,
		RefreshTokenInspiration: time.Duration(refreshTokenExpiration) * time.Hour * 24,
		AccessTokenSecret:       accessTokenSecret,
		RefreshTokenSecret:      refreshTokenSecret,
		PasswordCost:            passwordCost,
	}

	return securityConfig
}
