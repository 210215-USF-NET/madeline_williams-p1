namespace ArtModel
{
    public interface ICollector
    {
        string Email { get; set; }
        int Id { get; set; }
        string Location { get; set; }
        string Name { get; set; }
    }
}