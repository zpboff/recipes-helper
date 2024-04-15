package securityUtils

import (
	"auth/config"
	"golang.org/x/crypto/bcrypt"
)

func GenerateHashPassword(password string) (string, error) {
	cost := config.GetSecurityConfig().PasswordCost
	bytes, err := bcrypt.GenerateFromPassword([]byte(password), cost)
	return string(bytes), err
}
