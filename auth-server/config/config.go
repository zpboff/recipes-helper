package config

import (
	"fmt"
	"github.com/kelseyhightower/envconfig"
	"gopkg.in/yaml.v2"
	"os"
)

type Config struct {
	SqlDB struct {
		Host     string `yaml:"host", envconfig:"SQL_DB_HOST"`
		Port     string `yaml:"port", envconfig:"SQL_DB_PORT"`
		Username string `yaml:"user", envconfig:"SQL_DB_USER"`
		Password string `yaml:"pass", envconfig:"SQL_DB_PASSWORD"`
	} `yaml:"sqlDb"`
}

func processError(err error) {
	fmt.Println(err)
	os.Exit(2)
}

func readYml(cfg *Config) {
	f, err := os.Open("config.yml")
	if err != nil {
		processError(err)
	}
	defer f.Close()

	decoder := yaml.NewDecoder(f)
	err = decoder.Decode(cfg)
	if err != nil {
		processError(err)
	}
}

func readEnv(cfg *Config) {
	err := envconfig.Process("", cfg)
	if err != nil {
		processError(err)
	}
}

func RegisterConfig(cfg *Config) {
	readYml(cfg)
	readEnv(cfg)
}
