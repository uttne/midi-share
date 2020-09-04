package main

import (
	"net/http"

	"github.com/gin-gonic/gin"

	// calc の関数を使用しないとvscode に削除される
	"gin_test/calc"

	"log"
	"strconv"
)

func main() {
	log.Print("test2")
	engine := gin.Default()

	ans := calc.Add(1, 2) + 1

	engine.LoadHTMLGlob("templates/*")
	engine.GET("/", func(c *gin.Context) {
		c.HTML(http.StatusOK, "index.html", gin.H{
			"message": "hello gin:test" + strconv.Itoa(ans),
		})
	})
	engine.GET("/test", func(c *gin.Context) {
		c.HTML(http.StatusOK, "index.html", gin.H{
			"message": "hello gin:test" + strconv.Itoa(ans),
		})
	})
	engine.Run(":3000")
}
