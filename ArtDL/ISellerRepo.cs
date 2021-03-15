using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;

namespace ArtDL
{
    public interface ISellerRepo
    {
        public List<Seller> GetAll();
        public List<Art> GetArt(int id);
        public bool InBid(int id);
        public Seller Save(Seller user);
        public Auction Save(Auction auction);
        public DateTime? GetClose(int id);
        public List<Art> GetArtInAuction(int id);
    }
}
