package models

import (
	"gorm.io/gorm"
)

type RefreshToken struct {
	gorm.Model
	UserId     uint64
	Expiration int64
}
