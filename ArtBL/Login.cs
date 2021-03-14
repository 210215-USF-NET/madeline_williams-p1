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
    public Login(IArtistRepo ar)
    {
            _artistrepo = (ArtistRepo) ar;

    }

        public IUser GetUser(string name,string user) 
        {

            
            return GetArtist(name);
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
