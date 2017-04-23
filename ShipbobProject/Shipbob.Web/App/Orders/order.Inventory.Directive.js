(function() {
    "use strict";

    angular
        .module("shipBobProjectApp")
        .directive("sbInventoryDisplay", function sbInventoryDisplay() {
            return {
                templateUrl: "App/Orders/_sbOrderInventoryTemplate.html",
                restrict: "E",
                scope: {
                  //isolated scope
                },
                controller: function($scope, orderService, appConfiguration) {
                    var self = this;
                    $scope.InventoryCounts = orderService.GetCurrentInventory();

                    self.checkInventory = function() {
                        (function () {
                            setTimeout(function () {
                               
                                orderService.GetInventoryCount().then(function () {
                                    $scope.InventoryCounts = orderService.GetCurrentInventory();
                                    self.checkInventory();
                                });
                            }, appConfiguration.inventoryCheckInvernal);
                        })();
                    };

                    self.checkInventory();
                }
            };
        });


}());
