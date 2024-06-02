package main

import (
	"github.com/gin-gonic/gin"
)

func main() {
	r := gin.Default()

	r.GET("/current", getCurrentColor)
	r.POST("/switch", switchColor)

	err := r.Run(":8989")

	if err != nil {
		return
	}
}
