package config

import (
	"os"
)

type ServerConfig struct {
	Host string
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
		Host: os.Getenv("SERVER_HOST"),
		Port: os.Getenv("SERVER_PORT"),
	}

	return serverConfig
}
