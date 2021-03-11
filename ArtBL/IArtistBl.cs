using System.Collections.Generic;
using ArtModel;
namespace auctionBL
{
   public interface IArtistBl
    {
        public List<Artist> GetArtists();
    }
}