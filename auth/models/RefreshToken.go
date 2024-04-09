package models

import (
	"gorm.io/gorm"
)

type RefreshToken struct {
	gorm.Model
	Token      string
	UserId     uint
	Expiration int64
}
