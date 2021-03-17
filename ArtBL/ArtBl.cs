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
        public string GetArtistName(int id)
        {
           return _repo.GetArtistName(id); 
        }
        public string GetArtistEmail(int id)
        {
            return _repo.GetArtistEmail(id);
        }
        public List<Art> GetArtByArtist(int id)
        {
            return GetArt().Where(x => x.ArtistId==id).ToList();
        }

        public bool GetInBid(int id)
        {
            return _repo.GetInBid(id);
        }
        public string GetOwner(int id)
        {
            return _repo.GetOwner(id);
        }

    }
}
