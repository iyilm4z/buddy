using Buddy.Domain.Entities;
using Buddy.Logging.Domain.Entities;
using Buddy.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public static class LoggingDbContextModelBuilderExtensions
    {
        // ReSharper disable once UnusedTypeParameter
        public static void ConfigureLogging<TDbContext, TUser>(this ModelBuilder builder) where TUser : Entity, IUser
            where TDbContext : ILoggingDbContext
        {
            builder.ConfigureLogEntity();
            builder.ConfigureActivityLogEntity();
            builder.ConfigureActivityLogTypeEntity();
            builder.ConfigureLogUserEntity<TUser, LogUser>();
        }

        private static void ConfigureLogEntity(this ModelBuilder builder)
        {
            builder.Entity<Log>(b =>
            {
                b.ToTable(nameof(Log));
                b.HasKey(log => log.Id);

                b.Property(log => log.ShortMessage).IsRequired();
                b.Property(log => log.IpAddress).HasMaxLength(200);

                b.Ignore(log => log.LogLevel);

                b.HasOne(log => log.User)
                    .WithMany()
                    .HasForeignKey(log => log.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureActivityLogEntity(this ModelBuilder builder)
        {
            builder.Entity<ActivityLog>(b =>
            {
                b.ToTable(nameof(ActivityLog));
                b.HasKey(activityLog => activityLog.Id);

                b.Property(activityLog => activityLog.Comment).IsRequired();
                b.Property(activityLog => activityLog.IpAddress).HasMaxLength(200);
                b.Property(activityLog => activityLog.EntityName).HasMaxLength(400);

                b.HasOne(activityLog => activityLog.ActivityLogType)
                    .WithMany()
                    .HasForeignKey(activityLog => activityLog.ActivityLogTypeId)
                    .IsRequired();

                b.HasOne(activityLog => activityLog.User)
                    .WithMany()
                    .HasForeignKey(activityLog => activityLog.UserId)
                    .IsRequired();
            });
        }

        private static void ConfigureActivityLogTypeEntity(this ModelBuilder builder)
        {
            builder.Entity<ActivityLogType>(b =>
            {
                b.ToTable(nameof(ActivityLogType));
                b.HasKey(activityLogType => activityLogType.Id);

                b.Property(activityLogType => activityLogType.SystemKeyword).HasMaxLength(100).IsRequired();
                b.Property(activityLogType => activityLogType.Name).HasMaxLength(200).IsRequired();
            });
        }

        private static void ConfigureLogUserEntity<TUser, TLogUser>(this ModelBuilder builder)
            where TUser : Entity, IUser
            where TLogUser : Entity, IUser
        {
            builder.Entity<TLogUser>(b =>
            {
                b.ToTable(IUser.UserTableName);

                b.Property(user => user.Username).HasMaxLength(1000).HasColumnName(nameof(IUser.Username));
                b.Property(user => user.Email).HasMaxLength(1000).HasColumnName(nameof(IUser.Email));

                b.HasOne<TUser>().WithOne().HasForeignKey<TLogUser>(logUser => logUser.Id);
            });
        }
    }
}