package config

import (
	"os"
)

type DbConfig struct {
	Host     string
	Port     string
	User     string
	Password string
	DBName   string
	SSLMode  string
}

var dbConfig *DbConfig

func GetDbConfig() *DbConfig {
	if dbConfig != nil {
		return dbConfig
	}

	err := TryLoadConfigFile(".db.env")

	if err != nil {
		return nil
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
