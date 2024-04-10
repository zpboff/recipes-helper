package config

import (
	"github.com/joho/godotenv"
	"log"
)

func TryLoadConfigFile(fileName string) error {
	err := godotenv.Load(".server.env")

	if err != nil {
		log.Fatalf("Error loading %s file", fileName)
		return err
	}

	return nil
}
