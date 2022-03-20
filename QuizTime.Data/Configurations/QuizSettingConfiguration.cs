using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiztime.Core.Entities;

namespace QuizTime.Data.Configurations
{
    public class QuizSettingConfiguration : IEntityTypeConfiguration<QuizSetting>
    {
        public void Configure(EntityTypeBuilder<QuizSetting> builder)
        {
            builder.Property(u => u.IsShuffleQuestions).HasDefaultValue(false);
            builder.Property(u => u.IsShuffleAnswers).HasDefaultValue(false);
            builder.Property(u => u.IsActive).HasDefaultValue(true);

            builder.HasOne<Quiz>(q => q.Quiz)
                .WithOne(p => p.Setting)
                .HasForeignKey<QuizSetting>(q => q.QuizId);
        }
    }
}
