using ArtModel;

namespace auctionBL
{
    public interface ILogin
    {
        public IUser GetUser(string user, string name);
    }
}