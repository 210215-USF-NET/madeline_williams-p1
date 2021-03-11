using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace ArtModel
{
   public class ArtIndexVm
    {
            //Data annotation
            //Can be used for display purposes, and also for validation
            [DisplayName("Name")]
            public string Name { get; set; }

            public string Thumbnail { get; set; }

        }
    }

