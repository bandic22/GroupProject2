using AuctionWebsite.Models;
using genericRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebsite.Repository
{
    public class ItemRepository : GenericRepository, IItemRepository
    {
        private IGenericRepository _repo;

        public ItemRepository(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void AddBid(string name, decimal bidAmount, int itemId)
        {
            var original = _repo.Query<Item>().Where(i => i.Id == itemId).Include(i => i.Bids).FirstOrDefault();
            original.CurrentBid = bidAmount;
            original.BidCounter++;
            if(original.BidCounter >= 3)
            {
                original.IsActive = false;
            }
            else
            {
                original.Bids.Add(new Bid { BidAmount = bidAmount, BidderName = name });
            }

        }

    }
}