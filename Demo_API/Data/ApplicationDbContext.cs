using Demo_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 
        
        
            
        }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "Jack",
                    Address = "New york city",
                    Age = 25,
                    ImageUrl = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
                },
                 new Person
                 {
                     Id = 2,
                     Name = "Rose",
                     Address = "Las Vegas",
                     Age = 22,
                     ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fperson&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAE"
                 },
                  new Person
                  {
                      Id = 3,
                      Name = "Ron",
                      Address = "Madried",
                      Age = 28,
                      ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Funsplash.com%2Fs%2Fphotos%2Fprofile-image&psig=AOvVaw3zCQm5ilRKKKhIZfbIhuIt&ust=1697005510532000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCPiBkafs6oEDFQAAAAAdAAAAABAJ"
                  ,
                  },
                      new Person
                      {
                          Id = 4,
                          Name = "Batrisha",
                          Address = "sydney",
                          Age = 23,
                          ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRKouGaC5wkHjgKIuSSZTrTBBQWc5gEIOPFw&usqp=CAU"
                      }

                ) ;



        }
    }

    
}
