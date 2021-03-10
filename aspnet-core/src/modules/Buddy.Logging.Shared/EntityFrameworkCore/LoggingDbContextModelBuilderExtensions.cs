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
                b.HasKey(logItem => logItem.Id);

                b.Property(logItem => logItem.ShortMessage).IsRequired();
                b.Property(logItem => logItem.IpAddress).HasMaxLength(200);

                b.Ignore(logItem => logItem.LogLevel);

                b.HasOne(logItem => logItem.User)
                    .WithMany()
                    .HasForeignKey(logItem => logItem.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void ConfigureActivityLogEntity(this ModelBuilder builder)
        {
            builder.Entity<ActivityLog>(b =>
            {
                b.ToTable(nameof(ActivityLog));
                b.HasKey(logItem => logItem.Id);

                b.Property(logItem => logItem.Comment).IsRequired();
                b.Property(logItem => logItem.IpAddress).HasMaxLength(200);
                b.Property(logItem => logItem.EntityName).HasMaxLength(400);

                b.HasOne(logItem => logItem.ActivityLogType)
                    .WithMany()
                    .HasForeignKey(logItem => logItem.ActivityLogTypeId)
                    .IsRequired();

                b.HasOne(logItem => logItem.User)
                    .WithMany()
                    .HasForeignKey(logItem => logItem.UserId)
                    .IsRequired();
            });
        }

        private static void ConfigureActivityLogTypeEntity(this ModelBuilder builder)
        {
            builder.Entity<ActivityLogType>(b =>
            {
                b.ToTable(nameof(ActivityLogType));
                b.HasKey(logType => logType.Id);

                b.Property(logType => logType.SystemKeyword).HasMaxLength(100).IsRequired();
                b.Property(logType => logType.Name).HasMaxLength(200).IsRequired();
            });
        }

        private static void ConfigureLogUserEntity<TUser, TLogUser>(this ModelBuilder builder)
            where TUser : Entity, IUser
            where TLogUser : Entity, IUser
        {
            builder.Entity<TLogUser>(b =>
            {
                b.ToTable(IUser.UserTableName);
                b.HasOne<TUser>().WithOne().HasForeignKey<TLogUser>(logUser => logUser.Id);
            });
        }
    }
}