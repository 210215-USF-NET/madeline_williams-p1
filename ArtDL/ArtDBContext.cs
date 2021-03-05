using System;
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
        DbSet<Art> Arts { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<ArtistGallery> ArtistGalleries { get; set; }
        DbSet<Auction> Auctions { get; set; }
        DbSet<Bid> Bids { get; set; }
        DbSet<BlackList> BlackLists { get; set; }
        DbSet<Collector> Collectors { get; set; }
        DbSet<CollectorsGallery> CollectorsGalleries { get; set; }
        DbSet<Seller> Sellers { get; set; }
        DbSet<SellerInventory> SellerInventories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<SellerInventory>().HasNoKey().ToTable("SellerInventory");
            modelBuilder.Entity<BlackList>().HasNoKey().ToTable("BlackList");
            modelBuilder.Entity<CollectorsGallery>().HasNoKey().ToTable("CollectorsGallery");
            modelBuilder.Entity<ArtistGallery>().HasNoKey().ToTable("ArtistGallery");
        }
    }
}
