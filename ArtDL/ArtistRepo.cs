using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;
using Microsoft.EntityFrameworkCore;
namespace ArtDL
{
    public class ArtistRepo:IArtistRepo
    {
        private readonly ArtDBContext _context;

        public  ArtistRepo(ArtDBContext context)
        {
            _context = context;
        } 
       public List<Artist> GetAll() {

            return _context.Artists.AsNoTracking().ToList();
        }

        public Artist GetArtist(int id)
        {
           return _context.Artists.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public Artist GetArtist(string name)
        {
            return _context.Artists.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public List<Art> GetArt(int id)
        {
            return  _context.Arts.AsNoTracking().Where(x => x.ArtistId == id).ToList();
        }
        public List<Seller> GetSellers()
        {
            return _context.Sellers.AsNoTracking().ToList();
        }
        public string Owner(int id)
        {
            string name = "";
            SellerInventory si=_context.SellerInventories.Where(x => x.ArtId == id).FirstOrDefault();
            if (si != null)
            {
                name = _context.Sellers.Where(x=>x.Id==si.SellerId).FirstOrDefault().Name;
            }
            CollectorsGallery cg = _context.CollectorsGalleries.Where(x => x.ArtId == id).FirstOrDefault();
            if (cg != null)
            {
                name = _context.Collectors.Where(x => x.Id == cg.CollectorId).FirstOrDefault().Name;
            }


            return name;

        }
        public bool Attach(int aid,int sid)
        {
         //   try
         //   {
                SellerInventory si = new SellerInventory();
                si.ArtId = aid;
                si.SellerId = sid;
                _context.SellerInventories.Add(si);
                _context.SaveChanges();
                return true;
        /*    }
            catch
            {
                return false;
            }
        */
        }
        public bool InBid(int id)
        {
             
            return _context.Auctions.AsNoTracking().Where(q=>q.ClosingDate>DateTime.Now&&q.ArtId==id).FirstOrDefault()!=null;
        }

        public List<Seller> GetSellers(int id)
        {
            /*
            List<Seller> seller = new List<Seller>();
          foreach(SellerInventory si in _context.SellerInventories)
            {
                if (_context.Arts.Where(z => z.ArtistId == id).FirstOrDefault().Id == si.ArtId) { 
                seller.Add(_context.Sellers.Find(si.SellerId))
                }
             
            }
            
            return _context.Sellers.Include(x=>_context.SellerInventories.Where(y=>x.Id==y.SellerId).Include(z=>_context.Arts.Where(j=>j.ArtistId==id))).ToList();
            */
            return _context.Sellers.AsNoTracking().ToList();

        }
        public Artist Save(Artist artist)
        {
            Artist tc = _context.Artists.Find(artist.Id);
            if (tc == null)
            {
                tc = _context.Artists.Add(artist).Entity;
                _context.SaveChanges();

            }
            tc.Name = artist.Name;
            tc.ArtistStatement = artist.ArtistStatement;
            tc.Biography = artist.Biography;
            tc.Location = artist.Location;
            tc.ArtistPhoto = artist.ArtistPhoto;
            tc.Email = artist.Email;
            _context.SaveChanges();
            return tc;
        }

        public Art Save(Art art)
        {
            Art tc = _context.Arts.Find(art.Id);
            if (tc == null)
            {
                tc = _context.Arts.Add(art).Entity;
                _context.SaveChanges();

            }
            tc.Name = art.Name;
            tc.ArtistCommentary = art.ArtistCommentary;
            tc.Description = art.Description;
            tc.Thumbnail = art.Thumbnail;
            tc.Location = art.Location;
            tc.ArtistId = art.ArtistId;
            _context.SaveChanges();
            return tc;
        }


    }
}
