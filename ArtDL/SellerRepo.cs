using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using Microsoft.EntityFrameworkCore;

namespace ArtDL
{
    public class SellerRepo:ISellerRepo
    {
        private readonly ArtDBContext _context;

        public  SellerRepo(ArtDBContext context)
        {
            _context = context;
        } 
       public List<Seller> GetAll() {

            return _context.Sellers.ToList();
        }
        public string GetSellerName(int id)
        {



                return _context.Sellers.Where(x=>x.Id==id).FirstOrDefault().Name;
        }
        public Seller GetUser(int id)
        {
           return _context.Sellers.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }
        public DateTime? GetClose(int id)
        {
            Auction au= _context.Auctions.Where(x => x.ArtId == id).FirstOrDefault();
            if (au != null)
            {
                return au.ClosingDate;
            }
            return null;
        }
        public Seller GetUser(string name)
        {
            return _context.Sellers.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }



  public List<Art> GetArtInAuction(int id)
        {
            List<Art> arts = new List<Art>();
            List<Auction> si = _context.Auctions.Where(x => x.SellerId == id).ToList();
            if (si == null)
            {
                return arts;
            }
            foreach (Auction s in si)
            {
                Art art = _context.Arts.Where(x => x.Id == s.ArtId).FirstOrDefault();
                arts.Add(art);
            }
            return arts;

        }

        public List<Art> GetArtInCurrentAuction(int id)
        {
            List<Art> arts = new List<Art>();
            List<Auction> si = _context.Auctions.Where(x => x.SellerId == id).ToList();
            if (si == null)
            {
                return arts;
            }
            foreach (Auction s in si)
            {
                Art art = _context.Arts.Where(x => x.Id == s.ArtId&&s.ClosingDate>DateTime.Now).FirstOrDefault();
                if (art != null)
                {
                    arts.Add(art);
                }
            }
            return arts;

        }


        public List<Art> GetArt(int id)
        {
            List<Art> arts = new List<Art>();
            List<SellerInventory> si = _context.SellerInventories.Where(x => x.SellerId == id).ToList();
            if (si == null)
            {
                return arts;
            }
            foreach (SellerInventory s in si) {
                Art art = _context.Arts.Where(x => x.Id == s.ArtId).FirstOrDefault();
                arts.Add(art);
            }
            return arts;
        
        }

        public bool InBid(int id)
        {

            return _context.Auctions.Where(q => q.ClosingDate > DateTime.Now && q.ArtId == id).FirstOrDefault() != null;
        }


        public Seller Save(Seller user)
        {
            Seller tc = _context.Sellers.Find(user.Id);
            if (tc == null)
            {
                tc = _context.Sellers.Add(user).Entity;
                _context.SaveChanges();

            }
            tc.Name = user.Name;
            tc.Email = user.Email;
            _context.SaveChanges();
            return tc;
        }

        public Auction Save(Auction auction)
        {
            Auction tc = _context.Auctions.Add(auction).Entity;
            _context.SaveChanges();
            int aId = tc.Id;
            Bid bid = new Bid();
            bid.Amount = tc.MinimumBid;
            bid.CollectorId = 1;
            bid.TimeOfBid = DateTime.Now;
            bid.ArtId = tc.ArtId;
            bid.AuctionId = tc.Id;
            _context.Bids.Add(bid);
            _context.SaveChanges();
            Art art = _context.Arts.Where(x => x.Id == tc.ArtId).FirstOrDefault();
            if (art != null)
            {
                art.CurrentValue = bid.Amount;
                _context.SaveChanges();
            }
            return tc;
        }


    }
}
