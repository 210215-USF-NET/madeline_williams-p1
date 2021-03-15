using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ArtModel;
namespace ArtDL
{
    public class ArtDBContext : DbContext
    {

        public ArtDBContext()
        {

        }

        public ArtDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistGallery> ArtistGalleries { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<CollectorsGallery> CollectorsGalleries { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerInventory> SellerInventories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellerInventory>().ToTable("SellerInventory").HasKey(x => new { x.ArtId, x.SellerId });

            modelBuilder.Entity<BlackList>().HasNoKey().ToTable("BlackList");
            modelBuilder.Entity<CollectorsGallery>().ToTable("CollectorsGallery").HasKey(x => new { x.ArtId,x.CollectorId });
            modelBuilder.Entity<ArtistGallery>().HasNoKey().ToTable("ArtistGallery");

            modelBuilder.Entity<Collector>().HasData(new Collector { Id=1,Name="BidBot",Location="US",Email="fleeyourmind@hotmail.com"});
            modelBuilder.Entity<Artist>().HasData(new Artist { Id = 1, Name = "Madeline Williams", Location = "US", Signature = "Madzy", ArtistStatement = "Art is but an illusion", Biography = "Trans artist located in seattle wa", ArtistPhoto = "" },
            new Artist { Id = 2, Name = "cranky pants johonson", Location = "US", Signature = "Cranky Pants", ArtistStatement = "I spit on your art", Biography = "found as a baby in a junkyard on the outskirts of arkansas, Cranky Pants formed their view of the world by making beauty from ugly surroundings.", ArtistPhoto = "" },
            new Artist
            {
                Id = 3,
                Name = "googoo",
                Location = "NZ",
                Signature = "Goo Goo",
                ArtistStatement = "...",
                Biography = "newborn artist googoo, smears her hand over canvas to produce expressive art peices",
                ArtistPhoto = ""
            },
                        new Artist
                        {
                            Id = 4,
                            Name = "Blue Heart",
                            Location = "US",
                            Signature = "Blue",
                            ArtistStatement = "We exist in the intersection between fields of reality and dreams, stare in awe the liminal space",
                            Biography = "Blue Heart has arted for 162 years, winner of the blue hearty grand prize 10 years in a row",
                            ArtistPhoto = ""
                        },
                       new Artist
                       {
                           Id = 5,
                           Name = "ludwig popper",
                           Location = "UK",
                           Signature = "LP",
                           ArtistStatement = "Simplicity is useful, complexity divine",
                           Biography = "I'm too modest to talk about my extraordinary life",
                           ArtistPhoto = ""
                       },
                       new Artist
                       {
                           Id = 6,
                           Name = "Mama Moomin",
                           Location = "IT",
                           Signature = "MMoo",
                           ArtistStatement = "Art is for hanging on your walls and should by pastoral",
                           Biography = "Mama Moomin is the proud mother of 13 cats and lives on a farm raising goats, which she uses as inpiration for her art",
                           ArtistPhoto = ""
                       });
            modelBuilder.Entity<Art>().HasData(
                new Art { Id = 1, Name = "The Exquisite Loss of Hearing", Location = "US", ArtistCommentary = "", Description = "digital art produced by transforming the waveform of ringing bells into an abstract painting", CurrentValue = 0.00m, MaxSeries = 1, Thumbnail = "", ArtistId = 3 },
                new Art { Id = 2, Name = "Scream, scream, cry", Location = "NZ", Description = "A child menaced by dark figures in the background, screams with laughter, a tear drops from her eye", ArtistCommentary = "a phsyical representation of my bipolar disorder", MaxSeries = 1, ArtistId = 4, Thumbnail = "" },
                new Art { Id = 3, Name = "Dookey", Location = "US", Description = "a peice of poo on a stick", ArtistCommentary = "all art is crap", MaxSeries = 1000, ArtistId = 2, Thumbnail = "" },
                new Art { Id = 4, Name = "Shatter", Location = "US", Description = "A photo of broken glass", ArtistCommentary = "shatter your conceptions", MaxSeries = 1, ArtistId = 1, Thumbnail = "" },
                new Art { Id = 5, Name = "A field of Broken Skies", Location = "IT", Description = "The world swirls with silver tears among a beautiful goat farm", ArtistCommentary = "Bah", MaxSeries = 1, ArtistId = 1, Thumbnail = "" },
                new Art { Id = 6, Name = "Scratchy Painting", Location = "UK", Description = "random scribbles on a canvas", ArtistCommentary = "all the beats are made of stars", MaxSeries = 1, ArtistId = 6, Thumbnail = "" },
                new Art { Id = 7, Name = "A large Lost Kraken", Location = "US", Description = "The Monster of the deep rises", ArtistCommentary = "Philosophical contemplation of the deep", MaxSeries = 1, ArtistId = 4 },
                new Art { Id = 8, Name = "Unfortunate Mayhem", Location = "US", Description = "Abstracted ant farm", ArtistCommentary = "we fall into the process driven by maddness", MaxSeries = 1, ArtistId = 1 },
                new Art { Id = 9, Name = "Dabble Doodle", Location = "UK", Description = "A scrawl of broken lines fluttering in and out of existence", ArtistCommentary = "there are no more tears left to spare", MaxSeries = 1, ArtistId = 2 });

            }
    }
}
