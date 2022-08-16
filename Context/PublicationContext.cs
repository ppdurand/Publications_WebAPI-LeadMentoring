using Microsoft.EntityFrameworkCore;
using publication.Models;

namespace publication.Context;

public class PublicationContext : DbContext
{
    //Gerecia a conexãocom o banco de dados
    public PublicationContext(DbContextOptions<PublicationContext> options) : base(options){}

    //Relaciona 
    public DbSet<Publication>? Publication { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        var publication = modelBuilder.Entity<Publication>();    

    }
}