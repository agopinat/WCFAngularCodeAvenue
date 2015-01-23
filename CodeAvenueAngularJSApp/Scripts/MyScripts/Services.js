/// <reference path="~/Scripts/angular.min.js" />  
/// <reference path="~/Scripts/MyScripts/Module.js" />  

app.service("CRUD_AngularJs_RESTService", function ($http) {
    //Create new record  
    this.post = function (Product) {
        var request = $http({
            method: "post",
            url: "http://localhost:27321/ProductService.svc/AddToCart",
            data: Product
        });
        return request;
    }

    //Update the Record  
    this.put = function (ProductID, Product) {
        debugger;
        var request = $http({
            method: "put",
            url: "http://localhost:27321/ProductService.svc/UpdateProductInCart",
            data: Product
        });
        return request;
    }

    this.getAllProducts = function () {
        return $http.get("http://localhost:27321/ProductService.svc/GetAllProducts");
    };

    //Get Single Records  
    this.get = function (ProductID) {
        return $http.get("http://localhost:27321/ProductService.svc/GetProductDetails/" + ProductID);
    }

    //Delete the Record  
    this.delete = function (ProductID) {
        var request = $http({
            method: "delete",
            url: "http://localhost:27321/ProductService.svc/DeleteProductFromCart/" + ProductID
        });
        return request;
    }
});