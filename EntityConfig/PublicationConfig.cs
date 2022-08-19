using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using publication.Models;

namespace publication.EntityConfig;

public class PublicationConfig : IEntityTypeConfiguration<Publication>
{
    public void Configure(EntityTypeBuilder<Publication> builder)
    {
        builder.ToTable("tb_Publication");

        builder.HasKey(prop => prop.Id)
        .HasName("PK_Publication");

        builder.Property(prop => prop.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("int");

        builder.Property(prop => prop.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("longtext");
        
        builder.Property(prop => prop.Message)
            .IsRequired()
            .HasColumnName("Message")
            .HasColumnType("longtext");

        builder.Property(prop => prop.CreationDate)
            .IsRequired()
            .HasColumnName("CreationDate");
        
        builder.Property(prop => prop.MaxComments)
            .IsRequired()
            .HasColumnName("MaxCOmments")
            .HasColumnType("int");
    }
}