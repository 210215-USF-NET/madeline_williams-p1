using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;

namespace ArtDL
{
    public interface IArtistRepo
    {
        public List<Artist> GetAll();
        public Artist Save(Artist artist);
        public List<Art> GetArt(int id);
        public List<Seller> GetSellers();
        public bool InBid(int id);
        public string Owner(int id);
        public bool Attach(int aid, int sid);

    }
}
