using System.Collections.Generic;
using ArtModel;
namespace cryptoart.ArtModel
{
    public interface IArtmapper
    {
        public ArtIndexVm cast2IndexVM(Art art);
    }
}