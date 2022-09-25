package registration

import (
	"github.com/gin-gonic/gin"
	"net/http"
)

func AddRegistrationRoute(router *gin.Engine) {
	router.GET("/registration", func(context *gin.Context) {
		context.Status(http.StatusOK)
	})
}
