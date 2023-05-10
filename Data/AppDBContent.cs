using LabWork.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabWork.Data
{
    public class AppDBContent : IdentityDbContext<User>
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        public DbSet<Game> Game { get; set; }
        public DbSet<DigitalCopy> DigitalCopy { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Game_has_genre> Game_has_genre { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<Developer_has_game> developer_has_game { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Publisher_has_game> publisher_has_game { get; set; }
        public DbSet<GameKey> gameKey { get; set; }
        public DbSet<OrderBasket> orderBasket { get; set; }
        public DbSet<UserOrder> userOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer_has_game>().HasKey(c => new {c.gameId, c.developerId});
            modelBuilder.Entity<Publisher_has_game>().HasKey(c => new {c.gameId, c.publisherId});
            modelBuilder.Entity<Game_has_genre>().HasKey(c => new {c.gameId, c.genreId});
            modelBuilder.Entity<OrderBasket>().HasKey(c => new {c.keyId, c.orderId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
