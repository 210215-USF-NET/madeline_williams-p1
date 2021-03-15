using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtDL;
using ArtModel;
namespace auctionBL
{
    
    public class Login : ILogin
    {
    private readonly ArtistRepo _artistrepo;
        private readonly ArrayList _user;
        private readonly SellerRepo _sellrepo;
        private readonly CollectorRepo _collectrepo;
        public Login(IArtistRepo ar, ISellerRepo sr, ICollectorRepo cr)
    {
            _artistrepo = (ArtistRepo) ar;
            _sellrepo = (SellerRepo)sr;
            _collectrepo = (CollectorRepo)cr;
        }

        public IUser GetUser(string name,string user) 
        {

            switch (user)
            {
                case "artist":
                    return GetArtist(name);
                case "seller":
                    return GetSeller(name);
                case "collector":
                    return GetCollector(name);
                default:
                    return null;

            }

        }


        public Collector GetCollector(string name)
        {
            var nameorid = name;
            try
            {
                int id = int.Parse(name);
                return _collectrepo.GetUser(id);
            }
            catch (Exception)
            {
                return _collectrepo.GetUser(name);
            }

        }


        public Seller GetSeller(string name)
        {
            var nameorid = name;
            try
            {
                int id = int.Parse(name);
                return _sellrepo.GetUser(id);
            }
            catch (Exception)
            {
                return _sellrepo.GetUser(name);
            }

        }


        public Artist GetArtist(string name)
        {
            var nameorid = name;
            try
            {
                int id = int.Parse(name);
                return _artistrepo.GetArtist(id);
            }
            catch (Exception) {
                        return _artistrepo.GetArtist(name);
             }

        }

}
}
