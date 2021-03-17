using System.Collections.Generic;
using ArtModel;

namespace auctionBL
{
    public interface IArtBl
    {
        public List<Art> GetArt();
        public List<Art> GetArtByArtist(int id);
        public string GetArtistName(int id);

        public string GetArtistEmail(int id);
        public bool GetInBid(int id);
        public string GetOwner(int id);
    }
}