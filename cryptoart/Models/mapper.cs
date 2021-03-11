using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.Models
{
    public class mapper:Imapper
    {

        public ArtistIndexVm castIndexVM(Artist artist)
        {
            return new ArtistIndexVm
            {
                Name =artist.Name,
                ArtistStatement = artist.ArtistStatement
            };
        }
    }
}
