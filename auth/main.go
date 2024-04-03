package auth

import (
	"auth/config"
	"auth/models"
	"auth/routes"
	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()

	models.InitDB()
	routes.AuthRoutes(r)

	err := r.Run(":" + config.GetServerConfig().Host)

	if err != nil {
		return
	}
}
