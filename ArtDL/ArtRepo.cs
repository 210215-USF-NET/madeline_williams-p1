using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using Microsoft.EntityFrameworkCore;
using Serilog;
namespace ArtDL
{
    public class ArtRepo:IArtRepo
    {
        private readonly ArtDBContext _context;


        public  ArtRepo(ArtDBContext context)
        {
            _context = context;
        } 
       public List<Art> GetAll() {

            return _context.Arts.ToList();
        }

        public List<Auction> Maintain() 
        {
            DateTime testingDate = DateTime.Now;
            List<Auction> auctions = _context.Auctions.Where(x => (testingDate.CompareTo(x.ClosingDate)>0) && (x.Notify &1)== 0).ToList();
            foreach (Auction a in auctions)
            {
                Log.Information("now greater than closing");
                Log.CloseAndFlush();
                SellerInventory si = _context.SellerInventories.Where(x => x.ArtId == a.ArtId).FirstOrDefault();
                if (si != null)
                {
                    Log.Information("Removing art "+a.ArtId+ "from seller");
                    _context.SellerInventories.Remove(si);
                    _context.SaveChanges();
                }
                CollectorsGallery cg = new CollectorsGallery();
                cg.ArtId = a.ArtId;
                Bid bid = _context.Bids.Where(x => x.ArtId == a.ArtId && x.TimeOfBid < a.ClosingDate).OrderByDescending(z => z.TimeOfBid).FirstOrDefault();
                cg.CollectorId = bid.CollectorId;
                if (_context.CollectorsGalleries.Where(x => cg.CollectorId == x.CollectorId && cg.ArtId == x.ArtId).FirstOrDefault() == null) {
                    Log.Information("adding art " + a.ArtId + "to collector");
                    _context.CollectorsGalleries.Add(cg);
                }
                a.Notify = 1;
                _context.SaveChanges();
               
            }
            return auctions;
        }

        public string GetArtistName(int id)
        {
           
            return _context.Artists.Find(id).Name;
        }
        public string GetArtistEmail(int id)
        {

            return _context.Artists.Find(id).Email;
        }

        public string GetArtistEmailByArt(int id)
        {
            int ArtistId = _context.Arts.Find(id).ArtistId;

            return _context.Artists.Find(ArtistId).Email;
        }
        public bool GetInBid(int id)
        {
            return _context.Auctions.AsNoTracking().Where(q => q.ClosingDate > DateTime.Now && q.ArtId == id).FirstOrDefault() != null;
        }
        public string GetOwner(int id)
        {
            string name = "";
            SellerInventory si = _context.SellerInventories.Where(x => x.ArtId == id).FirstOrDefault();
            if (si != null)
            {
                name = _context.Sellers.Where(x => x.Id == si.SellerId).FirstOrDefault().Name;
            }
            CollectorsGallery cg = _context.CollectorsGalleries.Where(x => x.ArtId == id).FirstOrDefault();
            if (cg != null)
            {
                name = _context.Collectors.Where(x => x.Id == cg.CollectorId).FirstOrDefault().Name;
            }


            return name;

        }

        public List<string> GetNotify(string user,int id)
        {
            List<Auction> auctions = new List<Auction>();
            List<string> notifyList = new List<string>();
            int checkbit = 0;
            string flavor = "";
            switch (user)
            {
                case "collector":
                    auctions = _context.Auctions.Where(x => DateTime.Now > x.ClosingDate && (x.Notify & 2) == 0).ToList();

                    checkbit = 2;
                    flavor = "Congratulations! You Won ";
                    break;
                case "artist":
                    auctions = _context.Auctions.Where(x => DateTime.Now > x.ClosingDate && (x.Notify & 4) == 0).ToList();
                    checkbit = 4;
                    flavor = "Congratulations! Your art ";
                    break;
                case "seller":
                    auctions = _context.Auctions.Where(x => DateTime.Now > x.ClosingDate && (x.Notify &  8)==0 && x.SellerId==id).ToList();

                    checkbit = 8;
                    flavor = "Congratulations! Your auction ";
                    break;
                 default:
                    return notifyList;
                   
            }
            foreach (Auction a in auctions)
            {
                Log.Information(DateTime.Now.ToString() + " " + a.ClosingDate.ToString() + "   " + (DateTime.Now > a.ClosingDate).ToString());
                Log.CloseAndFlush();
                string art = "";
                string closingBid = "";
               
                Art at = _context.Arts.Where(x => a.ArtId == x.Id).FirstOrDefault();
                if (at != null)
                {
                    art = at.Name;
                    closingBid = at.CurrentValue.ToString();
                }

                DateTime d = DateTime.Now;
                bool cd = d.CompareTo(a.ClosingDate) > 0;
                if (cd&&((checkbit == 4 && at.ArtistId == id)|| checkbit==8 || (checkbit==2&& _context.Bids.Where(x => x.CollectorId == id && x.Amount == at.CurrentValue).FirstOrDefault()!=null)))
                {
                    Log.Information("adding art " + a.ArtId + "to notification list");
                    notifyList.Add(flavor + art + " sold for " + closingBid);
                    a.Notify += checkbit;
                    _context.SaveChanges();
                }
            }
            Log.CloseAndFlush();
            return notifyList;
        }

    }
}
