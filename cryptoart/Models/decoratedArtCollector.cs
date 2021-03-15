using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.Models
{
    public class decoratedArtCollector
    {
        public decoratedArtCollector(Art art) {
            Id = art.Id;
            Name = art.Name;
            CurrentValue = art.CurrentValue;
            Thumbnail = art.Thumbnail;
            ArtistId = art.ArtistId;
            CollectorsBid = 0.00m;

         }
        public string Owner{get;set;}
        public bool InBid { get; set; }

        public bool Owned { get; set; }
        public decimal CurrentValue { get; set; }
        public int Id { get; set; } 
        public DateTime? ClosingDate { get; set; }
       // public string Location { get; set; }
        public string Name { get; set; }
       public decimal CollectorsBid { get; set; }
        public string Thumbnail { get; set; }
      
        public int MaxSeries { get; set; }
     
        public int ArtistId { get; set; }

    }
}
