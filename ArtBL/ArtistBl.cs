using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using ArtDL;


namespace auctionBL
{
   public class ArtistBl :IArtistBl
    {
        private readonly IArtistRepo _repo;
        public ArtistBl(IArtistRepo repo)
        {
            _repo = repo;

        }
        public List<Artist> GetArtists()
        {
            return _repo.GetAll();
        }
        public List<Art> GetArt(int id)
        {
            return _repo.GetArt(id);
        }
        public List<Seller> GetSellers()
        {
            return _repo.GetSellers();
        }
        public bool Owned(int id)
        {
            return _repo.Owner( id) != "";

        }
      public string Owner(int id)
        {
            return _repo.Owner( id);

        }

        public bool InBid(int id)
        {
            return _repo.InBid( id);

        }

        public bool Attach(int aid, int sid)
        {
            return _repo.Attach(aid, sid);
        }
    }
}
