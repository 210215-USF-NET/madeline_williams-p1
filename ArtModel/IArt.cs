namespace ArtModel
{
    public interface IArt
    {
        string ArtistCommentary { get; set; }
        decimal CurrentValue { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string Location { get; set; }
        string Name { get; set; }
    }
}