using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.Property(user => user.Title).IsRequired().HasMaxLength(50);

            builder.Property(user => user.Description).IsRequired().HasMaxLength(150);

            builder.Property(user => user.Price).IsRequired();

            builder.Property(user => user.Genre).IsRequired();
        }
    }
}
