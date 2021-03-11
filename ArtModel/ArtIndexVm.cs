using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace ArtModel
{
   public class ArtistIndexVm
    {
            //Data annotation
            //Can be used for display purposes, and also for validation
            [DisplayName("Artist Name")]
            public string Name { get; set; }

            public int HP { get; set; }

            [DisplayName("Artist Statement")]
            public string ArtistStatement { get; set; }
        }
    }

