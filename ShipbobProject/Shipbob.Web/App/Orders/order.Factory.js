(function() {
    "use strict";

    angular
        .module('shipBobProjectApp')
        .factory('orderFactory', ["$q", "$http", orderFactory]);

    function orderFactory($q,$http) {
        return {
            GetInventory: function() {
                var result = $q.defer();

                $http({
                    method: 'GET',
                    url: '/Order/GetInventory'
                }).then(function (response) {
                    result.resolve(response);
                }, function (error) {
                    result.reject(error);
                });

                return result.promise;
            },
            GetInventoryCheck: function () {
                var result = $q.defer();

                $http({
                    method: 'GET',
                    url: '/Order/CheckInventory'
                }).then(function (response) {
                    result.resolve(response);
                }, function (error) {
                    result.reject(error);
                });

                return result.promise;
            },
            PostOrder: function(model) {
                var result = $q.defer();
                $http({
                    method: 'POST',
                    url: '/Order/PostOrder',
                    data: model
                }).then(function (response) {
                    result.resolve(response);
                }, function (error) {
                    result.reject(error);
                });

                return result.promise;
            }
        
        };
    }

}());