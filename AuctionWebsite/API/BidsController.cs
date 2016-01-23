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
    public class BidsController : ApiController
    {
        private IGenericRepository _repo;

        public BidsController(IGenericRepository repo)
        {
            _repo = repo;
        }
        public IHttpActionResult Get()
        {
            return Ok(_repo.Query<Bid>().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_repo.Find<Bid>(id));
        }

        public IHttpActionResult Post(Bid Bid)
        {
            _repo.Add<Bid>(Bid);
            _repo.SaveChanges();
            return Ok();
        }
    }
}
