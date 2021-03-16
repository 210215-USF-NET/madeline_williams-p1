using System;
using System.ComponentModel.DataAnnotations;

namespace ArtModel
{
    public class Bid : IBid
    {
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int AuctionId { get; set; }
        public int ArtId { get; set; }
[Required]

        public Decimal Amount { get; set; }
        public DateTime TimeOfBid { get; set; }
    }
}