using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace services.Migrations
{
    public partial class db_inits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    DocumentName = table.Column<string>(nullable: true),
                    DocumentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    KeywordId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleCode = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    EmailConfirmation = table.Column<bool>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    DocumentId = table.Column<Guid>(nullable: true),
                    Product = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentProperties_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentKeywords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    DocumentId = table.Column<Guid>(nullable: true),
                    KeywordId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentKeywords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentKeywords_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentKeywords_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDel = table.Column<bool>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    RoleCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "Roles",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "CreatedBy", "CreatedOn", "DocumentName", "DocumentType", "IsDel", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 346, DateTimeKind.Local).AddTicks(8120), "Document A", "Promotion", null, null, null },
                    { new Guid("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8390), "Document B", "Promotion", null, null, null },
                    { new Guid("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8430), "Document C", "Promotion", null, null, null },
                    { new Guid("ae630703-cbd1-471d-907f-52b757b7eb0e"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8440), "Document D", "Promotion", null, null, null },
                    { new Guid("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8450), "Document E", "Promotion", null, null, null },
                    { new Guid("8ed5b22d-2610-4ca4-bba7-91183cc66511"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8450), "Document F", "Promotion", null, null, null },
                    { new Guid("876b6f77-dbea-452e-8638-d04000bd44b1"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8460), "Document G", "Promotion", null, null, null },
                    { new Guid("33b6ffc5-b4e1-4187-95cd-189d33857246"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8470), "Document H", "Promotion", null, null, null },
                    { new Guid("b6e27851-c365-4287-9c58-dea7ee86ee97"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8470), "Document I", "Promotion", null, null, null },
                    { new Guid("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 362, DateTimeKind.Local).AddTicks(8480), "Document K", "Promotion", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DocumentProperties",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DocumentId", "IsDel", "Product", "Supplier", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("4659156e-38d0-49b1-b641-cbe266ff7a2a"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(3060), new Guid("b8c4d3cc-9659-4a2a-8e00-798e3f491d08"), null, "Laptop", "Supplier A", null, null },
                    { new Guid("a26e92ea-0298-4223-82e2-56f947df0359"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4430), new Guid("529bdc1a-8e86-4cf3-bfae-1f6be13775f2"), null, "Monitor", "Supplier A", null, null },
                    { new Guid("a764fe17-34e0-4069-ba97-10e3e977a564"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4470), new Guid("882b9cfc-691d-4813-a2f0-78b3d3ec3cfe"), null, "Laptop", "Supplier B", null, null },
                    { new Guid("e9774ae8-0628-4b00-ab3f-89513c9fba27"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4480), new Guid("ae630703-cbd1-471d-907f-52b757b7eb0e"), null, "Monitor", "Supplier B", null, null },
                    { new Guid("a680fe69-d674-4fab-8c1b-db7c9690b147"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4490), new Guid("ea091284-55c7-4c0b-bf0d-ccc4498d41a9"), null, "Tablet", "Supplier A", null, null },
                    { new Guid("24e6d736-95f9-48d9-b803-012a6d8a3a7d"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4500), new Guid("8ed5b22d-2610-4ca4-bba7-91183cc66511"), null, "Laptop", "Supplier C", null, null },
                    { new Guid("4779e52a-88e5-404a-807b-327e2ed1cabb"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4510), new Guid("876b6f77-dbea-452e-8638-d04000bd44b1"), null, "Laptop", "Supplier A", null, null },
                    { new Guid("32a1fea7-140b-4713-8f77-11e675bafdf5"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4520), new Guid("33b6ffc5-b4e1-4187-95cd-189d33857246"), null, "Laptop", "Supplier B", null, null },
                    { new Guid("f1ab8560-9035-44f7-a5bf-ddf70e2f4928"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4530), new Guid("b6e27851-c365-4287-9c58-dea7ee86ee97"), null, "Laptop", "Supplier A", null, null },
                    { new Guid("a4b8455c-d510-462e-8b90-c50a73b6f6d8"), new Guid("3b51e708-f9ff-4e4e-95bf-535085707374"), new DateTime(2021, 11, 1, 1, 50, 53, 364, DateTimeKind.Local).AddTicks(4540), new Guid("2e7c54f2-f773-4e85-b4dd-b3f92f811a2b"), null, "Laptop", "Supplier C", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentKeywords_DocumentId",
                table: "DocumentKeywords",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentKeywords_KeywordId",
                table: "DocumentKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProperties_DocumentId",
                table: "DocumentProperties",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleCode",
                table: "UserRoles",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentKeywords");

            migrationBuilder.DropTable(
                name: "DocumentProperties");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
