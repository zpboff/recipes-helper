package models

import "gorm.io/gorm"

type User struct {
	gorm.Model
	Email        string `gorm:"unique" json:"email"`
	PasswordHash string `json:"passwordHash"`
	Deleted      bool   `json:"Deleted"`
}
