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
	Salt                    int
	AccessTokenSecret       string
	RefreshTokenSecret      string
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

	salt, saltParsingError := strconv.Atoi(os.Getenv("SECURITY_SALT"))

	if saltParsingError != nil {
		log.Fatal("Incorrect Salt value")
	}

	accessTokenExpiration, accessTokenExpirationParsingError := strconv.Atoi(os.Getenv("SECURITY_ACCESS_TOKEN_EXPIRATION"))

	if accessTokenExpirationParsingError != nil {
		log.Fatal("Incorrect Salt value")
	}

	refreshTokenExpiration, refreshTokenExpirationParsingError := strconv.Atoi(os.Getenv("SECURITY_REFRESH_TOKEN_EXPIRATION"))

	if refreshTokenExpirationParsingError != nil {
		log.Fatal("Incorrect Salt value")
	}

	securityConfig = &SecurityConfig{
		AccessTokenExpiration:   time.Duration(accessTokenExpiration) * time.Minute,
		RefreshTokenInspiration: time.Duration(refreshTokenExpiration) * time.Hour,
		Salt:                    salt,
		AccessTokenSecret:       os.Getenv("SECURITY_ACCESS_SECRET"),
		RefreshTokenSecret:      os.Getenv("SECURITY_REFRESH_SECRET"),
	}

	return securityConfig
}
