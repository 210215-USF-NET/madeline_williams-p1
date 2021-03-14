using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtModel
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
