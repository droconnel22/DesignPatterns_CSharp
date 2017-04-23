(function() {
    "use strict";

    angular
        .module("shipBobProjectApp")
        .service("orderService", ["$q", "localStorageService", "orderFactory", orderService]);

    function orderService($q, localStorageService, orderFactory ) {
        var self = this;
        self.currentInventory = [];

        self.currentOrder = {
            TrackingId: null,
            OrderAddress: {},
            Items: []
        };

        self.currentInventoryCheck = {};

        /*
        100 Red baseballs, 100 Blue Bats, and 100 White Hats.
        public int ItemId { get; set; }

        public string ItemType { get; set; }

        public string ItemColor { get; set; }
        */

      


        //Private

        function refreshLocalStorage(currentOrderModel) {
            localStorageService.remove('currentOrder');
            localStorageService.set('currentOrder', angular.toJson(currentOrderModel));
        };

        function refreshInventoryStorage() {
            localStorageService.remove('currentInventory');
            localStorageService.set('currentInventory', angular.toJson(self.currentInventory));
        }

        //Public

        self.initalizeInventory = function () {
            var initalizeInventoryPromise = $q.defer();

            self.currentInventory = angular.fromJson(localStorageService.get('currentInventory'));
            if (self.currentInventory != null) {
                initalizeInventoryPromise.resolve(self.currentInventory);
            }
          
            orderFactory.GetInventory().then(function (response) {

                self.currentInventory = response.data;
                refreshInventoryStorage();

                initalizeInventoryPromise.resolve(self.currentInventory);
            }).catch(function(errorBack) {
                initalizeInventoryPromise.reject(errorBack);
            });
       
            return initalizeInventoryPromise.promise;

        };

        self._getInventoryCount = function() {
            var getInvCountPromise = $q.defer();
            
            orderFactory.GetInventoryCheck().then(function (response) {
                self.currentInventoryCheck = response.data;

                getInvCountPromise.resolve(self.currentInventoryCheck);
            }).catch(function(errorBack) {
                getInvCountPromise.reject(errorBack);
            });

            return getInvCountPromise.promise;
        };

        self._getCurrentInventory = function() {
            return self.currentInventoryCheck.InventoryCounts;
        }
        
        self.submitOrder = function (orderModel) {
            var orderPromise = $q.defer();


            orderFactory.PostOrder(orderModel).then(function () {
                return self.initalizeInventory();
            }).then(function() {
                orderPromise.resolve();
            }).catch(function (errorBack) {
                orderPromise.reject(errorBack);
            });

            return orderPromise.promise;
        };

        self.updateOrderCache = function (currentOrderModel) {
            refreshLocalStorage(currentOrderModel);
        };

        self.GetOrderFromCache = function() {
            self.currentOrder = angular.fromJson(localStorageService.get('currentOrder'));
            if (self.currentOrder == null) { //nullable, dont care about type
                self.currentOrder = {
                    TrackingId: null,
                    OrderAddress: {},
                    Items: []
                };
                refreshLocalStorage(self.currentOrder);
            }

            return self.currentOrder;
        };

        self._getAvailableInventoryItems = function() {
            return self.currentInventory.Items;
        }

        return {
            InitalizeInventory: self.initalizeInventory,
            GetCurrentInventory: self._getCurrentInventory,
            GetInventoryCount: self._getInventoryCount,
            GetAvailableInventoryItems:self._getAvailableInventoryItems,
            UpdateOrderCache: self.updateOrderCache,
            GetOrderFromCache: self.GetOrderFromCache,
            SubmitOrder: self.submitOrder
        };

    };

}());