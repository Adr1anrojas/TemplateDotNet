using CleanArchitecture.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
                builder.ToTable("User");

                builder.HasKey(e => e.Id);

                builder.Property(e => e.BirthDay).HasColumnType("date");

                builder.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);
        }
    }
}
