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

        public bool Maintain() 
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
            return auctions.Count>0;
        }


    }
}
