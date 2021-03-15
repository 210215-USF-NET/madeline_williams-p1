namespace ArtModel
{
    public interface IArtist
    {
        string ArtistPhoto { get; set; }
        string ArtistStatement { get; set; }
        string Biography { get; set; }
        string CountryCode { get; set; }
        int Id { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        string Signature { get; set; }
        string Email { get; set; }

    }
}