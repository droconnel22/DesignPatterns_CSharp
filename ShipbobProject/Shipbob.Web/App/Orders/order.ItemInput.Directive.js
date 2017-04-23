(function() {
    "use strict";

    angular
        .module("shipBobProjectApp")
        .directive("sbOrderItemInput", function sbOrderItemInput() {
            return {
                templateUrl: "App/Orders/_sbOrderItemInputTemplate.html",
                restrict: "E",
                controllerAs:"oiic",
                controller: "orderItemInputController",
                scope: {
                    orderModel:'='//two way binding, required. vs. =?
                },
                link: function orderItemInputLink($scope, element, attrs, controller) {
                    //not used but here for completeness.
                }
            }
        });

}());