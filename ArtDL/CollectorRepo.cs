using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using Microsoft.EntityFrameworkCore;

namespace ArtDL
{
    public class CollectorRepo:ICollectorRepo
    {
        private readonly ArtDBContext _context;

        public  CollectorRepo(ArtDBContext context)
        {
            _context = context;
        } 
       public List<Collector> GetAll() {

            return _context.Collectors.ToList();
        }

        public Collector GetUser(int id)
        {
           return _context.Collectors.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public Collector GetUser(string name)
        {
            return _context.Collectors.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
        public string GetName(int id)
        {
            return _context.Collectors.Find(id).Name;
        }
        public string GetOwner(int id)
        {

            string name = "";
           
            CollectorsGallery cg = _context.CollectorsGalleries.Where(x => x.ArtId == id).FirstOrDefault();
            if (cg != null)
            {
                name = _context.Collectors.Where(x => x.Id == cg.CollectorId).FirstOrDefault().Name;
            }


            return name;

        }
        public List<Art> GetArt(int id)
        {
            List<Art> arts = new List<Art>();
            List<CollectorsGallery> ci = _context.CollectorsGalleries.Where(x => x.CollectorId == id).ToList();
            if (ci == null)
            {
                return arts;
            }
            foreach (CollectorsGallery c in ci)
            {
                Art art = _context.Arts.Where(x => x.Id == c.ArtId).FirstOrDefault();
                arts.Add(art);
            }
            return arts;

        }

        public List<Bid> GetBids(int id)
        {
            
            List<Bid> bids = _context.Bids.Where(c => c.CollectorId == id).ToList();
            List<Bid> hackBid = new List<Bid>();  
            foreach (Bid b in bids)
            {
                if (hackBid.Where(x => x.AuctionId == b.AuctionId).FirstOrDefault() == null)
                {
                    hackBid.Add(b);
                }
                if (hackBid.Where(x => x.AuctionId == b.AuctionId).FirstOrDefault().Amount < b.Amount)
                {
                    hackBid.Remove(hackBid.Where(x => x.AuctionId == b.AuctionId).FirstOrDefault());
                    hackBid.Add(b);
                }
            }
            return hackBid;
        }

        public DateTime GetClosing(int id) {
            return _context.Auctions.Where(z => z.Id == id).AsNoTracking().FirstOrDefault().ClosingDate;
        
        }
        public DateTime GetClosingForArt(int id)
        {
            return _context.Auctions.Where(z => z.ArtId==id).AsNoTracking().FirstOrDefault().ClosingDate;

        }
        public List<Art> GetAuctions()
        {
            List<Art> arts = new List<Art>();
            List<Auction> ci = _context.Auctions.Where(x => x.ClosingDate > DateTime.Now).ToList();
            if (ci == null)
            {
                return arts;
            }
            foreach (Auction c in ci)
            {
                Art art = _context.Arts.Where(x => x.Id == c.ArtId).FirstOrDefault();
                arts.Add(art);
            }
            return arts;

        }
        public int GetAuction(int id)
        {
            return _context.Auctions.Where(x => x.ArtId == id).FirstOrDefault().Id;
        }
        public Bid Save(Bid bd)
        {
            Bid tc = _context.Bids.Add(bd).Entity;
            _context.SaveChanges();
            Art art = _context.Arts.Where(x => x.Id == tc.ArtId).FirstOrDefault();
            if (art != null)
            {
                art.CurrentValue = bd.Amount;
                _context.SaveChanges();
            }
            return tc;
        }
        public List<Art> GetAuctions(int collector)
        {
            List<Art> arts = new List<Art>();
            List<Auction> ci = _context.Auctions.ToList();
            if (ci == null)
            {
                return arts;
            }
            List<Bid> bid = _context.Bids.Where(x => x.CollectorId == collector).ToList();
            foreach (Auction c in ci)
            {

                if (bid.Count>0 && arts.Where(x => x.Id == c.ArtId).FirstOrDefault() == null)
                {
                    Art art = _context.Arts.Where(x => x.Id == c.ArtId).FirstOrDefault();
                    arts.Add(art);
                }
            }
            return arts;

        }



        public Collector Save(Collector user)
        {
            Collector tc = _context.Collectors.Find(user.Id);
            if (tc == null)
            {
                tc = _context.Collectors.Add(user).Entity;
                _context.SaveChanges();

            }
            tc.Name = user.Name;
            tc.Location = user.Location;
            tc.Email = user.Email;
            _context.SaveChanges();
            return tc;
        }



    }
}
