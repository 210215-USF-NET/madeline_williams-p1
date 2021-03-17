using System.Collections.Generic;
using ArtModel;

namespace ArtDL
{
    public interface IArtRepo
    {
        public List<Art> GetAll();
        public List<Auction> Maintain();
        public List<string> GetNotify(string user,int id);
        public string GetArtistEmail(int id);
        public string GetArtistName(int id);
        public string GetOwner(int id);
        public bool GetInBid(int id);
    }
}