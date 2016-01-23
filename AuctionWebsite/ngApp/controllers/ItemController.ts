namespace MyApp.Controllers {

    export class ItemController {
        public item;
        public items;

        constructor(private $uibModal: angular.ui.bootstrap.IModalService, private ItemService: MyApp.Services.ItemService, private $location: angular.ILocationService) {
            this.items = this.ItemService.getItems();
        }

        public saveItem() {

            this.ItemService.createItem(this.item);

        }

        public openModal(id) {

            this.$uibModal.open({

                templateUrl: "/ngApp/views/bidModal.html",
                controller: ModalController,
                controllerAs: "vm",
                resolve: {
                    itemId: () => id
                }
            });

        }



    }

    class ModalController {

        public item;
        public bid;
        public validBid = true;

        constructor(private itemId, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private ItemService: MyApp.Services.ItemService) {
            
            this.item = this.ItemService.getItem(itemId);

        }

        public createBid() {
            this.bid.itemId = this.item.id;

            if (this.bid.bidAmount > this.item.currentBid) {
                this.item.currentBid = this.bid.bidAmount;
                this.ItemService.createBid(this.bid);
            }
            else {
                this.validBid = false;
            }
            

        }

    }
  

}