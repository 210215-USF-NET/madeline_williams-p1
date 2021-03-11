using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.ArtModel
{
    public interface IArtistmapper
    {
        public ArtistIndexVm cast2IndexVM(Artist artist);

    }
}
