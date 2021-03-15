using System;

namespace ArtModel
{
    public interface IBid
    {
        Decimal Amount { get; set; }
        int ArtId { get; set; }
        int CollectorId { get; set; }
        int AuctionId { get; set; }
        int Id { get; set; }
        DateTime TimeOfBid { get; set; }
    }
}