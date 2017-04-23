(function() {
    "use strict";

    function AvailableItem(type,color, action ) {
        this.type = type;
        this.color = color;
        this.OnAdd = action;
    };

    AvailableItem.prototype.label = function() {
        return this.color + ' ' + this.type;
    };


    angular
        .module("shipBobProjectApp")
        .controller("orderItemInputController", function orderItemInputController($q, $scope, orderService) {
            var self = this;

            self.inventoryItems = orderService.GetAvailableInventoryItems();

            /* See bottom for creational object list*/
        

            $scope.addItemToList = function (currentItem) {
                if ($scope.orderModel.Items == null) {
                    $scope.orderModel.Items = [];
                }

                if (typeof (currentItem) === "undefined") {
                    return;
                }
               
                for (var i = 0; i < self.inventoryItems.length; i++) {
                    if (self.inventoryItems[i].ItemType === currentItem.type && self.inventoryItems[i].ItemColor === currentItem.color) {
                        var chosenInventoryItem = self.inventoryItems[i];
                        //Add To ORder Items
                        var currentOrderItemIndex = $scope.orderModel.Items.indexOf(chosenInventoryItem);
                        if (currentOrderItemIndex === -1) {
                            $scope.orderModel.Items.push(chosenInventoryItem);
                        }
                        //Remove from Inventory
                        var currentInventoryItemIndex = self.inventoryItems.indexOf(chosenInventoryItem);
                        if (currentInventoryItemIndex > -1) {
                            self.inventoryItems.splice(currentInventoryItemIndex, 1);
                        }
                        break;
                    }
                }
              
            };

            $scope.addBundleToList = function() {
                /*Ideally I would check if all items types existed*/
                if ($scope.orderModel.Items == null) {
                    $scope.orderModel.Items = [];
                }

                var bundeList = [
                    new AvailableItem("Bat", "Blue", $scope.addItemToList),
                    new AvailableItem("Hat", "White", $scope.addItemToList),
                    new AvailableItem("Baseball", "Red", $scope.addItemToList)
                ];


                for (var j = 0; j < bundeList.length; j++) {
                    
                    for (var i = 0; i < self.inventoryItems.length; i++) {
                        if (self.inventoryItems[i].ItemType === bundeList[j].type && self.inventoryItems[i].ItemColor === bundeList[j].color) {
                            var chosenInventoryItem = self.inventoryItems[i];

                            chosenInventoryItem.IsSold = true;
                            //Add To ORder Items
                            var currentOrderItemIndex = $scope.orderModel.Items.indexOf(chosenInventoryItem);
                            if (currentOrderItemIndex === -1) {
                                $scope.orderModel.Items.push(chosenInventoryItem);
                            }
                            //Remove from Inventory
                            var currentInventoryItemIndex = self.inventoryItems.indexOf(chosenInventoryItem);
                            if (currentInventoryItemIndex > -1) {
                                self.inventoryItems.splice(currentInventoryItemIndex, 1);
                            }
                            break;
                        }
                    }
                }
            };

            $scope.removeItemFromList = function (currentItem) {
                    if ($scope.orderModel.Items == null || typeof (currentItem) === "undefined") {
                        $scope.orderModel.Items = [];
                        return;
                    }

                    //Remove From Order
                    var currentOrderItemIndex = $scope.orderModel.Items.indexOf(currentItem);
                    if (currentOrderItemIndex > -1) {
                        $scope.orderModel.Items.splice(currentOrderItemIndex,1);
                    }

                //Add Back to Inventory
                    currentItem.IsSold = false;
                    var currentInventoryItemIndex = self.inventoryItems.indexOf(currentItem);
                    if (currentInventoryItemIndex === -1) {
                        self.inventoryItems.push(currentItem);
                    }
                
            };


            $scope.availableItems = [
                new AvailableItem("Bat", "Blue", $scope.addItemToList),
                new AvailableItem("Hat", "White", $scope.addItemToList),
                new AvailableItem("Baseball", "Red", $scope.addItemToList),
                new AvailableItem("Bundle", "Baseball", $scope.addBundleToList)
            ];


        });

}());