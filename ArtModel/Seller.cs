

namespace ArtModel
{
    public class Seller : ISeller
    {
        private string _name = "";
        public int Id { get; set; }
        public string name
        {
            get { return _name; }

            set { _name = value; }
        }
    }
}