package auth

import (
	"auth/models"
	"auth/routes"
	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()

	models.InitDB()
	routes.AuthRoutes(r)

	err := r.Run(":8080")
	
	if err != nil {
		return
	}
}
