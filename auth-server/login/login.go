package login

import (
	"github.com/gin-gonic/gin"
	"net/http"
)

type LoginRequest struct {
	email    string
	password string
}

func AddLoginRoute(router *gin.Engine) {
	router.GET("/login", func(context *gin.Context) {
		context.Status(http.StatusOK)
	})
}
