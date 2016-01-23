using AuctionWebsite.Models;
using genericRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuctionWebsite.API
{
    public class ItemsController : ApiController
    {
        private IGenericRepository _repo;

        public ItemsController(IGenericRepository repo)
        {
            _repo = repo;
        }
        public IHttpActionResult Get()
        {
            return Ok(_repo.Query<Item>().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_repo.Find<Item>(id));
        }

        [Route("api/items/createItem")]
        public IHttpActionResult Post(Item item)
        {
            _repo.Add<Item>(item);
            _repo.SaveChanges();
            return Ok();
        }

        [Route("api/items/createBid")]
        public IHttpActionResult Post(Bid bid)
        {
            //need to assign bid.amount to item.currentBid in server and get bid collection for item back, then find highest bid and display the name and bid amount on the modal + set the item to inactive.
            _repo.Add<Bid>(bid);
            _repo.SaveChanges();
            return Ok();
        }
    }
   
}
