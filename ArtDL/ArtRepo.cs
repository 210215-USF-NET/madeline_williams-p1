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
    }
}
