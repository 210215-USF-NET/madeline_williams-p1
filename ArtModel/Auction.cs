using System;
using System.ComponentModel.DataAnnotations;

namespace ArtModel
{
    public class Auction : IAuction
    {
        public int Id { get; set; }
        public int ArtId { get; set; }

        public DateTime ClosingDate { get; set; }
        public int SellerId { get; set; }
        public int Notify { get; set; }
        [Required]
        [Range(0.00,1000000.00)]
        public Decimal MinimumBid { get; set; }

    }
}