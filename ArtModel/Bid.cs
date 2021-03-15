using System;


namespace ArtModel
{
    public class Bid : IBid
    {
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int AuctionId { get; set; }
        public int ArtId { get; set; }
        public Decimal Amount { get; set; }
        public DateTime TimeOfBid { get; set; }
    }
}