package controllers

import (
	"auth/models"
	"auth/utils"
	"github.com/gin-gonic/gin"
)

type LoginRequest struct {
	Email    string
	Password string
}

func Login(c *gin.Context) {
	var request LoginRequest

	if err := c.ShouldBindJSON(&request); err != nil {
		c.JSON(400, gin.H{"error": err.Error()})
		return
	}

	var existingUser models.User

	models.DB.Where("email = ?", request.Email).First(&existingUser)

	if existingUser.ID == 0 {
		c.JSON(400, gin.H{"error": "User does not exist"})
		return
	}

	errHash := utils.CompareHashPassword(request.Password, existingUser.PasswordHash)

	if !errHash {
		c.JSON(400, gin.H{"error": "Invalid password"})
		return
	}

	utils.GenerateTokens(c, existingUser.ID)
}
