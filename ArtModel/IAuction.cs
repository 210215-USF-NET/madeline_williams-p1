using System;

namespace ArtModel
{
    public interface IAuction
    {
        int ArtId { get; set; }
        DateTime ClosingDate { get; set; }
        int Id { get; set; }
        decimal MinimumBid { get; set; }
        int Notify { get; set; }
        int SellerId { get; set; }
    }
}