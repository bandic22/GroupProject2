var MyApp;
(function (MyApp) {
    var Controllers;
    (function (Controllers) {
        var ItemController = (function () {
            function ItemController($uibModal, ItemService, $location) {
                this.$uibModal = $uibModal;
                this.ItemService = ItemService;
                this.$location = $location;
                this.items = this.ItemService.getItems();
            }
            ItemController.prototype.saveItem = function () {
                this.ItemService.createItem(this.item);
            };
            ItemController.prototype.openModal = function (id) {
                this.$uibModal.open({
                    templateUrl: "/ngApp/views/bidModal.html",
                    controller: ModalController,
                    controllerAs: "vm",
                    resolve: {
                        itemId: function () { return id; }
                    }
                });
            };
            return ItemController;
        })();
        Controllers.ItemController = ItemController;
        var ModalController = (function () {
            function ModalController(itemId, $uibModalInstance, ItemService) {
                this.itemId = itemId;
                this.$uibModalInstance = $uibModalInstance;
                this.ItemService = ItemService;
                this.validBid = true;
                this.item = this.ItemService.getItem(itemId);
            }
            ModalController.prototype.createBid = function () {
                this.bid.itemId = this.item.id;
                if (this.bid.bidAmount > this.item.currentBid) {
                    this.item.currentBid = this.bid.bidAmount;
                    this.ItemService.createBid(this.bid);
                }
                else {
                    this.validBid = false;
                }
            };
            return ModalController;
        })();
    })(Controllers = MyApp.Controllers || (MyApp.Controllers = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=ItemController.js.map