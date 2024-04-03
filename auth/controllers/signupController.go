package controllers

import (
	"auth/models"
	"auth/utils"
	"github.com/gin-gonic/gin"
)

type RegisterRequest struct {
	Email    string
	Password string
}

func Register(c *gin.Context) {
	var request RegisterRequest

	if err := c.ShouldBindJSON(&request); err != nil {
		c.JSON(400, gin.H{"error": err.Error()})
		return
	}

	var existingUser models.User

	models.DB.Where("email = ?", request.Email).First(&existingUser)

	if existingUser.ID != 0 {
		c.JSON(400, gin.H{"error": "User already exists"})
		return
	}

	passwordHash, errHash := utils.GenerateHashPassword(request.Password)

	if errHash != nil {
		c.JSON(500, gin.H{"error": "Could not generate password hash"})
		return
	}

	user := models.User{
		PasswordHash: passwordHash,
		Deleted:      false,
		Email:        request.Email,
	}

	models.DB.Create(&user)

	c.JSON(200, gin.H{"success": "User created"})
}
