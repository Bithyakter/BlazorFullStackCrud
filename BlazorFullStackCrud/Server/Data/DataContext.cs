
namespace BlazorFullStackCrud.Server.Data
{
   public class DataContext : DbContext
   {
      public DataContext(DbContextOptions<DataContext> options) : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Comic>().HasData(
            new Comic { Id = 1, Name = "Marvel" },
            new Comic { Id = 2, Name = "DC" }
         );

         modelBuilder.Entity<SuperHero>().HasData(
           new SuperHero
           {
              Id = 1,
              FirstName = "Bithy",
              LastName = "Akter",
              HeroName = "Spiderman",
              ComicId = 1
           },
           new SuperHero
           {
              Id = 2,
              FirstName = "Shammi",
              LastName = "Ahmed",
              HeroName = "Batman",
              ComicId = 2
           }
         );
      }

      public DbSet<SuperHero> superHeroes { get; set; }
      public DbSet<Comic> comics { get; set; }
   }
}