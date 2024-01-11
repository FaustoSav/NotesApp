using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Data.DBContext
{
    public class NotesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 LastName = "Potter",
                 Name = "Harry",
                 Email = "test@gmail.com",
                 UserName = "El chaboncito que sobrevivió",
                 Password = "123456",
                 Id = 1
             });



        //     public int TagId { get; set; }

     
        //public string Name { get; set; } = string.Empty;
      
        //public string Description { get; set; } = string.Empty
        //public string Color { get; set; } = "#333";

        //public bool State { get; set; } = true
        //public int UserId { get; set; }
        //public User? User { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        //public ICollection<Note> Notes { get; set; } = new List<Note>();
        modelBuilder.Entity<Tag>().HasData(
            new Tag
            {
                Name = "Default",
                Description = "Tag creada por default en el DbContext",
                CreatedAt = DateTime.Now,
                Color = "#90EE90",
                UserId = 1,
                TagId = 1
            }); ;
            modelBuilder.Entity<Tag>()
       .HasOne(t => t.User)
       .WithMany(u => u.Tags)
       .HasForeignKey(t => t.UserId)
       .OnDelete(DeleteBehavior.Cascade);  // Otra opción podría ser Restrict o SetNull según tus necesidades

            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .OnDelete(DeleteBehavior.Cascade);  // Otra opción podría ser Restrict o SetNull según tus necesidades

            modelBuilder.Entity<Note>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.Notes);


            base.OnModelCreating(modelBuilder);
        }


    }
}
