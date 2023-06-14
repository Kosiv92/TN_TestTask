using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure.Configurations
{
    class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
