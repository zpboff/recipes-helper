package login

import (
	"auth-server/config"
	"context"
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
	"net/http"
)

type LoginRequest struct {
	email    string
	password string
}

func AddLoginRoute(router *gin.Engine, config *config.SqlDbConfig) {
	router.GET("/login", func(response *gin.Context) {
		sqlUrl := fmt.Sprintf("postgres://%s:%s@%s:%s", config.Username, config.Password, config.Host, config.Port)
		pool, err := pgxpool.New(context.Background(), sqlUrl)

		if err != nil {
			response.Error(err)
			return
		}

		rows, err := pool.Query(context.Background(), "select generate_series(1,$1)", 5)

		if err != nil {
			response.Error(err)
			return
		}
		
		numbers, err := pgx.CollectRows(rows, pgx.RowTo[int32])

		if err != nil {
			response.Error(err)
			return
		}

		response.JSON(http.StatusOK, numbers)
	})
}
