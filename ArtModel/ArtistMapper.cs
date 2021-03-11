using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.ArtModel
{
    public class ArtistMapper:IArtistmapper
    {

        public ArtistIndexVm cast2IndexVM(Artist artist)
        {
            return new ArtistIndexVm
            {
                Name = artist.Name,
                ArtistStatement = artist.ArtistStatement
                
            };
        }
    }
}
