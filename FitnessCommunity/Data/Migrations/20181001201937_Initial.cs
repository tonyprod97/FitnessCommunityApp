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
                values: new object[] { "2204dae4-6cb2-4dbd-aac8-972d486ed767", 0, "521cf4b3-505c-4700-af88-78bc8e4f8c7a", "ana.anic@gmail.com", false, "Ana", "Anic", false, null, 0, "ANA.ANIC@GMAIL.COM", "ANA.ANIC@GMAIL.COM", "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==", null, false, null, "2c1530ac-c46a-4649-990d-a131c5ccefb8", false, "ana.anic@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MeasureType", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicInfo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a5ee4b19-904d-4834-9faf-3074b29c6551", 0, "963235e5-4572-414b-a420-8d7580573fb7", "pero.peric@gmail.com", false, "Pero", "Peric", false, null, 0, "PERO.PERIC@GMAIL.COM", "PERO.PERIC@GMAIL.COM", "AQAAAAEAACcQAAAAELDDBjldTca23egUkVYyY+T1RPphJETIEqcDq142PV6dR2hy4Zbu0d7VHlmzZDVrOg==", null, false, null, "7e3db214-2c8b-4d5a-b472-e3a6e5f0e1cd", false, "pero.peric@gmail.com" });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "LogDate", "UserId", "WeightValue" },
                values: new object[,]
                {
                    { new Guid("2a6994c9-54fb-4cd9-956f-d9257b82f914"), new DateTime(2018, 10, 1, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 80f },
                    { new Guid("cc8ac79c-f879-4f2d-b9e8-ed3848de1124"), new DateTime(2018, 10, 8, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 87f },
                    { new Guid("4f7cef42-cb41-4fde-acb1-4f25007443b5"), new DateTime(2018, 10, 7, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 86f },
                    { new Guid("40d86e42-dca5-431a-adc9-fc5cf12814ed"), new DateTime(2018, 10, 6, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 85f },
                    { new Guid("fcefc728-1517-4c1d-9005-929a27146391"), new DateTime(2018, 10, 5, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 84f },
                    { new Guid("1ad55c84-e395-4e6f-a751-cbaeef7e9f74"), new DateTime(2018, 10, 4, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 83f },
                    { new Guid("1b62eabe-77c5-4d08-8f80-97175b404731"), new DateTime(2018, 10, 3, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 82f },
                    { new Guid("bb4718b3-39df-48dd-b90b-998e5c337df3"), new DateTime(2018, 10, 2, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 81f },
                    { new Guid("8c2a57f3-2556-4958-ae64-51633a8d85d0"), new DateTime(2018, 10, 1, 22, 19, 37, 558, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 80f },
                    { new Guid("4b7f5564-1bd9-4ce5-9735-d7350400a43c"), new DateTime(2018, 10, 10, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 89f },
                    { new Guid("ab38039b-e5a8-46e4-aa01-3a559d5714e4"), new DateTime(2018, 10, 9, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 88f },
                    { new Guid("d8aae1e1-0051-4440-9e3f-9756421dd0fa"), new DateTime(2018, 10, 8, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 87f },
                    { new Guid("0b32db60-31ff-43b8-8528-abc903edf4a6"), new DateTime(2018, 10, 7, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 86f },
                    { new Guid("cffc6503-53dd-44d5-b3c4-22e4471f7855"), new DateTime(2018, 10, 6, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 85f },
                    { new Guid("07889197-1780-477b-85aa-c773dc6bb6e1"), new DateTime(2018, 10, 5, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 84f },
                    { new Guid("caddad0a-644f-4b00-b0af-51f1680f74be"), new DateTime(2018, 10, 4, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 83f },
                    { new Guid("bf8aefc8-5113-40f8-bfc4-90c233dc7151"), new DateTime(2018, 10, 3, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 82f },
                    { new Guid("36173845-6235-4d04-a2a8-a2e516ea98f2"), new DateTime(2018, 10, 2, 22, 19, 37, 560, DateTimeKind.Local), "2204dae4-6cb2-4dbd-aac8-972d486ed767", 81f },
                    { new Guid("8561d89b-b3f0-40e3-a345-5a388f0896da"), new DateTime(2018, 10, 9, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 88f },
                    { new Guid("91998422-08d2-45c0-b7d6-e720c0bf0626"), new DateTime(2018, 10, 10, 22, 19, 37, 560, DateTimeKind.Local), "a5ee4b19-904d-4834-9faf-3074b29c6551", 89f }
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
