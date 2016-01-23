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
    public class UserController : ApiController
    {
        private IGenericRepository _repo;

        public UserController(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IHttpActionResult Get()
        {
            return Ok(_repo.Query<Bid>().ToList());
        }

        public IHttpActionResult Post(Bid user)
        {
            if (ModelState.IsValid)
            {
                _repo.Add<Bid>(user);
                _repo.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}
