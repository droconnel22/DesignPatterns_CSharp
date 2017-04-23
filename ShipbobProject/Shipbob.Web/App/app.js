(function() {
    "use strict";

    var app = angular.module("shipBobProjectApp", ["ui.router", "LocalStorageModule"]);


    app.config([
        "$stateProvider", "$locationProvider", "localStorageServiceProvider", function ($stateProvider,$locationProvider, localStorageServiceProvider ) {
            $locationProvider.html5Mode(false);
            localStorageServiceProvider.setPrefix('shipBobProjectApp');
            localStorageServiceProvider.setStorageType('sessionStorage');

            $stateProvider
                .state("Order", {
                    url: "/PlaceOrder",
                    controller: "orderController",
                    templateUrl: "App/Orders/orderForm.html",
                    data: {
                        requireLogin: false
                    },
                    resolve: {
                        $q:"$q",
                        orderService:"orderService",
                        initialInventory: function($q, orderService) {
                            var initailizePromise = $q.defer();
                        
                            orderService.InitalizeInventory().then(function(response) {
                                initailizePromise.resolve(response);
                            }).catch(function(errorBack) {
                                initailizePromise.reject(errorBack);
                            });

                            return initailizePromise.promise;
                        }
                    }
                });
        }
    ]);

    app.run(['$rootScope', '$state',
       function ($rootScope, $state) {

           $state.go('Order', {}, { reload: true });
       }]);


}());