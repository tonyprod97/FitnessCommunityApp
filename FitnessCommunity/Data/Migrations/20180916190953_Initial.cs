using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessCommunity.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    MeasureType = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PublicInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LogDate = table.Column<DateTime>(nullable: false),
                    WeightValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MeasureType", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicInfo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2204dae4-6cb2-4dbd-aac8-972d486ed767", 0, "2b0716fa-51e0-432e-8a70-d76cc19fc153", "test@test.com", false, "Ana", "Anic", false, null, 0, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==", null, false, null, "0e1df3ba-3d31-4ad7-8ed8-382a2e8555b9", false, "test@test.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MeasureType", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicInfo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a5ee4b19-904d-4834-9faf-3074b29c6551", 0, "83999c03-0389-4815-bd53-2632090f67b4", "test1@test.com", false, "Pero", "Peric", false, null, 0, "TEST1@TEST.COM", "TEST1@TEST.COM", "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==", null, false, null, "68614e7e-9b05-42e8-a2db-1334c2abdcf1", false, "test1@test.com" });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "LogDate", "UserId", "WeightValue" },
                values: new object[,]
                {
                    { new Guid("1bd1b772-11c1-42d8-9d02-625506182c6f"), new DateTime(2018, 9, 16, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 80f },
                    { new Guid("ad60cded-2966-46b2-8e01-e43065cc8837"), new DateTime(2018, 9, 23, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 87f },
                    { new Guid("e38a64b5-3261-403a-a208-704ecc70fbb5"), new DateTime(2018, 9, 22, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 86f },
                    { new Guid("b1904418-b8fa-4615-a899-d43f7bfef2c1"), new DateTime(2018, 9, 21, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 85f },
                    { new Guid("953f6200-f2ef-4d2e-ae40-31e1ccb423c8"), new DateTime(2018, 9, 20, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 84f },
                    { new Guid("9eca5dab-1113-4179-b4ba-6477db9ac926"), new DateTime(2018, 9, 19, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 83f },
                    { new Guid("5b0cc703-7435-4c58-8e2b-e38ee2536855"), new DateTime(2018, 9, 18, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 82f },
                    { new Guid("86024fe0-d89b-4401-8e7f-f657ba14c386"), new DateTime(2018, 9, 17, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 81f },
                    { new Guid("f9c397fb-c94b-43ea-bbea-9d128b643cc9"), new DateTime(2018, 9, 16, 21, 9, 52, 221, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 80f },
                    { new Guid("eeaf5608-8203-4c07-a843-0d73c825653b"), new DateTime(2018, 9, 25, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 89f },
                    { new Guid("b215c365-c1ce-4b48-82bc-63339f046d30"), new DateTime(2018, 9, 24, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 88f },
                    { new Guid("e94a287f-5380-4011-bf47-5bb569347808"), new DateTime(2018, 9, 23, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 87f },
                    { new Guid("22684c6e-8890-4be9-825d-660fbfb82c4e"), new DateTime(2018, 9, 22, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 86f },
                    { new Guid("36a79431-3468-464f-bef1-df08bebd12cc"), new DateTime(2018, 9, 21, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 85f },
                    { new Guid("4872e588-d185-462f-a06a-fe0f2eb98291"), new DateTime(2018, 9, 20, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 84f },
                    { new Guid("b9d4df67-8c44-470d-8691-dd47391a25c4"), new DateTime(2018, 9, 19, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 83f },
                    { new Guid("8131aeeb-585c-4b2e-9758-9065038195e7"), new DateTime(2018, 9, 18, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 82f },
                    { new Guid("e0fec932-86e9-4ff5-b319-cd6eef1c245d"), new DateTime(2018, 9, 17, 21, 9, 52, 225, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 81f },
                    { new Guid("af2d02df-6629-4a71-8521-5174b12ccae3"), new DateTime(2018, 9, 24, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 88f },
                    { new Guid("e304ead4-2edd-4e98-a562-9cef8cb922c2"), new DateTime(2018, 9, 25, 21, 9, 52, 225, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 89f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
