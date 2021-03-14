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

            return _context.Artists.ToList();
        }

        public Artist GetArtist(int id)
        {
           return _context.Artists.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public Artist GetArtist(string name)
        {
            return _context.Artists.AsNoTracking().Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
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
            _context.SaveChanges();
            return tc;
        }



    }
}
