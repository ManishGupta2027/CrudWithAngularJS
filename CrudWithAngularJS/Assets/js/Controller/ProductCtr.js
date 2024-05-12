myApp.controller('ProductController', ['$scope', function ($scope) {
    $scope.product = {};

    //$scope.search1 = '';

    $scope.submitForm = function () {
        if ($scope.productForm.$valid) {
            var data = {
                title: $scope.product.title,
                stockCode: $scope.product.stockCode,
                price: $scope.product.price,
                category: $scope.product.category,
                gender: $scope.product.gender,
                isActive: $scope.product.isActive
            };

            // Make POST request using Axios
            axios.post('/Product/NewProduct', data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(function (response) {
                    // Handle success response
                    if (response.data.isValid) {
                        alert(response.data.Message);
                        window.location.href = '/Product/GetProductList';
                    } else {
                        alert(response.data.Message);
                    }
                })
                .catch(function (error) {
                    // Handle error
                    console.error(error);
                });
        } else {
            // Form is invalid, display error messages
            $scope.productForm.$submitted = true;
        }
    };

    $scope.initList = function (model) {
        $scope.productList = model;
    }
    ///we not use searching in js  so dont use js 
    //$scope.search = function () {
    //    window.location.reload(); // Reload the page
    //    // Make POST request using Axios
    //    axios.get('/Product/GetProductsear', {
    //        params: {
    //            search: $scope.search1
    //        },
    //        headers: {
    //            'Content-Type': 'application/json'
    //        }
    //    });
    //    //    .then(function (response) {
    //    //    // Handle response data as needed
    //    //    console.log(response.data);
    //    //    $scope.productList = response.data;
    //    //})
    //    //    .catch(function (error) {
    //    //        // Handle errors
    //    //        console.error(error);
    //    //    });;
    //}

    $scope.initEdit = function (model) {
        $scope.product = model;
    }

    $scope.updateForm = function () {
        if ($scope.productForm.$valid) {
            var data = {
                id: $scope.product.id,
                title: $scope.product.title,
                stockCode: $scope.product.stockCode,
                price: $scope.product.price,
                category: $scope.product.category,
                gender: $scope.product.gender,
                isActive: $scope.product.isActive,
            };

            // Make POST request using Axios
            axios.post('/Product/NewProduct', data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(function (response) {
                    // Handle success response
                    if (response.data.isValid) {
                        alert(response.data.Message);
                        window.location.href = '/Product/GetProductList';
                    } else {
                        alert(response.data.Message);
                    }
                })
                .catch(function (error) {
                    // Handle error
                    console.error(error);
                });
        } else {
            // Form is invalid, display error messages
            $scope.productForm.$submitted = true;
        }

    };

}]);