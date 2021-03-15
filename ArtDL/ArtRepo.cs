using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using Microsoft.EntityFrameworkCore;

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
            List<Auction> auctions = _context.Auctions.Where(x => DateTime.Now > x.ClosingDate && x.Notify == 0).ToList();
            foreach (Auction a in auctions)
            {
                SellerInventory si = _context.SellerInventories.Where(x => x.ArtId == a.ArtId).FirstOrDefault();
                if (si != null)
                {
                    _context.SellerInventories.Remove(si);
                    _context.SaveChanges();
                }
                CollectorsGallery cg = new CollectorsGallery();
                cg.ArtId = a.ArtId;
                Bid bid = _context.Bids.Where(x => x.ArtId == a.ArtId && x.TimeOfBid < a.ClosingDate).OrderByDescending(z => z.TimeOfBid).FirstOrDefault();
                cg.CollectorId = bid.CollectorId;
                if (_context.CollectorsGalleries.Where(x => cg.CollectorId == x.CollectorId && cg.ArtId == x.ArtId).FirstOrDefault() == null) { 
                    _context.CollectorsGalleries.Add(cg);
                }
                a.Notify = 1;
                _context.SaveChanges();
               
            }
            return auctions;
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
                string art = "";
                string closingBid = "";
               
                Art at = _context.Arts.Where(x => a.ArtId == x.Id).FirstOrDefault();
                if (at != null)
                {
                    art = at.Name;
                    closingBid = at.CurrentValue.ToString();
                }
              
                 

                if ((checkbit == 4 && at.ArtistId == id)|| checkbit==8 || (checkbit==2&& _context.Bids.Where(x => x.CollectorId == id && x.Amount.ToString() == at.CurrentValue.ToString()).FirstOrDefault()!=null))
                {
                    notifyList.Add(flavor + art + " sold for " + closingBid);
                    a.Notify += checkbit;
                    _context.SaveChanges();
                }
            }
            return notifyList;
        }

    }
}
