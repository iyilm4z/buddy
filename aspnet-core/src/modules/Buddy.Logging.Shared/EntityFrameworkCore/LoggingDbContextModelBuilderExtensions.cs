using Buddy.Logging.Domain;
using Buddy.Logging.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buddy.EntityFrameworkCore
{
    public static class LoggingDbContextModelBuilderExtensions
    {
        // ReSharper disable once UnusedTypeParameter
        public static void ConfigureLogging<TDbContext>(this ModelBuilder builder)
            where TDbContext : ILoggingDbContext
        {
            builder.Entity<Log>(b =>
            {
                b.ToTable(nameof(Log));
                b.HasKey(logItem => logItem.Id);

                b.Property(logItem => logItem.ShortMessage).IsRequired();
                b.Property(logItem => logItem.IpAddress).HasMaxLength(200);

                b.Ignore(logItem => logItem.LogLevel);

                //TODO
                //b.HasOne(logItem => logItem.User)
                //    .WithMany()
                //    .HasForeignKey(logItem => logItem.UserId)
                //    .OnDelete(DeleteBehavior.Cascade);
            });

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

                //TODO
                //b.HasOne(logItem => logItem.User)
                //    .WithMany()
                //    .HasForeignKey(logItem => logItem.UserId)
                //    .IsRequired();
            });

            builder.Entity<ActivityLogType>(b =>
            {
                b.ToTable(nameof(ActivityLogType));
                b.HasKey(logType => logType.Id);

                b.Property(logType => logType.SystemKeyword).HasMaxLength(100).IsRequired();
                b.Property(logType => logType.Name).HasMaxLength(200).IsRequired();
            });
        }
    }
}