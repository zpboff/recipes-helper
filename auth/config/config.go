package config

import (
	"github.com/joho/godotenv"
	"log"
	"os"
	"strconv"
)

type DbConfig struct {
	Host     string
	Port     string
	User     string
	Password string
	DBName   string
	SSLMode  string
}

type ServerConfig struct {
	Port string
}

type SecurityConfig struct {
	Salt   int
	Secret string
}

var dbConfig *DbConfig
var serverConfig *ServerConfig
var securityConfig *SecurityConfig

func GetServerConfig() *ServerConfig {
	if serverConfig != nil {
		return serverConfig
	}

	err := godotenv.Load()

	if err != nil {
		log.Fatal("Error loading .env file")
	}

	serverConfig = &ServerConfig{
		Port: os.Getenv("DB_PORT"),
	}

	return serverConfig
}

func GetDbConfig() *DbConfig {
	if dbConfig != nil {
		return dbConfig
	}

	err := godotenv.Load()

	if err != nil {
		log.Fatal("Error loading .env file")
	}

	dbConfig = &DbConfig{
		Host:     os.Getenv("DB_HOST"),
		Port:     os.Getenv("DB_PORT"),
		User:     os.Getenv("DB_USER"),
		Password: os.Getenv("DB_PASSWORD"),
		DBName:   os.Getenv("DB_NAME"),
		SSLMode:  os.Getenv("DB_SSLMODE"),
	}

	return dbConfig
}

func GetSecurityConfig() *SecurityConfig {
	if securityConfig != nil {
		return securityConfig
	}

	err := godotenv.Load()

	if err != nil {
		log.Fatal("Error loading .env file")
	}

	salt, saltParsingError := strconv.Atoi(os.Getenv("SECURITY_SALT"))

	if saltParsingError != nil {
		log.Fatal("Incorrect Salt value")
	}

	securityConfig = &SecurityConfig{
		Salt:   salt,
		Secret: os.Getenv("SECURITY_SECRET"),
	}

	return securityConfig
}
