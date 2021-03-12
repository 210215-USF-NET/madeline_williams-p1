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

    }
}
