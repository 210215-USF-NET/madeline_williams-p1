using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtModel;
namespace cryptoart.ArtModel
{
    public class ArtMapper:IArtmapper
    {

        public ArtIndexVm cast2IndexVM(Art art)
        {
            return new ArtIndexVm
            {
                Name = art.Name,
                Thumbnail = art.Thumbnail
                
            };
        }
    }
}
