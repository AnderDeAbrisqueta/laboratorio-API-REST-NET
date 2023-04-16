using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Persistence.SQLServer.FluentConfig
{
    public class FluentBookEntityConfig : IEntityTypeConfiguration<Fluent_BookEntity>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookEntity> modelBuilder)
        {
            //BookEntity
            modelBuilder.HasKey(b => b.BookId);

            modelBuilder.Property(b => b.Title).IsRequired();

            modelBuilder.Property(b => b.PublishedOn).HasMaxLength(25);

            //One to many relation between Author and Books
            modelBuilder
                .HasOne(a => a.Fluent_Author)
                .WithMany(b => b.Fluent_Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
