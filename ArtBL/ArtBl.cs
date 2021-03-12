using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using ArtDL;


namespace auctionBL
{
   public class ArtBl :IArtBl
    {
        private readonly IArtRepo _repo;
        public ArtBl(IArtRepo repo)
        {
            _repo = repo;

        }
        public List<Art> GetArt()
        {
            return _repo.GetAll();
        }

        public List<Art> GetArtByArtist(int id)
        {
            return GetArt().Where(x => x.ArtistId==id).ToList();
        }
    }
}
