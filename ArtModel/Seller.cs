
using System.ComponentModel.DataAnnotations;
namespace ArtModel
{
    public class Seller : ISeller, IUser
    {
        private string _name = "";
        public int Id { get; set; }
        [Required]
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}