using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtModel;

namespace ArtDL
{
    public interface IArtistRepo
    {
        public List<Artist> GetAll();
        public Artist Save(Artist artist);
    }
}
