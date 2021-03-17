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
[Range(0.01,1000000.00)]
        public Decimal Amount { get; set; }
        public DateTime TimeOfBid { get; set; }
    }
}