using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure.Configurations
{
    class PatrolConfiguration : IEntityTypeConfiguration<Patrol>
    {
        public void Configure(EntityTypeBuilder<Patrol> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id)
                .IsUnique();

            builder.Property(x => x.Title)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(x=> x.Status)
                .IsRequired();

            builder.HasOne(e => e.Place)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
