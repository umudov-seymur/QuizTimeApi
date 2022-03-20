using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiztime.Core.Entities;

namespace QuizTime.Data.Configurations
{
    public class ResultAnswerConfiguration : IEntityTypeConfiguration<ResultAnswer>
    {
        public void Configure(EntityTypeBuilder<ResultAnswer> builder)
        {
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
