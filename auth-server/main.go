package main

import (
	"auth-server/login"
	"auth-server/registration"
	"github.com/gin-gonic/gin"
)

func main() {
	router := gin.Default()

	login.AddLoginRoute(router)
	registration.AddRegistrationRoute(router)

	router.Run(":5052")
}
