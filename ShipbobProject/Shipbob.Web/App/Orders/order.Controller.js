(function() {
    "use strict";

    angular
        .module('shipBobProjectApp')
        .controller('orderController', ["$state", "$scope","orderService","initialInventory", orderController]);

    function orderController($state, $scope, orderService, initialInventory) {
        var self = this;

        $scope.isOrderSubmitted = false;
        $scope.isOrderFormWorking = false;
        $scope.message = null;
        $scope.shipBobOrderModel = orderService.GetOrderFromCache() || {};

        $scope.submitShipBobOrder = function () {
            $scope.isOrderFormWorking = true;

            orderService.SubmitOrder($scope.shipBobOrderModel).then(function(response) {
                $scope.message = "Congradulations Your Order Has been submitted!";
                $scope.isOrderSubmitted = true;
                $scope.isOrderFormWorking = false;
            }, function(errorBack) {
                $scope.message = "Sorry your order did not go through";
                $scope.isOrderFormWorking = false;
            }, function(onUpdate) {
                //not implemented, but used for intermitten updates from the server.
            });


        };

        $scope.$watch("shipBobOrderModel", function (oldVal, newVal) {
                if (newVal !== oldVal) {
                    orderService.UpdateOrderCache($scope.shipBobOrderModel);
                }
        });
    };

}());