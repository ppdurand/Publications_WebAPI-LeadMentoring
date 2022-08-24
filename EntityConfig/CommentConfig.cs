using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using publication.Models;

namespace publication.EntityConfig;

public class CommentConfig : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("tb_Comment");

        builder.HasKey(com => com.CommentId)
            .HasName("PK_Comment");

        builder.Property(com => com.CommentId)
            .IsRequired()
            .HasColumnName("id")
            .HasColumnType("int");
        
        builder.Property(com => com.Menssage)
            .IsRequired()
            .HasColumnName("Message")
            .HasColumnType("varchar(200)");

        builder.Property(com => com.RegistrationDate)
            .IsRequired()
            .HasColumnName("RegistrationDate");

        builder.HasOne(com => com.Publication)
            .WithMany(pub => pub.Comments)
            .HasForeignKey(com => com.PublicationId);


    }
}