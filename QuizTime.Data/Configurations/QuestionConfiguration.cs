using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiztime.Core.Entities;

namespace QuizTime.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(u => u.IsVisited).HasDefaultValue(false);
            builder.Property(u => u.Order).HasDefaultValue(0);

            builder.Property(q => q.Content)
               .HasMaxLength(1000);

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
