using System;


namespace ArtModel
{
    public class Bid : IBid
    {
        public int Id { get; set; }
        public int CollectorId { get; set; }
        public int ArtId { get; set; }
        public int Amount { get; set; }
        public DateTime TimeOfBid { get; set; }
    }
}