using System.Collections.Generic;
using ArtModel;
namespace auctionBL
{
   public interface IArtistBl
    {
        public List<Artist> GetArtists();
        public List<Art> GetArt(int id);
        public List<Seller> GetSellers();
        public bool InBid(int id);
        public string Owner(int id);
        public bool Owned(int id);
        public bool Attach(int aid, int sid);
    }
}