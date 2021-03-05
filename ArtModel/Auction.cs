using System;

namespace ArtModel
{
    public class Auction : IAuction
    {
        public int Id { get; set; }
        public int ArtId { get; set; }
        public DateTime ClosingDate { get; set; }
        public int SellerId { get; set; }
        public int Notify { get; set; }
        public Decimal MinimumBid { get; set; }

    }
}