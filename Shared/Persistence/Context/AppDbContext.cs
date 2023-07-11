using Microsoft.EntityFrameworkCore;
using Notes.API.Notes.Domain.Models;
using Notes.API.Shared.Extensions;

namespace Notes.API.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Note?> Notes { get; set; }
    
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Notes
        modelBuilder.Entity<Note>().ToTable("Notes");
        modelBuilder.Entity<Note>().HasKey(note => note.Id);
        modelBuilder.Entity<Note>().Property(note => note.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Note>().Property(note => note.Title);
        modelBuilder.Entity<Note>().Property(note => note.Description);
        modelBuilder.Entity<Note>().Property(note => note.Text);
        modelBuilder.Entity<Note>().Property(note => note.Date);
        
        
        modelBuilder.ConvertAllToSnakeCase();
    }
    
}