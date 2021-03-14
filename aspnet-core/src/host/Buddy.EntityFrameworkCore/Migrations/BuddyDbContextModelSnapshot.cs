﻿// <auto-generated />
using System;
using Buddy.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Buddy.Migrations
{
    [DbContext(typeof(BuddyDbContext))]
    partial class BuddyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Buddy.Configuration.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("Buddy.Localization.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("FlagImageFileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LanguageCulture")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LimitedToTenants")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<bool>("Rtl")
                        .HasColumnType("bit");

                    b.Property<string>("UniqueSeoCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Buddy.Localization.Domain.Entities.LocaleStringResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ResourceValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LocaleStringResource");
                });

            modelBuilder.Entity("Buddy.Localization.Domain.Entities.LocalizedProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("LocaleKey")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("LocaleKeyGroup")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("LocaleValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LocalizedProperty");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityLogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityLogTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.ActivityLogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SystemKeyword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ActivityLogType");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("LogLevelId")
                        .HasColumnType("int");

                    b.Property<string>("PageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferrerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.LogUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Email");

                    b.Property<string>("Username")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Buddy.MultiTenancy.Domain.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DefaultLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Hosts")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("SecureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SslEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Buddy.MultiTenancy.Domain.Entities.TenantMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantMapping");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.PermissionRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("PermissionRecord");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.PermissionRecordUserRoleMapping", b =>
                {
                    b.Property<int>("PermissionRecordId")
                        .HasColumnType("int")
                        .HasColumnName("PermissionRecord_Id");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int")
                        .HasColumnName("UserRole_Id");

                    b.HasKey("PermissionRecordId", "UserRoleId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("PermissionRecord_UserRole_Mapping");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AdminComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CannotLoginUntilDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Email");

                    b.Property<string>("EmailToRevalidate")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<bool>("IsSystemAccount")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastActivityDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RequireReLogin")
                        .HasColumnType("bit");

                    b.Property<string>("SystemName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordFormatId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPassword");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("EnablePasswordLifetime")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemRole")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SystemName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserUserRoleMapping", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_Id");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int")
                        .HasColumnName("UserRole_Id");

                    b.HasKey("UserId", "UserRoleId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User_UserRole_Mapping");
                });

            modelBuilder.Entity("Buddy.Localization.Domain.Entities.LocaleStringResource", b =>
                {
                    b.HasOne("Buddy.Localization.Domain.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Buddy.Localization.Domain.Entities.LocalizedProperty", b =>
                {
                    b.HasOne("Buddy.Localization.Domain.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.ActivityLog", b =>
                {
                    b.HasOne("Buddy.Logging.Domain.Entities.ActivityLogType", "ActivityLogType")
                        .WithMany()
                        .HasForeignKey("ActivityLogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buddy.Logging.Domain.Entities.LogUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityLogType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.Log", b =>
                {
                    b.HasOne("Buddy.Logging.Domain.Entities.LogUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Buddy.Logging.Domain.Entities.LogUser", b =>
                {
                    b.HasOne("Buddy.Users.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Buddy.Logging.Domain.Entities.LogUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Buddy.MultiTenancy.Domain.Entities.TenantMapping", b =>
                {
                    b.HasOne("Buddy.MultiTenancy.Domain.Entities.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.PermissionRecordUserRoleMapping", b =>
                {
                    b.HasOne("Buddy.Users.Domain.Entities.PermissionRecord", "PermissionRecord")
                        .WithMany("PermissionRecordUserRoleMappings")
                        .HasForeignKey("PermissionRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buddy.Users.Domain.Entities.UserRole", "UserRole")
                        .WithMany("PermissionRecordUserRoleMappings")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionRecord");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserPassword", b =>
                {
                    b.HasOne("Buddy.Users.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserUserRoleMapping", b =>
                {
                    b.HasOne("Buddy.Users.Domain.Entities.User", "User")
                        .WithMany("UserUserRoleMappings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buddy.Users.Domain.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.PermissionRecord", b =>
                {
                    b.Navigation("PermissionRecordUserRoleMappings");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.User", b =>
                {
                    b.Navigation("UserUserRoleMappings");
                });

            modelBuilder.Entity("Buddy.Users.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("PermissionRecordUserRoleMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
