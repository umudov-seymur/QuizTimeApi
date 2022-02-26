﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiztime.Core.Entities;

namespace QuizTime.Data.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasOne(q => q.Password)
                .WithOne(p => p.Quiz)
                .HasForeignKey<Quiz>(q => q.PasswordId);

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
