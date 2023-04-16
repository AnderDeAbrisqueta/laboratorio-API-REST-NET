using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Persistence.SQLServer.FluentConfig
{
    public class FluentAthorEntityConfig : IEntityTypeConfiguration<Fluent_AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<Fluent_AuthorEntity> modelBuilder)
        {
            //AuthorEntity
            modelBuilder.HasKey(a => a.AuthorId);

            modelBuilder.Property(a => a.Name).IsRequired();

            modelBuilder.Property(a => a.LastName).IsRequired();

            modelBuilder.Property(a => a.Birth).HasMaxLength(25);
        }
    }
}
