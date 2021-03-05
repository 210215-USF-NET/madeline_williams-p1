using System;


namespace ArtModel
{
    public class Art : IArt
    {
        int id = 0;
        string name = "";
        string description = "";
        string artiststatement = "";
        decimal currentValue = 0.0M;
        public int Id
        {
            get
            {
                return id;
            }
            set { id = value; }
        }
        public string Location { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string ArtistCommentary { get { return artiststatement; } set { artiststatement = value; } }
        string Thumbnail { get; set; }
        Byte[] Fullart { get; set; }
        int MaxSeries { get; set; }
        public decimal CurrentValue { get { return currentValue; } set { currentValue = value; } }
        public override string ToString()
        {
            string s = $"Art:\nId={Id}\nname={Name}\ndescription={Description}\nartistv statement={ArtistCommentary}\ncurrent value={CurrentValue}\n";
            return s;
        }
    }
}