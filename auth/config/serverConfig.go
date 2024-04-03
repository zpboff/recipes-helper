package config

import (
	"os"
)

type ServerConfig struct {
	Port string
}

var serverConfig *ServerConfig

func GetServerConfig() *ServerConfig {
	if serverConfig != nil {
		return serverConfig
	}

	err := TryLoadConfigFile(".server.env")

	if err != nil {
		return nil
	}

	serverConfig = &ServerConfig{
		Port: os.Getenv("DB_PORT"),
	}

	return serverConfig
}
