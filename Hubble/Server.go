package main

import (
	"hubble/controllers"
	"net/http"
)

func main() {
	http.HandleFunc("/api/search", controllers.Search)
	http.ListenAndServe(":8080", nil)
}
