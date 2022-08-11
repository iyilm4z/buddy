using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buddy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EmailToRevalidate = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequireReLogin = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    CannotLoginUntilDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemAccount = table.Column<bool>(type: "bit", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    LastIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastActivityDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsSystemRole = table.Column<bool>(type: "bit", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EnablePasswordLifetime = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordFormatId = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPassword_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRecord_UserRole_Mapping",
                columns: table => new
                {
                    PermissionRecord_Id = table.Column<int>(type: "int", nullable: false),
                    UserRole_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRecord_UserRole_Mapping", x => new { x.PermissionRecord_Id, x.UserRole_Id });
                    table.ForeignKey(
                        name: "FK_PermissionRecord_UserRole_Mapping_PermissionRecord_PermissionRecord_Id",
                        column: x => x.PermissionRecord_Id,
                        principalTable: "PermissionRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRecord_UserRole_Mapping_UserRole_UserRole_Id",
                        column: x => x.UserRole_Id,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_UserRole_Mapping",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    UserRole_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserRole_Mapping", x => new { x.User_Id, x.UserRole_Id });
                    table.ForeignKey(
                        name: "FK_User_UserRole_Mapping_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserRole_Mapping_UserRole_UserRole_Id",
                        column: x => x.UserRole_Id,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRecord_UserRole_Mapping_UserRole_Id",
                table: "PermissionRecord_UserRole_Mapping",
                column: "UserRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRole_Mapping_UserRole_Id",
                table: "User_UserRole_Mapping",
                column: "UserRole_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassword_UserId",
                table: "UserPassword",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionRecord_UserRole_Mapping");

            migrationBuilder.DropTable(
                name: "User_UserRole_Mapping");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "PermissionRecord");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
