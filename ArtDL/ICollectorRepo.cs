using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;

namespace ArtDL
{
    public interface ICollectorRepo
    {
        public List<Art> GetArt(int id);
        public List<Collector> GetAll();
        public Collector Save(Collector user);
        public List<Art> GetAuctions(int id);
        public List<Art> GetAuctions();
        public List<Bid> GetBids(int id);
        public DateTime GetClosing(int id);
        public DateTime GetClosingForArt(int id);
        public int GetAuction(int id);
        public Bid Save(Bid bd);
    }
}
