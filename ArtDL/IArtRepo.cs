using System.Collections.Generic;
using ArtModel;

namespace ArtDL
{
    public interface IArtRepo
    {
        public List<Art> GetAll();
        public bool Maintain();
    }
}