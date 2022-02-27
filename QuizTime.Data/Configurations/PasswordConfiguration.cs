using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiztime.Core.Entities;

namespace QuizTime.Data.Configurations
{
    public class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> builder)
        {
            builder.Property(q => q.Content)
               .HasMaxLength(16)
               .IsRequired();

            builder.HasIndex(x => x.Content)
                .IsUnique();

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
