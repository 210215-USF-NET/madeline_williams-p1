using System;
using System.ComponentModel.DataAnnotations;

namespace ArtModel
{
    public class Collector : ICollector, IUser
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Location { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}