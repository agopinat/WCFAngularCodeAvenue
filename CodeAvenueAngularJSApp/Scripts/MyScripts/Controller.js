// <reference path="~/Scripts/angular.min.js" />  
/// <reference path="~/Scripts/MyScripts/Module.js" />  
/// <reference path="~/Scripts/MyScripts/Services.js" />

app.controller("CRUD_AngularJS_RestController", function ($scope, CRUD_Angular_JS) {

    $scope.OperType = 1;
    //1 Mean New Entry  

    GetAllProducts();
    //To Get All Records  
    function GetAllProducts() {
        var promiseGet = CRUD_AngularJs_RESTService.GetAllProducts();
        promiseGet.then(function (pl) { $scope.Products = pl.data },
              function (errorPl) {
                  $log.error('Some Error in Getting Records.', errorPl);
              });
    }

    //To Clear all input controls.  
    function ClearModels() {
        $scope.OperType = 1;
        $scope.ProductID = "";
        $scope.CartID = "";
        $scope.Name = "";
        $scope.Price = "";
        $scope.Description = "";
        $scope.Car = "";
        $scope.Image = "";
        $scope.QuantityInHand = "";
    }

    //To Create new record and Edit an existing Record.  
    $scope.save = function () {
        var Product = {
            ProductID: $scope.ProductID,
            CartID: $scope.CartID,
            Name: $scope.Name,
            Price: $scope.Price,
            Description: $scope.Description,
            Car: $scope.Car,
            Image: $scope.Image,
            QuantityInHand: $scope.QuantityInHand
        };
        if ($scope.OperType === 1) {
            var promisePost = CRUD_AngularJs_RESTService.post(Product);
            promisePost.then(function (pl) {
                $scope.ProductID = pl.data.ProductID;
                GetAllProducts();

                ClearModels();
            }, function (err) {
                console.log("Some error Occured" + err);
            });
        } else {
            //Edit the record      
            debugger;
            Product.ProductID = $scope.ProductID;
            var promisePut = CRUD_AngularJs_RESTService.put($scope.ProductID, Product);
            promisePut.then(function (pl) {
                $scope.Message = "Product Updated Successfuly";
                GetAllProducts();
                ClearModels();
            }, function (err) {
                console.log("Some Error Occured." + err);
            });
        }
    };

    //To Get Product Detail on the Base of Product ID  
    $scope.get = function (Product) {
        var promiseGetSingle = CRUD_AngularJs_RESTService.get(Product.ProductID);
        promiseGetSingle.then(function (pl) {
            var res = pl.data;

            $scope.ProductID = res.ProductID
            $scope.CartID = res.CartID;
            $scope.Name = res.Name;
            $scope.Price = res.Price;
            $scope.Description = res.Description;
            $scope.Car = res.Car;
            $scope.Image = res.Image;
            $scope.QuantityInHand = res.QuantityInHand;
            $scope.OperType = 0;
        },
                  function (errorPl) {
                      console.log('Some Error in Getting Details', errorPl);
                  });
    }

    //To Delete Record  
    $scope.delete = function (Product) {
        var promiseDelete = CRUD_AngularJs_RESTService.delete(Product.ProductID);
        promiseDelete.then(function (pl) {
            $scope.Message = "Product Deleted Successfuly";
            GetAllProducts();
            ClearModels();
        }, function (err) {
            console.log("Some Error Occured." + err);
        });
    }
});