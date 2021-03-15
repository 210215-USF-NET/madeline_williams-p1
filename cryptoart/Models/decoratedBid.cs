using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.Models
{
    public class decoratedBid
    {
        public decoratedBid(Bid art) {
            Id = art.Id;
            AuctionId = art.AuctionId;
            CollectorId = art.CollectorId;
            ArtId = art.ArtId;
            Amount = art.Amount;
            TimeOfBid = art.TimeOfBid;

         }
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int AuctionId { get; set; }
        public int ArtId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime TimeOfBid { get; set; }
        public DateTime Closing { get; set; }
    }
}
