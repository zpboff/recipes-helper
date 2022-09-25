package main

import (
	"auth-server/config"
	"auth-server/login"
	"auth-server/registration"
	"github.com/gin-gonic/gin"
)

func main() {
	var cfg config.Config
	config.RegisterConfig(&cfg)
	router := gin.Default()

	login.AddLoginRoute(router, &cfg.SqlDB)
	registration.AddRegistrationRoute(router)

	router.Run(":5052")
}
