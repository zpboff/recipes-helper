package controllers

import (
	"auth/config"
	"github.com/gin-gonic/gin"
)

func Logout(c *gin.Context) {
	c.SetCookie("token", "", -1, "/", config.GetServerConfig().Host, false, true)
	c.Status(200)
}
