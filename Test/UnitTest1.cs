using System;
using Xunit;
using ArtModel;
using ArtDL;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            Artist a = new Artist();
            a.Id = 2;
            Assert.Equal(2, a.Id);
        }
    }



    public class ArtDBTest
    {
        private readonly DbContextOptions<ArtDBContext> options;

        public ArtDBTest()
        {
            options = new DbContextOptionsBuilder<ArtDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }

        [Fact]
        public void GetAllArtReturnsAllArt()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtRepo _repo = new ArtRepo(context);
                var arts = _repo.GetAll();
                Assert.Equal(9, arts.Count);
            }
        }
        [Fact]
           public void GetNotifyTest()
           {
               using (var context = new ArtDBContext(options))
               {
                   IArtRepo _repo = new ArtRepo(context);
                var notifies = _repo.GetNotify("artist",1);

                   Assert.NotNull(notifies);
                   Assert.Equal("Congratulations! Your art A field of Broken Skies sold for 0.0", notifies[0]);
               }
           }
        [Fact]
        public void MaintainTest()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtRepo _repo = new ArtRepo(context);
                _repo.Maintain();
                var notifies = _repo.GetNotify("artist", 1);

                Assert.NotNull(notifies);
                Assert.Equal("Congratulations! Your art A field of Broken Skies sold for 0.0", notifies[0]);
            }
        }

        [Fact]
        public void GetArtByArtistTest()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                List<Art>arts=_repo.GetArt(1);
                Assert.Equal("Shatter", arts[0].Name);
            }
        }

        [Fact]
        public void GetArtByArtistNotExistTest()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                List<Art> arts = _repo.GetArt(188);
                Assert.Empty(arts);
            }
        }


        [Fact]
        public void GetArtistTest()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var artist = _repo.GetArtist("googoo");
                Assert.NotNull(artist);
            }
        }
        [Fact]
        public void GetArtistNotExistTest()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var artist = _repo.GetArtist("booboo");
                Assert.Null(artist);
            }
        }


        [Fact]
        public void GetArtNotinBid()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var inbid = _repo.InBid(1);
                Assert.False(inbid);
            }
        }

        [Fact]
        public void GetArtinBid()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var inbid = _repo.InBid(4);
                Assert.True(inbid);
            }
        }


        [Fact]
        public void GetOwner()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var owner = _repo.Owner(9);
                Assert.Equal("",owner);
            }
        }

        [Fact]
        public void GetOwnerNot()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var owner = _repo.Owner(6);
                Assert.Equal("Lucy", owner);
            }
        }

        [Fact]
        public void AttachTestReturnsTrue()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var success = _repo.Attach(8,1);
                Assert.True(success);
            }
        }

        [Fact]
        public void AttachTestAddsToCollection()
        {
            using (var context = new ArtDBContext(options))
            {
                IArtistRepo _repo = new ArtistRepo(context);
                var success = _repo.Attach(8, 1);
                var owner=_repo.Owner(8);
                Assert.Equal("whatta",owner);
            }
        }

        [Fact]
        public void GetArtByCollectorReturnsEmpty()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                List<Art> arts = _repo.GetArt(1);
                Assert.Empty(arts);
            }
        }
        [Fact]
        public void GetArtByCollectorReturnsData()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                List<Art> arts = _repo.GetArt(2);
                Assert.NotEmpty(arts);
            }
        }

        [Fact]
        public void GetBidsNotEmpty()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                var arts = _repo.GetBids(1);
                Assert.NotEmpty(arts);
            }
        }

        [Fact]
        public void GetBidsEmpty()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                var arts = _repo.GetBids(3);
                Assert.Empty(arts);
            }
        }
        [Fact]
        public void GetClosingForArtTrue()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                var arts = _repo.GetClosingForArt(4);
                bool timegreaterthannow = arts > DateTime.Now;
                Assert.True(timegreaterthannow);
            }
        }

        [Fact]
        public void GetAuctionsHaveCurrent()
        {
            using (var context = new ArtDBContext(options))
            {
                ICollectorRepo _repo = new CollectorRepo(context);
                var arts = _repo.GetAuctions();
                Assert.NotEmpty(arts);
            }
        }
        private void Seed()
        {
            using (var context = new ArtDBContext(options))
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Bids.AddRange(new Bid {Id=1,Amount=25.00m,ArtId=5,AuctionId=1,CollectorId=1,TimeOfBid= DateTime.Parse("2021-03-15 18:16:00") },new Bid { Id = 2, Amount = 23.00m, ArtId = 5, AuctionId = 1, CollectorId = 2, TimeOfBid = DateTime.Parse("2021-03-15 18:15:00") });
                context.CollectorsGalleries.Add(new CollectorsGallery {CollectorId=2,ArtId=6 });
                context.SellerInventories.AddRange(new SellerInventory { ArtId = 5, SellerId = 1 },new SellerInventory {SellerId=2 ,ArtId=2}, new SellerInventory {SellerId=2,ArtId=4},new SellerInventory {SellerId=1,ArtId=1 });
                context.Sellers.AddRange(new Seller { Id = 1, Name = "whatta", Email = "fleeumi@com.com" },new Seller {Id=2,Name="sherbert",Email="sher@a.com" });
                context.Collectors.AddRange(new Collector { Id = 2, Name = "Lucy", Location = "UK", Email = "fleey@hotmail.com" }, new Collector { Id = 3, Name = "Bufort", Location = "UK", Email = "zaz@hotmail.com" });
                context.Auctions.AddRange
                (
                    new Auction { Id = 1,ArtId=5,ClosingDate= DateTime.Parse("2021-03-15 18:17:00"),SellerId=1,MinimumBid=10.00m,Notify=0 },
                    new Auction { Id = 2, ArtId = 2, ClosingDate = DateTime.Parse("2021-03-15 18:17:00"), SellerId = 2, MinimumBid = 10.00m, Notify = 3 },
                    new Auction { Id = 3,ArtId = 4,ClosingDate = DateTime.Parse("2125-03-15 18:17:00"),SellerId = 2,MinimumBid = 10.00m,Notify = 0 });
                context.SaveChanges();
            }

        }

    }
}

