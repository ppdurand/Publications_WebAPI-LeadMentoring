using Microsoft.EntityFrameworkCore;
using publication.EntityConfig;
using publication.Models;

namespace publication.Context;

public class PublicationContext : DbContext
{
    //Gerecia a conexãocom o banco de dados
    public PublicationContext(DbContextOptions<PublicationContext> options) : base(options){}

    //Relaciona 
    public DbSet<Publication>? Publication { get; set; }
    public DbSet<Comment>? Comment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Publication>(new PublicationConfig().Configure);
        modelBuilder.Entity<Comment>(new CommentConfig().Configure);
    }
}