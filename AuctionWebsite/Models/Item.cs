using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionWebsite.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinBid { get; set; }        
        public bool IsActive { get; set; }
        public decimal CurrentBid { get; set; }
        public int BidCounter { get; set; }

        public ICollection<Bid> Bids { get; set; }

       
    }

}