package main

import (
	"github.com/gin-gonic/gin"
	"github.com/redis/go-redis/v9"
	"golang.org/x/net/context"
	"net/http"
)

type InstanceColor string

const (
	Blue  InstanceColor = "blue"
	Green               = "green"
)

const colorKey = "INSTANCE_COLOR"

var ctx = context.Background()

var rdb = redis.NewClient(&redis.Options{
	Addr:     "localhost:6379",
	Password: "",
	DB:       0,
})

func getCurrentColor(context *gin.Context) {
	color, err := getColor()

	if err != nil {
		context.Status(http.StatusInternalServerError)
		return
	}

	context.JSON(http.StatusOK, gin.H{
		"color": color,
	})
}

func switchColor(context *gin.Context) {
	currentColor, err := getColor()

	if err != nil {
		context.Status(http.StatusInternalServerError)
		return
	}

	var color InstanceColor
	if *currentColor == Blue {
		color = Green
	} else {
		color = Blue
	}

	_, setColorError := setColor(color)

	if setColorError != nil {
		context.Status(http.StatusInternalServerError)
		return
	}

	context.JSON(http.StatusOK, gin.H{
		"color": color,
	})
}

func getColor() (*InstanceColor, error) {
	color, err := rdb.Get(ctx, colorKey).Result()

	if err != redis.Nil {
		convertedColor := InstanceColor(color)
		return &convertedColor, err
	}

	return setColor(Blue)
}

func setColor(color InstanceColor) (*InstanceColor, error) {
	resultColor, err := rdb.Set(ctx, colorKey, color, 0).Result()

	if err != nil {
		return nil, err
	}

	convertedColor := InstanceColor(resultColor)

	return &convertedColor, err
}
