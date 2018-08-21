using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public sealed class UserLogEntityTypeConfiguration : IEntityTypeConfiguration<UserLogModel>
    {
        public void Configure(EntityTypeBuilder<UserLogModel> builder)
        {
            builder.ToTable("UsersLogs", "User");

            builder.HasKey(x => x.UserLogId);

            builder.Property(x => x.Content).IsRequired(false).HasMaxLength(8000);
            builder.Property(x => x.DateTime).IsRequired();
            builder.Property(x => x.LogType).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserLogId).IsRequired().ValueGeneratedOnAdd();

            builder.HasOne(x => x.User).WithMany(x => x.UsersLogs).HasForeignKey(x => x.UserId);
        }
    }
}
