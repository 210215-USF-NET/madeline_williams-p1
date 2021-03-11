using System.Collections.Generic;
using ArtModel;

namespace auctionBL
{
    public interface IArtBl
    {
        public List<Art> GetArt();
        public List<Art> GetArtByArtist(int id);
    }
}