myApp.controller('ProductController', ['$scope', '$log', function ($scope, $log) {
    $scope.product = {};
    $scope.productList = [];
    $scope.currentPage = 1;
    $scope.pageSize = 40;
    $scope.total = 300;
   // $scope.page = 1;

    //$scope.search1 = '';
    // A function to do some act on paging click
    // In reality this could be calling a service which
    // returns the items of interest from the server
    // based on the page parameter
    $scope.DoCtrlPagingAct = function (text, page, pageSize, total) {
        $log.info({
            text: text,
            page: page,
            pageSize: pageSize,
            total: total
        });
        console.log($log.info);
        axios.get('/Product/GetProductList1', {
            params: {
                page: page,      // Assuming page is a variable holding the page number
                search: null   // Assuming search is a variable holding the search string
            },
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                // handle success
                console.log(response.data);
                var model = JSON.parse(response.data) ;
                $scope.productList = model;
                $scope.currentPage = model[0].currentPage;
                $scope.pageSize = model[0].pageSize;
                $scope.total = model[0].totalRecords;
            })
            .catch(error => {
                // handle error
                console.error(error);
            });

        // Make POST request using Axios
        //axios.get('/Product/GetProductList', page, null  {
        //    headers: {
        //        'Content-Type': 'application/json'
        //    }
        //})
            //.then(function (response) {
            //    // Handle success response
            //    //if (response.data.isValid) {
            //    //    alert(response.data.Message);
            //    //    window.location.href = '/Product/GetProductList';
            //    //} else {
            //    //    alert(response.data.Message);
            //    //}
            //   // $scope.productList= response.data
            //})
            //.catch(function (error) {
            //    // Handle error
            //    console.error(error);
            //});
    
    };

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
        $scope.currentPage = model[0].currentPage;
        $scope.pageSize = model[0].pageSize;
        $scope.total = model[0].totalRecords;
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