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
    }
}
