namespace MyApp.Services {

    export class ItemService {
        private ItemResource;

        constructor(private $resource: ng.resource.IResourceService) {
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

        public getItems() {
            return this.ItemResource.query();
        }

        public getItem(id: number) {

            return this.ItemResource.get({ id: id });
        }

        public createItem(item) {

            this.ItemResource.createItem(item);

        }

        public createBid(bid) {
                this.ItemResource.createBid(bid);
        }

    }
    angular.module("MyApp").service("ItemService", ItemService);
}