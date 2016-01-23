var MyApp;
(function (MyApp) {
    var Services;
    (function (Services) {
        var ItemService = (function () {
            function ItemService($resource) {
                this.$resource = $resource;
                this.ItemResource = $resource('/api/items/:id', null, {
                    createBid: {
                        url: "/api/items/createBid",
                        method: "POST"
                    },
                    createItem: {
                        url: "/api/items/createItem",
                        method: "POST"
                    }
                });
            }
            ItemService.prototype.getItems = function () {
                return this.ItemResource.query();
            };
            ItemService.prototype.getItem = function (id) {
                return this.ItemResource.get({ id: id });
            };
            ItemService.prototype.createItem = function (item) {
                this.ItemResource.createItem(item);
            };
            ItemService.prototype.createBid = function (bid) {
                this.ItemResource.createBid(bid);
            };
            return ItemService;
        })();
        Services.ItemService = ItemService;
        angular.module("MyApp").service("ItemService", ItemService);
    })(Services = MyApp.Services || (MyApp.Services = {}));
})(MyApp || (MyApp = {}));
//# sourceMappingURL=ItemService.js.map