package routes

import (
	"auth/controllers"
	"auth/middleware"
	"github.com/gin-gonic/gin"
)

func AuthRoutes(r *gin.Engine) {
	r.POST("/register", controllers.Register)
	r.POST("/login", controllers.Login)
	r.GET("/logout", middleware.AuthMiddleware(), controllers.Logout)
}
