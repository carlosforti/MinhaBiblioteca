using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BogusFaker.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Color = table.Column<string>(maxLength: 100, nullable: true),
                    Size = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Costumers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("0dea7b21-e744-4876-ba63-33f50fdf4194"), new DateTime(1968, 11, 21, 0, 23, 27, 22, DateTimeKind.Local).AddTicks(7154), "Dixie_Heller@yahoo.com", "Dixie", "Heller", "692-427-8594" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("a50617d0-d73d-460c-a70c-f9fcd6bfbca9"), new DateTime(1963, 12, 19, 9, 51, 4, 115, DateTimeKind.Local).AddTicks(5348), "Danny.Gleichner48@hotmail.com", "Danny", "Gleichner", "843-425-8076" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("33f0f501-3f65-44ac-8e46-52c3ab3e3021"), new DateTime(1970, 9, 30, 17, 10, 41, 870, DateTimeKind.Local).AddTicks(9175), "Kevin.Hauck92@hotmail.com", "Kevin", "Hauck", "262.313.4985" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("4d9060de-3161-479e-8876-161fc550270d"), new DateTime(1984, 12, 13, 23, 2, 43, 799, DateTimeKind.Local).AddTicks(2838), "Francis.Cole@hotmail.com", "Francis", "Cole", "1-339-462-1548" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3c698d7e-c868-40ac-ab4a-4f60b9996ab8"), new DateTime(1976, 11, 12, 5, 17, 9, 660, DateTimeKind.Local).AddTicks(1295), "Cassandra79@hotmail.com", "Cassandra", "Kunde", "(624) 397-9287 x9227" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("52e94354-6d87-4025-9fc2-009d04933b12"), new DateTime(1995, 5, 8, 0, 49, 2, 368, DateTimeKind.Local).AddTicks(2954), "Gilberto97@gmail.com", "Gilberto", "Volkman", "1-771-291-9493" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("d04f45fe-5b60-491c-acdb-2dbca8fdcd4d"), new DateTime(1994, 1, 1, 0, 36, 20, 879, DateTimeKind.Local).AddTicks(9926), "Francis.Ratke@yahoo.com", "Francis", "Ratke", "1-529-644-9443 x827" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("7d4ed6b5-d521-4416-8317-f045f4ed0e2c"), new DateTime(1973, 12, 4, 17, 2, 25, 645, DateTimeKind.Local).AddTicks(1574), "Thelma_Medhurst@yahoo.com", "Thelma", "Medhurst", "515.417.5610 x9714" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("bafbd84a-1d2e-4953-8b33-893c8dcfa279"), new DateTime(1969, 7, 24, 5, 26, 9, 837, DateTimeKind.Local).AddTicks(2050), "Tricia4@gmail.com", "Tricia", "Johnson", "763-271-5397 x385" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("83007617-a1ab-457b-a2cb-fbffdb12a069"), new DateTime(1967, 7, 4, 8, 39, 1, 827, DateTimeKind.Local).AddTicks(7456), "Daisy32@gmail.com", "Daisy", "Hodkiewicz", "(654) 240-6951 x1763" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("1be910ca-e40a-46ee-82f9-0dee65827a70"), new DateTime(1966, 2, 22, 19, 38, 47, 634, DateTimeKind.Local).AddTicks(1548), "Cecilia.Carter@yahoo.com", "Cecilia", "Carter", "648.457.3705 x765" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("923dd462-6734-4ad8-9f90-74f8a48f0421"), new DateTime(1961, 7, 17, 21, 20, 52, 837, DateTimeKind.Local).AddTicks(9849), "Marjorie.Ward@hotmail.com", "Marjorie", "Ward", "668-778-9454" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("8a809a97-8b76-4789-a88e-af8c2858713a"), new DateTime(1960, 9, 12, 22, 14, 22, 29, DateTimeKind.Local).AddTicks(9876), "Angelina.Renner13@yahoo.com", "Angelina", "Renner", "1-818-931-5430" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b41d96c0-d842-4ebe-8f8b-9eed05e4356e"), new DateTime(1992, 7, 28, 15, 31, 11, 48, DateTimeKind.Local).AddTicks(1992), "Juana.Hills2@yahoo.com", "Juana", "Hills", "274.744.6717" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("37a62f3d-4a44-49d5-ae9d-19d4674e4e29"), new DateTime(1999, 1, 23, 17, 10, 54, 817, DateTimeKind.Local).AddTicks(7102), "Lena.Koelpin59@hotmail.com", "Lena", "Koelpin", "819-549-1936 x474" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("623172de-eca8-4ba5-83a8-cedf7691b9d5"), new DateTime(1983, 9, 17, 0, 15, 44, 352, DateTimeKind.Local).AddTicks(4000), "Milton22@hotmail.com", "Milton", "Wehner", "483.271.5871 x14306" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("5d1b6548-1161-4a7b-9ef9-cd7ea5b327c2"), new DateTime(1999, 11, 3, 19, 31, 48, 632, DateTimeKind.Local).AddTicks(5121), "Belinda_Hoeger73@yahoo.com", "Belinda", "Hoeger", "1-589-701-1213" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2704f0d8-e3c6-49c2-9f42-e63a6daf4427"), new DateTime(1968, 1, 15, 21, 38, 58, 42, DateTimeKind.Local).AddTicks(5015), "Mary91@gmail.com", "Mary", "Murazik", "(748) 416-4941" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3967febd-ad3e-4c91-92a4-48cc8a85c5a1"), new DateTime(1951, 9, 17, 9, 38, 46, 35, DateTimeKind.Local).AddTicks(575), "Doris_Schultz5@gmail.com", "Doris", "Schultz", "(293) 902-1931 x9206" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("a8bed5f1-cf6c-4207-ae94-1afc6f20d4c2"), new DateTime(1953, 7, 16, 4, 43, 6, 945, DateTimeKind.Local).AddTicks(3817), "Alicia_Purdy12@gmail.com", "Alicia", "Purdy", "842-419-1846 x2894" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("cc3bd371-5b29-40bc-80b6-e4d101672c10"), new DateTime(1975, 4, 29, 11, 25, 11, 626, DateTimeKind.Local).AddTicks(6411), "Glenda_Watsica@hotmail.com", "Glenda", "Watsica", "1-998-633-8234 x544" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3b856624-993d-432c-966a-2efc5ca1929c"), new DateTime(1959, 7, 16, 16, 26, 33, 198, DateTimeKind.Local).AddTicks(3499), "Lana94@gmail.com", "Lana", "Dickens", "819.494.3043" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("7f617d9e-05c1-4feb-af8e-28be108ed9bb"), new DateTime(1951, 6, 11, 9, 3, 44, 939, DateTimeKind.Local).AddTicks(393), "Mona.Kovacek@hotmail.com", "Mona", "Kovacek", "400-364-0211" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("aeb5639e-1c34-48cf-9a99-9a15d4bc76f8"), new DateTime(1988, 1, 5, 7, 44, 54, 742, DateTimeKind.Local).AddTicks(1276), "Luis_Huels@hotmail.com", "Luis", "Huels", "602.338.4896 x261" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("402099d3-3727-4b14-b5ee-2a5dc5263e23"), new DateTime(1990, 10, 12, 19, 57, 10, 878, DateTimeKind.Local).AddTicks(6978), "Lynette.Dach40@gmail.com", "Lynette", "Dach", "742-393-8730" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2fd38a9a-c318-488f-bdc4-68e97be204a7"), new DateTime(1971, 6, 4, 4, 58, 22, 602, DateTimeKind.Local).AddTicks(3663), "Lillie.Ebert@gmail.com", "Lillie", "Ebert", "1-986-541-6482 x161" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("30ae4f65-4f90-47f8-8872-5102a51ba907"), new DateTime(1994, 3, 24, 2, 20, 29, 965, DateTimeKind.Local).AddTicks(7471), "Alex_Witting@gmail.com", "Alex", "Witting", "(603) 599-0264 x2770" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("45df531c-abb9-4dba-b5e5-f4d88f5ff4f6"), new DateTime(1986, 7, 27, 20, 29, 31, 200, DateTimeKind.Local).AddTicks(2910), "Wendy.Turcotte@yahoo.com", "Wendy", "Turcotte", "1-975-249-6923 x3026" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b473ae7b-c846-4c49-bd65-07f1fda023df"), new DateTime(1963, 4, 18, 14, 15, 56, 72, DateTimeKind.Local).AddTicks(8431), "Timmy_Nikolaus@gmail.com", "Timmy", "Nikolaus", "506-980-6658" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("5317f398-e2f5-43de-bf83-e1c57937cadd"), new DateTime(1991, 4, 30, 0, 32, 9, 780, DateTimeKind.Local).AddTicks(2423), "Carole21@hotmail.com", "Carole", "Mohr", "1-608-726-8860 x31467" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("a8e4dfc4-2df0-4394-a4dd-14162e243c57"), new DateTime(1974, 10, 15, 8, 6, 7, 816, DateTimeKind.Local).AddTicks(7026), "Lowell_Sawayn@hotmail.com", "Lowell", "Sawayn", "963.476.1461" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("fb492897-ddb4-4746-9577-134b3039990a"), new DateTime(1955, 9, 28, 9, 33, 57, 536, DateTimeKind.Local).AddTicks(4144), "Bryant.Gislason3@gmail.com", "Bryant", "Gislason", "534-802-0160 x4630" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3442f346-b170-44d4-bbe2-e209f27bc734"), new DateTime(1967, 12, 27, 2, 6, 58, 311, DateTimeKind.Local).AddTicks(8382), "Jonathan54@gmail.com", "Jonathan", "Casper", "1-809-598-3175 x2209" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("f40e9953-18e4-4cf0-9c72-b328c1f64ad7"), new DateTime(1991, 9, 5, 9, 22, 50, 789, DateTimeKind.Local).AddTicks(7423), "Glen_Kris@yahoo.com", "Glen", "Kris", "846.940.7687" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("1eb151bb-85f2-4205-b32a-2e9f6623d0c0"), new DateTime(1963, 9, 2, 7, 43, 9, 557, DateTimeKind.Local).AddTicks(8074), "Lillie27@gmail.com", "Lillie", "Luettgen", "1-469-330-6563 x6582" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("ca57b048-cd37-40ae-a054-5e262ca83da0"), new DateTime(1953, 6, 26, 18, 46, 53, 525, DateTimeKind.Local).AddTicks(2756), "Delia39@gmail.com", "Delia", "Robel", "(209) 489-5028" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("39841cfc-daa3-4fd7-ad76-3042e0a2de40"), new DateTime(1981, 1, 30, 3, 54, 8, 716, DateTimeKind.Local).AddTicks(926), "Dora40@hotmail.com", "Dora", "Hauck", "388-669-4706" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("262f0259-a784-4c86-a457-7fba1b771b09"), new DateTime(1981, 7, 31, 21, 48, 59, 481, DateTimeKind.Local).AddTicks(6211), "Pedro38@hotmail.com", "Pedro", "MacGyver", "1-560-819-0735 x4808" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("6a4f915b-1baf-45b5-8301-0190c9f3e6f1"), new DateTime(1954, 8, 14, 17, 58, 42, 409, DateTimeKind.Local).AddTicks(9783), "Enrique.Dietrich82@hotmail.com", "Enrique", "Dietrich", "(438) 575-6731 x13385" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("40dfe483-5d9a-4260-9a80-08facf318bb3"), new DateTime(1975, 2, 9, 4, 39, 40, 599, DateTimeKind.Local).AddTicks(8121), "Nellie88@yahoo.com", "Nellie", "Hettinger", "436.597.4809" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("e33dd3ee-920d-4e78-8788-3a9d04628889"), new DateTime(1989, 7, 24, 11, 45, 53, 471, DateTimeKind.Local).AddTicks(2818), "Erick.Abernathy@yahoo.com", "Erick", "Abernathy", "(238) 529-4897 x841" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("da12f501-27ac-4d5c-934f-80f0106d62d4"), new DateTime(1964, 8, 27, 12, 53, 18, 136, DateTimeKind.Local).AddTicks(1538), "Russell32@yahoo.com", "Russell", "Kautzer", "(698) 760-6342 x177" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("8556fb51-1d0c-4f26-9fbb-a90b8cdecb38"), new DateTime(1963, 1, 27, 13, 46, 11, 809, DateTimeKind.Local).AddTicks(4610), "Chris65@hotmail.com", "Chris", "Collier", "274-924-8046 x036" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b2a93cb6-84ba-4d57-9074-199b65a9e5c7"), new DateTime(1982, 2, 3, 2, 45, 11, 379, DateTimeKind.Local).AddTicks(2917), "Casey32@gmail.com", "Casey", "Rolfson", "866.684.1752 x3670" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2ba23c21-e2f6-42ad-9f0b-41662d5fe0d8"), new DateTime(1954, 10, 19, 17, 40, 37, 105, DateTimeKind.Local).AddTicks(6847), "Arturo_Krajcik35@yahoo.com", "Arturo", "Krajcik", "617-244-1467" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("aedc78dd-be3f-40b4-8d6d-656d78378d16"), new DateTime(1974, 4, 1, 4, 7, 5, 375, DateTimeKind.Local).AddTicks(9279), "Kathy.Hettinger91@hotmail.com", "Kathy", "Hettinger", "(396) 957-7731 x62228" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2baf2f5f-e180-4383-a771-41f6d0bc6732"), new DateTime(1976, 5, 18, 2, 52, 32, 391, DateTimeKind.Local).AddTicks(7952), "Melody_Leannon@gmail.com", "Melody", "Leannon", "660.534.5103" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("ba54c2ba-313f-4184-8282-751a1c1cb513"), new DateTime(1974, 12, 23, 20, 16, 57, 308, DateTimeKind.Local).AddTicks(5294), "Dallas20@hotmail.com", "Dallas", "Lang", "844-469-3131" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("6b8257f6-39d4-411b-8740-30d7c776fdf2"), new DateTime(1953, 11, 2, 19, 33, 45, 981, DateTimeKind.Local).AddTicks(5849), "Myrtle.Dietrich45@gmail.com", "Myrtle", "Dietrich", "(915) 312-1352 x391" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("ed401066-9bd7-40f4-b352-16828940fa32"), new DateTime(1978, 10, 5, 13, 32, 49, 822, DateTimeKind.Local).AddTicks(6824), "Amber65@yahoo.com", "Amber", "Bashirian", "868-237-6975" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("28a754b0-8d7e-4402-9c52-8d44341d4835"), new DateTime(1995, 6, 12, 0, 47, 43, 617, DateTimeKind.Local).AddTicks(949), "Hannah.Christiansen@gmail.com", "Hannah", "Christiansen", "638-281-2474" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("1125fcbb-7334-4bbd-98dc-3a782bfc0a47"), new DateTime(1972, 4, 19, 5, 55, 49, 84, DateTimeKind.Local).AddTicks(5884), "Mercedes51@hotmail.com", "Mercedes", "Ondricka", "(756) 751-2177 x687" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("642243d5-1f92-40f9-81a0-cad499c81a23"), new DateTime(1961, 1, 21, 1, 9, 27, 180, DateTimeKind.Local).AddTicks(1528), "Michele35@hotmail.com", "Michele", "Cronin", "238.211.5368 x817" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b549d9df-ca0e-4e57-890a-af5b7b7e777e"), new DateTime(1956, 1, 5, 6, 33, 34, 930, DateTimeKind.Local).AddTicks(6270), "Kevin.Friesen27@gmail.com", "Kevin", "Friesen", "839.907.8142 x2264" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("06bb59fb-66d3-411c-ad02-fe8e38401d92"), new DateTime(1984, 4, 7, 8, 13, 48, 575, DateTimeKind.Local).AddTicks(7293), "Kerry4@gmail.com", "Kerry", "Kshlerin", "622.689.2930 x72238" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("cbaaa2d6-149a-489b-819a-48aa3388d669"), new DateTime(1952, 4, 20, 12, 10, 6, 759, DateTimeKind.Local).AddTicks(4551), "Wendell.Boehm@hotmail.com", "Wendell", "Boehm", "771.651.2857 x316" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("9eb7031b-0020-4f07-9d20-1315c924e22e"), new DateTime(1958, 2, 22, 21, 4, 43, 264, DateTimeKind.Local).AddTicks(8966), "Belinda36@yahoo.com", "Belinda", "Rohan", "244-662-7917 x572" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2a0416cb-651b-4535-99c8-2bb5f588949d"), new DateTime(1952, 11, 27, 16, 25, 9, 673, DateTimeKind.Local).AddTicks(3497), "Nathaniel39@hotmail.com", "Nathaniel", "Bartoletti", "(814) 924-9129 x957" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("67969bef-745b-42ae-a8d7-ec91bc39943d"), new DateTime(1970, 12, 22, 12, 38, 30, 67, DateTimeKind.Local).AddTicks(9357), "Roger93@gmail.com", "Roger", "Spencer", "1-459-305-4424" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("7c8f2476-5e34-472d-9a6b-864b24ce5ab4"), new DateTime(1982, 4, 10, 23, 24, 30, 842, DateTimeKind.Local).AddTicks(1404), "Evan_Padberg@yahoo.com", "Evan", "Padberg", "1-483-279-0114 x240" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("e17fe276-63f7-4669-97ab-39b3fa8184be"), new DateTime(1958, 1, 14, 7, 27, 57, 618, DateTimeKind.Local).AddTicks(3705), "Erin.Langworth@hotmail.com", "Erin", "Langworth", "(300) 861-3731" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3650ea2b-5bb7-4dbf-86b6-9308e85338b9"), new DateTime(2000, 7, 15, 0, 24, 47, 863, DateTimeKind.Local).AddTicks(2789), "Christopher_Langworth29@gmail.com", "Christopher", "Langworth", "(752) 902-3819 x3016" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("6d147f46-6fab-4d11-8dc3-e5ef7604c092"), new DateTime(1994, 1, 8, 23, 2, 43, 781, DateTimeKind.Local).AddTicks(5779), "Johnathan_Purdy@hotmail.com", "Johnathan", "Purdy", "1-701-683-6084 x7050" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("70c93c18-8d31-4ce6-b413-8e50acc8bbb7"), new DateTime(1991, 10, 16, 21, 57, 53, 33, DateTimeKind.Local).AddTicks(7329), "Angelo_MacGyver33@gmail.com", "Angelo", "MacGyver", "(485) 949-9820 x2496" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("5e80eddf-18ac-40cb-ad0e-6c701f0c9f20"), new DateTime(1981, 9, 19, 19, 27, 1, 321, DateTimeKind.Local).AddTicks(3559), "Alison.Kshlerin@gmail.com", "Alison", "Kshlerin", "514.922.9176" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("154f3cc7-7e4f-4512-ba2b-2122edb8a150"), new DateTime(1961, 5, 2, 6, 28, 53, 688, DateTimeKind.Local).AddTicks(2846), "Clarence_Block52@gmail.com", "Clarence", "Block", "518-381-3176" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("e66c69eb-a8ae-4087-a944-bfc0fcea16b4"), new DateTime(1971, 3, 16, 2, 42, 42, 815, DateTimeKind.Local).AddTicks(1920), "Essie.Luettgen43@yahoo.com", "Essie", "Luettgen", "331.274.9712 x576" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("8bdcd7d8-a402-461c-b00b-88919040c1bd"), new DateTime(1956, 4, 13, 2, 13, 12, 29, DateTimeKind.Local).AddTicks(457), "Javier.Streich@hotmail.com", "Javier", "Streich", "1-315-790-5769 x88340" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("104c8050-e040-4993-a964-d2c66d4973b4"), new DateTime(1961, 6, 21, 17, 45, 55, 268, DateTimeKind.Local).AddTicks(9026), "Kellie_McGlynn@yahoo.com", "Kellie", "McGlynn", "362.629.4836 x5247" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("aeb2e527-c9c5-497b-bd64-aca7cb5c72d7"), new DateTime(1974, 9, 12, 13, 53, 41, 551, DateTimeKind.Local).AddTicks(8643), "Edward.McDermott28@gmail.com", "Edward", "McDermott", "788.777.8866 x3734" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("f6edf490-8163-42d4-b07c-aeb4f4309e07"), new DateTime(1984, 10, 23, 13, 59, 50, 654, DateTimeKind.Local).AddTicks(1583), "Robin.Wyman@hotmail.com", "Robin", "Wyman", "465-283-7235" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2554981a-f800-4686-b126-5ce5338d8790"), new DateTime(1966, 7, 24, 16, 13, 37, 430, DateTimeKind.Local).AddTicks(7220), "Vanessa.Deckow@hotmail.com", "Vanessa", "Deckow", "(304) 790-2227 x7171" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("a77e5c8b-c378-4f84-83c9-ea0a8b61fd62"), new DateTime(1971, 8, 10, 17, 21, 55, 639, DateTimeKind.Local).AddTicks(8108), "Harry.Schmeler@yahoo.com", "Harry", "Schmeler", "(878) 756-7751" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("0d9cf135-c81a-4209-8ec1-10cd7dd98ed6"), new DateTime(1954, 12, 4, 15, 34, 10, 870, DateTimeKind.Local).AddTicks(6800), "Nettie_Olson91@gmail.com", "Nettie", "Olson", "1-386-592-4850 x3331" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("746e13d3-6067-409f-b83c-74a2b86b6dab"), new DateTime(1951, 3, 19, 8, 43, 29, 189, DateTimeKind.Local).AddTicks(5096), "Emily_Emmerich98@hotmail.com", "Emily", "Emmerich", "735-527-8751 x689" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("da23e8da-7a96-4c76-861b-2daa6c18de43"), new DateTime(1956, 7, 22, 3, 1, 14, 83, DateTimeKind.Local).AddTicks(6108), "Ben_Bayer@hotmail.com", "Ben", "Bayer", "535-537-3364 x49258" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("77ab1d47-5973-491a-b24a-88934458e26e"), new DateTime(1973, 9, 14, 20, 28, 18, 501, DateTimeKind.Local).AddTicks(1105), "Marvin_Cronin@hotmail.com", "Marvin", "Cronin", "987-372-7440" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("ecb81626-fd3b-42f7-a7fe-896e0ad31612"), new DateTime(1994, 1, 27, 21, 19, 40, 666, DateTimeKind.Local).AddTicks(3002), "Bobbie96@hotmail.com", "Bobbie", "Monahan", "1-693-986-7950 x53007" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("dc39b9ea-83d2-4ab1-8d30-9dd2f9a2c9df"), new DateTime(1968, 5, 16, 6, 10, 24, 737, DateTimeKind.Local).AddTicks(7419), "Elena_Feil11@yahoo.com", "Elena", "Feil", "701.468.7613" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("004aca34-f18e-4efe-bdc3-da8cf436fb51"), new DateTime(1971, 5, 5, 9, 59, 26, 592, DateTimeKind.Local).AddTicks(9771), "Adrienne26@hotmail.com", "Adrienne", "Upton", "1-662-227-7554" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("feb2bbb0-4147-442f-b7a9-3c06376a9e46"), new DateTime(1970, 7, 13, 14, 23, 54, 596, DateTimeKind.Local).AddTicks(947), "Vivian56@hotmail.com", "Vivian", "Christiansen", "1-732-878-7036" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("65a8e5cd-d35c-41da-97c1-1c53aaf20c54"), new DateTime(1983, 11, 30, 1, 45, 17, 293, DateTimeKind.Local).AddTicks(9330), "Gilbert.Reichel84@hotmail.com", "Gilbert", "Reichel", "803-814-0271 x4049" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("c7619892-6274-44be-8ba3-b0ce90e6be71"), new DateTime(1982, 5, 31, 5, 29, 30, 290, DateTimeKind.Local).AddTicks(7199), "Johnny.Beer35@hotmail.com", "Johnny", "Beer", "(501) 405-5640 x3047" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("44391c77-dcfc-40fd-b045-887ca24c1ee7"), new DateTime(1954, 8, 2, 4, 52, 56, 801, DateTimeKind.Local).AddTicks(462), "Douglas_OHara90@yahoo.com", "Douglas", "O'Hara", "1-869-661-1132 x1613" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("dfa7cf8d-df0c-497b-a8a6-3c2196974f01"), new DateTime(1970, 6, 21, 1, 8, 18, 791, DateTimeKind.Local).AddTicks(7841), "Harold.Stanton@yahoo.com", "Harold", "Stanton", "1-555-569-1310" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("02fb85cd-a9a2-4a3b-a82d-f25b5ca08f1a"), new DateTime(1975, 11, 10, 5, 24, 57, 828, DateTimeKind.Local).AddTicks(359), "Jody_Corkery@gmail.com", "Jody", "Corkery", "(532) 358-6065" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("f74e84a0-c033-4331-83e2-98c224e079ba"), new DateTime(1996, 4, 26, 4, 47, 40, 179, DateTimeKind.Local).AddTicks(7335), "Wade46@gmail.com", "Wade", "Wiza", "492-785-3230 x926" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("11bba451-5ace-49d6-af75-2a557898d841"), new DateTime(1957, 7, 19, 12, 30, 54, 699, DateTimeKind.Local).AddTicks(5081), "Greg.Stokes@yahoo.com", "Greg", "Stokes", "(232) 273-1921" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("8357c940-3ae2-4e24-a59a-ca3fc707458a"), new DateTime(1979, 6, 14, 20, 44, 32, 733, DateTimeKind.Local).AddTicks(6677), "Sandra88@gmail.com", "Sandra", "Auer", "(932) 827-3927" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("d02fcd8b-9a6a-4b1d-b8bf-2de62427e982"), new DateTime(1955, 4, 4, 17, 50, 57, 781, DateTimeKind.Local).AddTicks(1833), "Kenneth.Spinka@gmail.com", "Kenneth", "Spinka", "(325) 328-2452 x78636" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("c048cb75-1eb3-4103-a2ce-7b00661d5483"), new DateTime(1994, 5, 30, 1, 49, 54, 756, DateTimeKind.Local).AddTicks(5317), "Jesus_Moore@hotmail.com", "Jesus", "Moore", "533-602-6921 x3424" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("f39bd2b6-22b1-44b5-bc1d-930a73124716"), new DateTime(1998, 3, 12, 3, 54, 30, 570, DateTimeKind.Local).AddTicks(5063), "Casey.Emmerich@gmail.com", "Casey", "Emmerich", "1-696-700-6989" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("a8023c44-258c-4abe-84cd-18b8368b77dd"), new DateTime(1981, 4, 25, 18, 21, 17, 586, DateTimeKind.Local).AddTicks(5289), "Luke85@hotmail.com", "Luke", "O'Conner", "(755) 327-1737" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("c22b0104-c4d3-4a07-ab13-c270bad31c44"), new DateTime(1995, 10, 5, 5, 3, 50, 532, DateTimeKind.Local).AddTicks(4074), "Miguel.Stracke@hotmail.com", "Miguel", "Stracke", "1-355-247-4645 x01633" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("b53de6a0-de4c-43ed-a428-624664933197"), new DateTime(1951, 1, 1, 0, 11, 29, 155, DateTimeKind.Local).AddTicks(8797), "Edith_Walter@gmail.com", "Edith", "Walter", "1-672-979-4578" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("29c6090f-7d3f-4184-80cb-b7a1e4b065c8"), new DateTime(1954, 4, 4, 3, 19, 3, 390, DateTimeKind.Local).AddTicks(7243), "Marvin49@yahoo.com", "Marvin", "Hane", "600-977-0233" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("ca232ed9-cdda-4a77-8472-78eb37703d17"), new DateTime(1966, 5, 9, 21, 15, 45, 736, DateTimeKind.Local).AddTicks(9310), "Carla.OReilly38@hotmail.com", "Carla", "O'Reilly", "432-488-5338 x888" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("529e22f8-7dc4-4fa7-9a45-1a8e7bc517a8"), new DateTime(1967, 12, 16, 19, 48, 59, 218, DateTimeKind.Local).AddTicks(5927), "Dominic66@yahoo.com", "Dominic", "Kilback", "937.398.0640" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("3d8ea39c-369e-49bc-b07e-62b3a10d694d"), new DateTime(1960, 12, 1, 15, 22, 51, 201, DateTimeKind.Local).AddTicks(3631), "Oscar8@yahoo.com", "Oscar", "Jacobi", "638.614.8813" });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { new Guid("2d7169a2-ef0f-4dd8-9afd-690e773fb163"), new DateTime(1966, 1, 7, 10, 17, 34, 618, DateTimeKind.Local).AddTicks(8777), "Lena_Jacobi@hotmail.com", "Lena", "Jacobi", "1-751-937-3256" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("419e73b4-c0d7-44f2-93a4-0e494d545816"), "salmon", "Intelligent Rubber Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3974139f-7ee9-4246-82f5-22ef427690be"), "red", "Unbranded Wooden Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ebfb0d0c-2fd6-4537-a911-c96400f6c7c2"), "maroon", "Handmade Granite Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9e7e5f43-79bf-4c28-8821-43c7d05cd2f5"), "magenta", "Practical Rubber Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bee0f94d-e241-4f81-8d34-086ebdfc1e2a"), "fuchsia", "Ergonomic Steel Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d39716fa-1b1c-413f-aef6-2196c05d6d44"), "purple", "Awesome Concrete Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4c3f33f2-42e4-46c8-933e-1e18de361e4a"), "plum", "Incredible Steel Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b523a93d-9636-477f-a902-6698f0911b4f"), "magenta", "Awesome Frozen Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b122d49c-6495-41f4-99e6-99b69ffd7056"), "olive", "Handmade Soft Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0aa703ad-8c38-42db-8dd1-de6ac8c829cb"), "magenta", "Fantastic Rubber Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("03f51841-c519-4b5b-8e66-b0da7f661ade"), "tan", "Practical Frozen Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9aba218b-178d-41fa-a685-7eba02dee06f"), "plum", "Unbranded Fresh Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a89d9ac4-7cf3-46dd-8de1-e15354802e73"), "blue", "Handcrafted Plastic Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5379ff22-4839-4992-bec8-c7a7ebaef99c"), "purple", "Licensed Cotton Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cfb5d01a-4a59-469b-ba1d-d871b7eca7e2"), "salmon", "Ergonomic Cotton Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2164a8d1-0fea-49ab-a3aa-358f4ed16bc3"), "purple", "Small Frozen Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6f8db3b1-aded-495f-82e7-3ba9a5ec10be"), "indigo", "Handmade Frozen Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7d841656-d0ac-4704-9a57-0b259cdfc51f"), "black", "Rustic Fresh Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3d35d8cc-ad26-453c-9675-37a6e9d9be2c"), "yellow", "Sleek Soft Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c92fee3d-4005-4ffe-8ad9-5ed4467d3bda"), "cyan", "Practical Rubber Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48abab6c-5426-43c0-a271-c692440cec8c"), "cyan", "Practical Fresh Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7b69a382-c669-42c0-b19b-f53386b4892b"), "cyan", "Handmade Granite Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("402b8f24-e055-4937-b075-50c7163d1bcb"), "mint green", "Practical Metal Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a931553b-4ae9-4b1c-a0b7-7c9a83a0a8d7"), "lavender", "Refined Metal Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2aed2196-65b9-4e06-b862-b3c3ff60473a"), "mint green", "Incredible Granite Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("24db66d3-c975-4be8-b98d-523e14f8a5df"), "salmon", "Refined Plastic Table", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bc939be8-cd13-4187-93d0-d40bfa719fff"), "black", "Practical Steel Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c25bcf44-24a1-4d03-b1b8-fb9cd38a1697"), "blue", "Handcrafted Cotton Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9ccd5957-a480-4cdf-a3b4-37174cf30ac5"), "orchid", "Tasty Frozen Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d78089d5-ebd4-4ce6-b14e-a9310860bcd6"), "yellow", "Refined Plastic Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("88e03398-6c37-4dcb-b36b-2c4ecaa92173"), "mint green", "Small Wooden Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a7346775-feea-4768-bf1a-db58df5ac45d"), "yellow", "Refined Steel Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a75e9245-7168-4adf-be67-5d7a1d7e7182"), "yellow", "Handmade Soft Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3bc61884-33bc-4e4f-8b76-d896a6da20e1"), "azure", "Practical Metal Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a70f7928-8d3f-4ece-bac1-7010f581bf5c"), "black", "Small Plastic Mouse", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("91d1784a-38c1-4b09-8e27-5df02b1ea17e"), "blue", "Handmade Cotton Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4393ab64-5bc5-4dd0-b8b1-adf7fe0fb320"), "ivory", "Rustic Granite Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0fd9ca2e-492f-4066-9443-6a7f226a4ccc"), "red", "Intelligent Soft Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c86ba9de-70fa-49cc-90a0-65a1520adac5"), "black", "Unbranded Rubber Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2447d261-5d5a-44da-9f10-c4d5381a1f61"), "orchid", "Fantastic Soft Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2b32f969-4d96-420d-aa83-e69052858a9d"), "mint green", "Licensed Granite Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4a368860-efca-44ae-a067-02957ea9c8da"), "magenta", "Fantastic Granite Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("019b417d-0530-4462-9d13-ac4291ab525f"), "azure", "Intelligent Metal Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("751e70ff-4f4d-42d4-b819-8d4c2edd2236"), "azure", "Intelligent Metal Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("742e10c8-ab6e-4101-a033-52b3bcf40fdc"), "gold", "Gorgeous Plastic Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac7e374d-cef5-42b1-b1d2-f80f26dbb1b0"), "tan", "Intelligent Granite Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("64a2daee-87d5-4eed-8e89-60fdf972bbd7"), "silver", "Fantastic Fresh Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("50e57aae-1569-4d5b-936c-8954c56b758d"), "sky blue", "Fantastic Plastic Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b8ffcc1e-a06a-4fb9-adbc-c9ceec29f123"), "maroon", "Handcrafted Metal Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("31a4d12c-b355-444e-a744-05fb22b98c79"), "black", "Intelligent Plastic Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0affaae6-a247-4628-800e-780fbf0ab64b"), "white", "Handcrafted Soft Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("639837e8-ce41-4ab6-8910-b69c13d5c0b3"), "gold", "Sleek Plastic Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3e4ffddf-20ad-4906-bb87-e11e8a1615c9"), "blue", "Tasty Metal Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1ceb39c8-c4c3-48f9-8434-d496c7eaec7b"), "sky blue", "Fantastic Concrete Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0bdae4ba-5e4f-4b2b-8489-ec0d772c873a"), "pink", "Unbranded Soft Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6fdabac-c177-4879-a1ef-77f6b261a763"), "plum", "Generic Wooden Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8e0c7146-b0bb-4508-95d3-974dfad6080b"), "yellow", "Unbranded Cotton Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0d119d2f-9327-4f15-a073-84178ca80196"), "turquoise", "Awesome Steel Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aa19e8fc-b638-4049-bd51-4a95e4f5dc47"), "yellow", "Tasty Steel Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8c574840-a773-426f-af11-aceecd9129f8"), "silver", "Handcrafted Rubber Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f1ea9e25-f16b-46f6-8712-92dcb506bab9"), "lime", "Generic Soft Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c8bb5fa-a218-4f78-9bbc-86cd1e7625ca"), "turquoise", "Small Granite Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f183cb6e-425a-4e4a-b2d1-5dba67321525"), "salmon", "Rustic Metal Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4e71ada6-8071-4edb-92ad-12f1d9a43afe"), "blue", "Handmade Plastic Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3a3d09c7-841e-4fc4-984c-6e844d793c3e"), "magenta", "Handmade Fresh Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("55411ecd-0a1d-4fba-a40f-e82c58604338"), "purple", "Intelligent Soft Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a2803884-ede6-4d24-9b26-aacbfcde3b9a"), "orchid", "Small Metal Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("735c6a9b-2f92-4332-acc7-d9683f920808"), "turquoise", "Intelligent Steel Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d466027a-1b6f-46a9-848e-bffe70cdbd3b"), "yellow", "Incredible Fresh Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1ffc02a7-23aa-4962-afce-babe27bde713"), "indigo", "Practical Soft Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6b2b344c-769b-408b-b299-5c249347da9b"), "cyan", "Handcrafted Cotton Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ad50bf35-0db4-44fb-8300-f7292dfc6f76"), "teal", "Fantastic Frozen Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b0014e59-15dd-4614-ab96-bd0bd1789780"), "green", "Ergonomic Granite Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("506936b5-9303-48cb-b813-b3a0c994b943"), "olive", "Sleek Plastic Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9de969c5-b7ee-4ec9-952e-4fc5b02e93fd"), "ivory", "Handcrafted Plastic Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6e0a2124-d5d9-4808-b2b7-cf8b59a24e99"), "orchid", "Refined Steel Gloves", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4878d1d8-41f7-4397-ac49-c31443837328"), "purple", "Practical Fresh Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fcca5897-fbba-4075-8d7e-b693f31c38db"), "olive", "Refined Rubber Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("10f3a479-2df3-46c3-9934-9a1348c2895d"), "white", "Gorgeous Steel Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("861299ec-3c91-465e-968e-b828f56e8e71"), "fuchsia", "Licensed Soft Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("534a056b-3f00-4d5f-8df7-aa3ec5813e8e"), "maroon", "Ergonomic Metal Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("24f5746d-8664-4002-a769-e797c743902b"), "lavender", "Fantastic Concrete Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6b7e0ec1-f94d-4a0b-a91e-2357bac58b8f"), "mint green", "Incredible Rubber Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("380d2f3d-58aa-43da-b7b0-ffb4139b0e59"), "magenta", "Intelligent Steel Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5803cd78-3592-474b-897e-a4f38312fdd5"), "yellow", "Handmade Fresh Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e3b168a0-8a7b-49d6-b8a9-be92498fe1b2"), "sky blue", "Generic Granite Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("23e5353e-3119-466d-8d18-2ad3f319ab03"), "blue", "Rustic Plastic Table", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fad9ee97-2476-4d97-b64f-943374201af3"), "gold", "Licensed Rubber Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3130301e-5bf6-444e-9be8-643e618c40e9"), "olive", "Fantastic Metal Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("47b2f48b-8f1a-42d7-a9e2-c6cceaea00ea"), "blue", "Refined Soft Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b44c8124-dbc3-48df-822d-828c1dfde6b3"), "orchid", "Intelligent Plastic Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9acbe2cd-a3d9-4b11-b1e8-1cf8fbeb8cb1"), "teal", "Small Steel Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67c167cd-30a6-44e3-9f3f-0051f054cb36"), "maroon", "Ergonomic Granite Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9b88a433-c5a7-4090-b491-87f489b9c69f"), "black", "Handmade Fresh Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("360b232c-93e6-4399-babd-cbf89d815476"), "grey", "Intelligent Frozen Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dac256fa-00ff-48df-869f-323c5b9e8a31"), "orange", "Fantastic Plastic Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cafbdd2f-e45b-4004-8683-5a9d59809773"), "azure", "Handmade Granite Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("322a90ab-b483-4d1c-82d7-eea21853437a"), "orange", "Gorgeous Fresh Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d7dd70f6-389e-439e-a38d-341e1d26f913"), "salmon", "Gorgeous Soft Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("60ce4ca2-b3d9-4fc9-932e-e2d9e04ab2c4"), "black", "Unbranded Plastic Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("51fa5503-60f3-408d-9227-0308693a86c6"), "ivory", "Unbranded Wooden Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5cc3f44c-6322-4c7e-a56f-5ed4f9dd6bf7"), "purple", "Handcrafted Rubber Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2351f844-0111-4944-a5f1-55b7a1c1d8a0"), "white", "Sleek Rubber Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bf449f50-d455-43ba-9e39-7859fe377093"), "lime", "Awesome Granite Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3e62a3fd-2d6c-4eca-a5fc-8de4883a0eb6"), "tan", "Refined Fresh Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("79372edc-9f03-4e75-89a0-2e79d8a9c1a4"), "fuchsia", "Fantastic Soft Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48959283-1c4b-4fdf-8e4d-b0d32c4f316c"), "white", "Refined Steel Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a0e1fef5-9be8-4a7b-adf9-dad46ac25945"), "mint green", "Ergonomic Cotton Mouse", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("84c299fd-9b56-4725-811f-fef919c9c5b4"), "green", "Generic Cotton Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c282a21e-2fb2-4d72-9fbe-5496719e33e5"), "magenta", "Generic Cotton Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5ffcfad6-06be-40bf-a1cb-4588945a8fc7"), "tan", "Fantastic Cotton Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("503256a8-870a-4afa-9b0a-39effddafab8"), "olive", "Small Rubber Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("74f27487-eb02-4176-9e60-04171afe9fcc"), "teal", "Tasty Wooden Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bc247d62-2086-4201-9412-ae8ae233b891"), "purple", "Ergonomic Granite Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("84c9aa5f-50d5-431f-b3e3-7c14e9757494"), "olive", "Handmade Plastic Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2c208ca9-8441-40b0-a814-ec2b1354f0d3"), "white", "Sleek Steel Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48cb3e6b-7aed-44b5-962a-133fda856492"), "cyan", "Tasty Metal Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2b1b809a-010a-4ca9-a1d2-755972bf2aa1"), "azure", "Handcrafted Concrete Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bd242ce2-8063-4ced-8053-1dce0dc3551a"), "black", "Small Rubber Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("32f97466-5f3a-479b-8820-f46f9ffce45a"), "azure", "Sleek Soft Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bcfa56b3-9d7f-48e9-a0c7-3982cde494d2"), "grey", "Rustic Concrete Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8dd148d5-236a-46df-b380-622d603d5087"), "cyan", "Awesome Soft Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e5b0a3be-e8bf-403b-bf66-220b96ccb9a1"), "maroon", "Ergonomic Metal Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f4e239bd-dd61-4038-aeab-64ac1f7adbaa"), "gold", "Tasty Frozen Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("98577cea-6f01-4ba4-8f2a-01e62c02988e"), "mint green", "Generic Rubber Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f5486b8e-a2f3-4bba-b34f-f8f5cbbbb0aa"), "silver", "Awesome Cotton Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5c02c062-0d6c-4eac-aaff-01f96fd49d8d"), "blue", "Generic Metal Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5a7b347c-0539-424f-bdf2-087aa464481c"), "salmon", "Intelligent Frozen Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b866ab2e-3f34-4d86-80ec-db35fbbd49e7"), "red", "Licensed Cotton Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e0753c28-afe1-43fa-a117-f3786b01dd83"), "silver", "Handmade Metal Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3d195d99-2f81-4be2-9b4a-cdd55b2f78c5"), "plum", "Tasty Granite Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec0317b8-513c-446c-bd91-b0a9cc62605d"), "red", "Intelligent Plastic Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0b316443-dbe3-4201-9d14-a6fae1a9effd"), "green", "Gorgeous Rubber Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4cd1e0b1-0bf9-4464-b41e-83f59703a3db"), "grey", "Intelligent Plastic Table", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e9a39049-6e15-4f4b-b8fb-bd678a2ef9eb"), "teal", "Incredible Frozen Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e9048cba-3eb6-4fa3-9939-cf8762faf4ca"), "lavender", "Intelligent Plastic Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("448c83f6-fe18-4ce8-a1fb-1fad01cce789"), "sky blue", "Unbranded Granite Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("82ba1aca-a15f-475e-8dca-17de8bdf36d9"), "olive", "Rustic Fresh Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dc1449f5-bbcc-4661-b1dd-8c939c555b1a"), "sky blue", "Refined Wooden Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("038b5fe8-2c24-4062-aed5-242e5319d623"), "black", "Gorgeous Rubber Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e756d30a-bdf2-4c0a-9a82-aa003e7e1c0f"), "yellow", "Fantastic Concrete Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cc7c54a3-e3f6-4fc0-bfef-0e8624a5a5fd"), "azure", "Tasty Wooden Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dfb303a9-fd79-41b9-b197-9e3cf8047009"), "violet", "Refined Concrete Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ad210194-187e-4859-9fed-cb2e2f0ae999"), "violet", "Licensed Frozen Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b2cf4da3-06fc-45af-b86c-11211f70d8fa"), "maroon", "Incredible Steel Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d73631c9-2fed-4dc3-8a70-7e1379f76934"), "orange", "Intelligent Concrete Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3092eab3-8203-4ed3-841e-4e9b8980678f"), "tan", "Handcrafted Plastic Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("498d2b93-d182-4cce-a7b8-9bb0faa0f6c9"), "grey", "Handmade Steel Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("246d6e7d-d41a-423f-a6ea-48b1efc644f1"), "turquoise", "Tasty Plastic Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c408990-d57f-4fc0-84f2-b9fc664c083b"), "violet", "Generic Plastic Gloves", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c5f2a674-160a-4b0f-b2a9-d65202a5bca0"), "olive", "Gorgeous Concrete Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a89d2b21-4b9d-428e-9ebd-1288284b79b6"), "blue", "Incredible Cotton Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f23adf05-d267-45a1-ba59-397f0a959097"), "salmon", "Generic Cotton Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ff5309b7-cbf1-494a-9d9b-66eb3b70936c"), "turquoise", "Handmade Cotton Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dfb4d1b9-4780-4adf-93d5-05eab55c360a"), "maroon", "Gorgeous Soft Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cf9756e1-44e0-4ba1-b321-fbf75b2615a0"), "orchid", "Generic Wooden Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b7190af4-88de-4744-9ba6-2748180fc417"), "pink", "Small Granite Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b59798c0-4a5a-47da-93c3-7134f69b4b5a"), "plum", "Licensed Granite Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9641da29-feb7-4eb7-be01-189fc91977d3"), "teal", "Rustic Cotton Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("00e773d4-0c10-40f6-89cf-c1d40a2c2672"), "magenta", "Ergonomic Frozen Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("31afd1eb-a853-495e-af03-d84a358f2d56"), "orange", "Handmade Plastic Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("71641b5e-a4cd-4900-88ce-bd54895030dc"), "ivory", "Licensed Wooden Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dbe4da17-7f4b-4b9f-9d47-7f39b51db5c2"), "azure", "Unbranded Fresh Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac88ad45-5c4c-4522-881d-b5e712164aee"), "violet", "Fantastic Rubber Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("81a1370f-4ccf-467a-9b08-6486ebfb21f1"), "black", "Generic Fresh Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d596b10e-b961-4c1f-9f02-2242bcd56451"), "purple", "Awesome Cotton Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("42274c7e-f63d-41c0-b5ef-4d49d3e33f56"), "lavender", "Practical Concrete Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7a6442c3-06eb-473d-989f-cf25797cd211"), "turquoise", "Handmade Soft Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9cdfd38a-fff4-40b6-8fee-8ebd718c3fd0"), "ivory", "Handcrafted Soft Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("318a568c-e89b-484a-9515-2acdd32d86ae"), "ivory", "Incredible Fresh Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f5879d45-ecb2-472f-9436-7d897b99f9df"), "salmon", "Awesome Cotton Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7a281b45-0e5d-4a50-bfb3-c289b7074c57"), "olive", "Refined Steel Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e000725b-c437-4a4e-9b9d-fefa547c6d0c"), "azure", "Fantastic Soft Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9596afdb-50f6-4202-8af3-4ec0f3029ecf"), "orange", "Handcrafted Plastic Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("057e5303-a391-435e-b551-6f47dd852d4f"), "teal", "Generic Fresh Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c731712-5e1c-42a2-a89b-ad8ebda8e145"), "blue", "Licensed Concrete Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("125f82a6-fb63-40b9-8a08-af1cc719ef89"), "ivory", "Handmade Soft Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f494ebd4-24cf-42fe-bee1-9aeac01a917c"), "yellow", "Small Fresh Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a68483a6-7357-4399-910d-915695610921"), "purple", "Handcrafted Plastic Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("19decf76-acba-4351-9cae-6410bbb71405"), "grey", "Tasty Concrete Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2012040e-81cf-4d0e-9142-371711537964"), "green", "Small Wooden Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("202293b5-6e54-4c96-a9dc-71b2a1f81b2b"), "yellow", "Handmade Cotton Mouse", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("93fddb1f-f183-45c1-aa34-e72f520fd4ec"), "orange", "Generic Granite Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("074d4f83-a184-48e6-b887-4f4a3a41f95b"), "tan", "Refined Concrete Hat", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cfbc75ce-8c8e-4d44-84bb-4d9d3d4117ae"), "black", "Awesome Plastic Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b41a0686-be45-49d4-80ca-f4fc94e6e40b"), "gold", "Handmade Granite Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("044e4744-44f4-4d3d-ba8b-1481e9b5b2ab"), "orange", "Tasty Metal Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d5283a68-f05e-4626-a927-39eac5f7d8bd"), "magenta", "Rustic Rubber Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ae3ffe61-be94-4242-b5af-43492511213d"), "turquoise", "Unbranded Wooden Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a804b906-81b9-4c93-b246-86c8d943e5df"), "olive", "Practical Fresh Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("932b1e1b-d01f-41e8-b697-b4072174d6a5"), "teal", "Awesome Plastic Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("700bfe63-a686-43de-8348-954a2e559202"), "green", "Rustic Soft Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6ffb2445-4064-48df-856e-437adf6f35db"), "purple", "Fantastic Plastic Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1d3bc169-e8ca-45ed-8c93-fe24d83c94a5"), "orange", "Small Frozen Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("782ebf85-3046-4ecc-800e-f6efbf4d8b81"), "ivory", "Intelligent Plastic Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("145fd628-5612-4bf3-9b24-1705650f373e"), "silver", "Fantastic Rubber Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8e07bbad-7718-4f1e-8458-99223d110ad9"), "orchid", "Incredible Metal Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6d7c867d-0c62-48fd-b907-184c3f20bd76"), "red", "Intelligent Fresh Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7e08abcd-c13e-4f12-8af3-9474fed2e8fe"), "maroon", "Incredible Concrete Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0d863daa-d5e1-4c63-a319-99d7352610d6"), "mint green", "Awesome Steel Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("04f6514c-5f66-43d2-b1a3-c45e5f9d99e1"), "turquoise", "Sleek Granite Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0176f6ab-c457-4333-92a8-f61ee410688e"), "green", "Rustic Concrete Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7fbf6dab-d571-4972-a97c-3b0814708cdc"), "magenta", "Awesome Plastic Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("511229db-b9bc-4e5b-b942-abf1157bc52a"), "salmon", "Generic Concrete Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("45127358-5225-4324-b63f-5dd4ed4c5a35"), "turquoise", "Intelligent Cotton Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("25f00037-9043-44c2-af31-aee3a4ed0590"), "white", "Tasty Metal Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("73c9403b-0dc9-4189-a5b8-d2c5d4bce1fb"), "lime", "Fantastic Soft Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a98f3be3-3779-453a-8158-c4469b9fc109"), "grey", "Refined Steel Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7d34799a-af51-48b3-913d-d973be4f4db5"), "ivory", "Small Wooden Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9cff9a5a-dddf-43b2-a915-955d552317b0"), "violet", "Small Fresh Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("90588bee-edde-412e-b35a-067e2b1e57d7"), "purple", "Incredible Granite Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e0d8e2c8-0280-4020-be2b-092fe667bf04"), "plum", "Small Wooden Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1b980fe3-7054-4d60-af3f-46f2ed51c4df"), "maroon", "Sleek Granite Table", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("29d68340-3a15-48a7-8e23-5a5a26dcf27e"), "gold", "Handmade Frozen Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("443b4eb3-0407-4be4-bb85-db4decc86a16"), "olive", "Awesome Plastic Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b28647d2-0159-45d8-a00c-53567ee88f12"), "yellow", "Intelligent Soft Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("de281391-4031-4ec0-b892-28e5d3c17245"), "orange", "Awesome Rubber Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3bebe9be-b0ef-4ee9-9ed4-81a2dbe7bfd9"), "orchid", "Handmade Wooden Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c80a6430-ae39-44cd-a86f-6cb21794f51e"), "mint green", "Unbranded Frozen Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2fb5416f-3d18-4b5a-a8d0-4d6989717301"), "grey", "Practical Metal Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("82e24dff-d5e4-47c5-b953-83d4d50a8724"), "violet", "Incredible Frozen Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3ebcb43e-1000-4c1d-89b4-0a69682a1013"), "lavender", "Awesome Steel Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ddb3fa90-6871-43ea-b13e-8002f89548cf"), "blue", "Gorgeous Frozen Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8bf0b048-7b45-4f1c-b659-28da66b20fcf"), "red", "Licensed Plastic Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("653fbd19-4e3d-44b3-96b1-eb6f66de8dd6"), "magenta", "Handcrafted Steel Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5f3d02e8-b3d1-4af5-953f-d1c107b43a98"), "pink", "Licensed Steel Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9f8484a6-57c9-4e4f-b230-564b1dd771f0"), "turquoise", "Unbranded Wooden Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ed8b89e8-6d76-4746-bd9b-04c9e527f1d6"), "azure", "Refined Steel Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b577713e-14d4-4b19-801c-aedc138bfcc1"), "indigo", "Unbranded Soft Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("311b437f-8654-45c8-830d-593da5f55547"), "violet", "Handcrafted Metal Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ce934aad-fc0f-4166-bf56-adef505cae9c"), "teal", "Ergonomic Fresh Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f1592c2e-26ab-4ae7-bae6-c69c46e7e0af"), "mint green", "Ergonomic Fresh Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("789a2643-d227-485d-a874-d6e8a1de9ca0"), "maroon", "Gorgeous Wooden Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a2cf1a5c-3974-421d-9027-a59584ba87de"), "red", "Ergonomic Frozen Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9cb65a76-3aa6-4d44-8168-16eda36b3e1e"), "cyan", "Handmade Fresh Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d7edba65-c1b6-4258-aa86-b45672870844"), "orchid", "Unbranded Metal Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("691dcfb3-a0e2-45cc-bda0-f87754860c01"), "lavender", "Unbranded Soft Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dc113b19-d0bc-4c81-984f-cbef95b3365f"), "pink", "Ergonomic Steel Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d427730b-afbf-499f-9fe3-bddc84e407da"), "fuchsia", "Handcrafted Cotton Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7139e50a-f3b0-47ca-92db-6ac9aab52c0f"), "mint green", "Unbranded Wooden Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("231b53bf-df11-404d-ba3b-67feebe25fe6"), "black", "Small Plastic Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dd6f65d1-7f20-44db-b1a1-db45b9abdd19"), "silver", "Intelligent Frozen Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ce6d6ef5-6a91-4468-984c-f3a281bccc82"), "orange", "Generic Wooden Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("42bd9839-4f9b-490c-aada-98d5bb71df9d"), "gold", "Handcrafted Soft Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f34ff4b7-be5b-4eb6-a000-de540732addf"), "black", "Ergonomic Wooden Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1e626ecd-85ce-42ee-91fb-acfbea4f5e09"), "white", "Incredible Soft Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("43de4ff9-49ea-4d94-9b41-02a695ebe01d"), "gold", "Sleek Steel Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bb484871-ef3b-4d5c-a3d2-64955ef16cd5"), "teal", "Handmade Metal Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5fa8b604-2c04-420b-8246-ffc3d4d75f18"), "olive", "Incredible Cotton Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("77b5d553-8651-4786-83e0-27564dcb008b"), "indigo", "Unbranded Plastic Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("21a537f0-20c2-4420-830a-f28c47b00e2e"), "gold", "Ergonomic Wooden Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48c7f850-c49e-4afc-b1e8-00a220019048"), "salmon", "Unbranded Concrete Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e4fce5db-613d-4cc6-87aa-1d8573739fa4"), "black", "Incredible Frozen Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cb4eb32b-b03b-4b6d-91ab-1aaca2c1546e"), "gold", "Tasty Cotton Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("04545898-3443-4fd4-81d3-ffbd60d433ea"), "turquoise", "Intelligent Plastic Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c15808e4-d650-45bf-be9b-f58ef535f5c0"), "gold", "Licensed Rubber Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7339f2a4-e702-4713-9371-fdf6624697a9"), "orchid", "Refined Frozen Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f711eaa9-29e6-467d-9fd5-348d6aa7ba2a"), "olive", "Handmade Wooden Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9796ba33-3ad2-40b9-b94c-03e612c36038"), "salmon", "Handcrafted Cotton Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2d5b87db-e599-4639-bcbd-cf2ca6db3564"), "maroon", "Generic Plastic Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9a8af48d-8e24-45b1-97cc-798a33602cfe"), "olive", "Intelligent Fresh Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a763bc12-59cf-49cb-8fb9-fa9450110c60"), "sky blue", "Handmade Frozen Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e8055f93-4780-463b-a696-39380885e315"), "red", "Incredible Plastic Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1daebef8-3bed-46c9-9d6a-ceba8640aeb6"), "turquoise", "Fantastic Cotton Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("965a386d-e7a7-48bb-9a91-1d79cf982477"), "fuchsia", "Refined Fresh Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0b8e7da0-b053-429b-abe1-0df9fbfd80ca"), "mint green", "Licensed Metal Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ef346ec1-0074-45ff-bc79-a8c4e23871d4"), "purple", "Awesome Metal Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("27e3803e-cb4c-466e-9ff4-3d40f78aa19c"), "gold", "Unbranded Concrete Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6bce941f-c7a7-4923-906a-d3a25cb04e77"), "silver", "Licensed Rubber Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0b8aa658-cab1-4589-bd6c-c6f139378b5b"), "teal", "Gorgeous Wooden Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("478989e3-922c-431f-bd58-c597261990be"), "black", "Intelligent Wooden Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f082ff60-7700-4c2a-85bd-359e4b506775"), "azure", "Incredible Granite Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9bcabfb3-5f31-4344-8df4-97b6dfc9e00e"), "fuchsia", "Ergonomic Concrete Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d717a754-4d8b-490b-8584-62f251f58cc1"), "magenta", "Generic Frozen Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5bddeaab-f4d7-4a93-9919-e75f3161c7b2"), "turquoise", "Rustic Rubber Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ab806275-df0f-4dd0-a83a-7a186f72a32b"), "mint green", "Gorgeous Frozen Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9a6fa07e-cc28-4761-b74b-038c2995c3a7"), "black", "Handmade Frozen Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("18894ae1-f42b-4738-85e9-87dac2621a56"), "green", "Generic Steel Hat", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7524d8db-547b-47c9-886c-9142e8487cfe"), "black", "Practical Plastic Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("df3b1a21-c2ed-4513-b147-b136564a72c0"), "teal", "Awesome Steel Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("639e3397-898d-4300-b93b-d74eaa472dca"), "mint green", "Refined Wooden Ball", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("88c9cace-7c13-476c-bf43-416ba11a3b50"), "gold", "Licensed Granite Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("06ffd281-49be-4632-8290-367b271dbc1f"), "salmon", "Ergonomic Frozen Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cfdb4b7c-66f0-48bf-9b27-e3604a62019f"), "tan", "Refined Metal Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bb4a6e5a-8946-4414-8788-fd72f00105ce"), "blue", "Unbranded Concrete Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2acf7def-e5ba-401c-a5ec-5fed7aa861df"), "black", "Intelligent Concrete Gloves", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("578e40ef-8fcb-4ac4-a6cb-3596dd514e4e"), "grey", "Tasty Fresh Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0e3cfe8e-fcf0-40fe-932e-b9790ddf891d"), "silver", "Gorgeous Fresh Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("66ca9772-128e-4d67-9d24-e7896efff0de"), "plum", "Intelligent Granite Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aea7a4e2-0361-4d24-a33f-b89f3e160deb"), "sky blue", "Refined Wooden Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67239c7b-a1f0-4a9e-95cc-b4c3ea1ab0c2"), "violet", "Fantastic Frozen Tuna", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5c489cb3-4661-4832-9445-100780902314"), "blue", "Handmade Concrete Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("41ca4316-9003-4688-8816-ef993e6e1aa8"), "indigo", "Awesome Concrete Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f8bb4ee7-8c04-49e2-8d84-cdd6ba450aa9"), "black", "Gorgeous Rubber Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5dce6557-526b-4a56-9b23-345ea2c4e1b6"), "sky blue", "Unbranded Rubber Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b16031d8-94dd-4a4b-90cc-dfce0e298082"), "purple", "Practical Steel Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c411fc0f-4130-4f9b-88ab-cf6d69c99704"), "tan", "Rustic Soft Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b29a6706-fead-4e4b-97a4-5aba36fa07ae"), "salmon", "Small Concrete Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec947aa7-de2e-4831-927e-65f6fc51f680"), "gold", "Ergonomic Wooden Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cb982557-eaf0-45cb-a906-f2825f0af626"), "azure", "Tasty Granite Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d3ad66ce-1043-4d0a-b65a-2297af2d8bf7"), "black", "Gorgeous Plastic Ball", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4343266f-a5a6-45a6-a6c8-e35e69c15121"), "orchid", "Handmade Wooden Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ed675481-9fe4-4fb7-92f6-052e14860f30"), "magenta", "Handcrafted Concrete Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7d9fe404-1bad-443d-9b54-378820d439f6"), "purple", "Licensed Cotton Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3b105949-9af9-4b8b-8732-6fc4b87af15c"), "lime", "Small Metal Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("75c09d86-3e35-4440-a8b8-67fc6d2a336a"), "yellow", "Licensed Rubber Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20e3d0ba-7408-4a60-b372-f8eb26ac4ec9"), "turquoise", "Unbranded Soft Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5253b718-5c06-4145-8cb5-be1264d398e3"), "olive", "Refined Granite Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("959971d6-c6d9-481b-8614-1348a55402cc"), "indigo", "Refined Rubber Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("716765a2-715c-4838-8bf6-be45a72056cd"), "gold", "Sleek Cotton Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3ff65c2a-921f-4b8d-88de-eaf3543be574"), "gold", "Awesome Concrete Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9384a923-6db8-4394-8e21-b7d0698e15a4"), "gold", "Fantastic Frozen Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("efc597ea-e7f0-40f9-864d-5568fc4fbc97"), "blue", "Fantastic Soft Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9e63f72d-7f37-464b-9f40-d856eb663e7e"), "olive", "Intelligent Plastic Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20024648-a230-4bd5-bd2d-ac28b3cccd98"), "pink", "Fantastic Plastic Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("003f60da-2992-4288-bef7-a3a6b935472e"), "lavender", "Refined Wooden Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("651159f5-4462-478e-a8f9-852e692148c2"), "grey", "Generic Soft Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c8cc0863-e540-4371-a5d0-2ab685b8ed67"), "yellow", "Unbranded Concrete Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ca91cda1-3073-46dd-8110-31c7900c7b7d"), "olive", "Small Plastic Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1f55bc47-d9ae-4385-ace5-53e93bf23dfc"), "lavender", "Intelligent Granite Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e1927267-91d6-4d4d-aafe-150ef1be3bc6"), "green", "Refined Steel Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bf160ebd-a874-4288-8973-6e57bcb7bfb5"), "turquoise", "Unbranded Steel Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fbc82afc-d915-43fe-b4ca-4a4702dc264e"), "fuchsia", "Tasty Plastic Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("556a41fe-8f6a-4046-9fde-7e3f9076b9d1"), "silver", "Awesome Wooden Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e2f38b02-b13c-4afd-ba2c-f08d68cdcf78"), "white", "Small Rubber Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e7392016-62cb-4c3a-a052-edf6f5bcac29"), "purple", "Ergonomic Wooden Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2903bb4f-f777-4ae5-a5d7-50c1f06f3911"), "orchid", "Fantastic Fresh Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a070a2e0-6d70-4b0e-9e85-9f1b94fab3ae"), "blue", "Generic Rubber Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("08d715b2-564f-4def-bc3e-b5237e8c9834"), "cyan", "Refined Cotton Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dd0597e9-e019-49fc-a2ab-6ed08809ff20"), "turquoise", "Handcrafted Granite Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cbb176cf-381b-4a6f-b2b3-ef8619aab576"), "salmon", "Ergonomic Soft Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ebcf36a0-82cd-4cd1-81e8-8d7d5dc9a343"), "magenta", "Gorgeous Soft Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7a43b996-40a7-413c-b7ce-97b5d81dc674"), "fuchsia", "Licensed Frozen Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d4180779-c543-4072-bd8b-bd4328c17ef8"), "teal", "Rustic Plastic Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("98dd2240-c4b9-44bf-83d1-667b9f2e5669"), "fuchsia", "Tasty Granite Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6d6bc907-66a9-43f0-a49a-80f421d0f773"), "gold", "Handcrafted Cotton Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("66dad490-bd9e-4c2a-8131-c1d30ac45045"), "sky blue", "Awesome Fresh Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1a58beae-4e9d-4a5f-8a30-4edf55d6cb69"), "grey", "Generic Rubber Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bd63d760-16d0-4148-b454-61c224550816"), "fuchsia", "Licensed Metal Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6b4cc359-c019-41fa-8adb-b501f44035bb"), "pink", "Ergonomic Plastic Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("94f0de29-d7f4-4749-87ee-ee81f13b8512"), "black", "Gorgeous Fresh Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("243d7695-a178-438a-891f-d36fdfbd6431"), "violet", "Rustic Cotton Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("33260539-5ea1-4055-9738-3a764d9be372"), "white", "Unbranded Rubber Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("da3404cf-6363-4fbc-b15d-b4762811bb08"), "lavender", "Awesome Soft Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d1da70d1-19f0-46e8-8997-6a6a1012341f"), "tan", "Fantastic Steel Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e1d70651-3ca8-4cc2-bf5e-2bf68f95ae4e"), "maroon", "Rustic Fresh Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cc557b57-bac9-4c17-8d8f-401e0c49d2c3"), "lime", "Incredible Soft Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6c58f4eb-7ee5-4c3c-8e14-67844a97c9f8"), "salmon", "Handmade Metal Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3004b902-1a43-4cdb-81b8-aefc3169a682"), "blue", "Small Fresh Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("53284a23-4cd7-4831-a44f-dbdf7f76ea59"), "turquoise", "Licensed Frozen Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d56b3633-0e71-4445-b6bc-0b33d724a85f"), "magenta", "Handcrafted Plastic Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4091403e-a9a9-4de5-a224-845600843307"), "sky blue", "Sleek Soft Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("01f8c70c-89e4-4bf7-be0b-faab6afab0ac"), "yellow", "Handmade Wooden Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bbbcfb3b-784c-4aa4-a053-16dc7a22f8ce"), "cyan", "Awesome Steel Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e5d226a1-3e23-4e28-bc03-86e1b2775ca7"), "teal", "Refined Concrete Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a029e6b8-5823-42f2-a6c1-a1f0651fe771"), "maroon", "Awesome Cotton Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48d0e798-ccce-4994-89aa-b3a23e376d91"), "orange", "Unbranded Soft Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b70b06a6-577f-4963-afca-da132f13566c"), "tan", "Rustic Concrete Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("326cdf10-0c68-41fe-85df-1355e036c54f"), "gold", "Tasty Plastic Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5e1013f4-14a4-4ce9-b00b-b0082f1d59d4"), "orange", "Refined Wooden Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d1608334-354c-45a5-a89a-6c96408f6446"), "grey", "Handmade Metal Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fd0b1a77-5e0e-4312-9850-e73ad87cff25"), "purple", "Practical Frozen Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8290360a-61be-43f9-b354-f21fd2e0fde0"), "green", "Ergonomic Wooden Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7cbd34f5-a80a-42b2-a339-24932f2495b3"), "red", "Awesome Rubber Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e20d22b3-afab-44d4-a00f-fb4b3ed4740e"), "maroon", "Tasty Fresh Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5140d731-db66-4b87-aa2e-7798d22f0642"), "purple", "Sleek Concrete Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dd54a21e-aabc-4bcf-9ed9-41dedd860530"), "cyan", "Fantastic Fresh Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("312819de-44ec-4b87-a7bb-ee2352bee5f3"), "turquoise", "Practical Cotton Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("883738bc-2e80-4c6f-840a-dab9d357e764"), "green", "Small Rubber Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac136c4e-073a-438d-9752-f65b836e384c"), "white", "Licensed Plastic Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ea81a199-756e-4a89-a2bb-a6a0e87cb15a"), "turquoise", "Incredible Frozen Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c7cc1df9-defe-4e20-be72-d9a1358bb754"), "yellow", "Tasty Rubber Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c4f46a5-58df-4034-bdae-c3fe36f6bd12"), "turquoise", "Small Soft Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("97b3f2dd-810f-4b67-b1ae-3bed3c5f5ce0"), "blue", "Licensed Plastic Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1a06bf36-7f73-4167-a6e1-853179c4d8ad"), "orange", "Handmade Metal Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8cafb295-55ff-4bb2-aa14-a0b09bd5fb7b"), "sky blue", "Unbranded Metal Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a447ce41-d0f7-480e-acee-b27d9ce2fe08"), "plum", "Handmade Steel Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("24f637ef-ea2b-473d-9f44-26c03e26943e"), "white", "Awesome Cotton Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f8e61177-3bf1-43d6-b30b-865132fda480"), "olive", "Handmade Rubber Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8099bf5c-b32a-4b38-870c-a5e038b6fcc7"), "blue", "Fantastic Soft Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0f920800-6379-475e-b1f2-8aed88969a9e"), "gold", "Licensed Wooden Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a97da822-5881-4129-a4cf-8c60fb092e3b"), "violet", "Intelligent Concrete Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9231fe3f-a070-430e-8bd0-710286aaf722"), "violet", "Handmade Cotton Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9cb8bfaf-e1d6-4e52-b987-ab07531782ab"), "indigo", "Unbranded Steel Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5b338958-431e-4736-a5d3-8e251293c68b"), "pink", "Handcrafted Plastic Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("37206b15-7af0-4675-8d47-6f05d71e0775"), "orange", "Handcrafted Fresh Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dc17f242-fa66-478b-a764-a2d03d4c2e36"), "turquoise", "Rustic Fresh Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6ce2dd1a-61a9-4253-9d7c-1716e4dbd5cc"), "sky blue", "Generic Plastic Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8f660875-9e26-4c85-bbba-1f15cf042914"), "ivory", "Fantastic Wooden Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9e633bba-2a7a-4b08-845e-8e9fb38cdc97"), "gold", "Fantastic Granite Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4afc4d13-f6c4-4113-8f0c-c46f35f4d91f"), "grey", "Fantastic Steel Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("87b231ca-d969-49d1-80b1-3b1e0121cb6b"), "olive", "Sleek Concrete Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7188927a-f908-4435-bfec-1208c6dfbac2"), "lavender", "Fantastic Granite Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("db6581a2-7480-4761-9d14-7d1438246368"), "green", "Unbranded Metal Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("759e38c7-d002-430e-8264-360f5f51c23c"), "salmon", "Awesome Wooden Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("beb3f270-6016-4f56-b52b-1b31ec4fa941"), "plum", "Awesome Concrete Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a93899e8-c4b5-4839-bbee-458a9a72ac4c"), "fuchsia", "Rustic Concrete Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("45029c1a-c0c9-4ed1-a295-86d205736f15"), "yellow", "Handmade Fresh Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9d289c9d-2f05-48bd-92cf-a83265ec48d4"), "purple", "Incredible Frozen Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7f011fe2-9342-4be6-a3a9-5512824fc589"), "violet", "Unbranded Wooden Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("43e89de2-7517-4e2d-b519-e5b730600bda"), "salmon", "Handmade Fresh Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ccd85adb-f11d-4eb5-9d93-2afd97df4708"), "salmon", "Intelligent Metal Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ea6c2230-1dad-451c-a58b-9671aeaa2865"), "orchid", "Intelligent Frozen Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("23d483ae-f4eb-42f4-bc80-8e733156800c"), "gold", "Rustic Metal Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("85636a8b-4517-41c2-ae7d-1fee397e1a97"), "black", "Tasty Fresh Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a3622d2c-c4d1-406e-9eaf-c38d9fbede60"), "plum", "Practical Wooden Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("441ae38c-df97-45ed-b986-c4f633300c38"), "black", "Small Wooden Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c246b717-f9fe-4167-9380-93fa081a74ee"), "lime", "Handcrafted Steel Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1136022f-1d0c-42c0-918c-2ae50281828d"), "cyan", "Small Plastic Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("98d64b8d-cbcb-4648-9d76-3e8df9e669b5"), "sky blue", "Tasty Fresh Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e4378ef7-18d1-4580-a230-da3cd6fbd5b1"), "black", "Fantastic Concrete Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d2585b9a-5c2a-461d-b0f0-b93cf4f781db"), "yellow", "Sleek Cotton Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eb08a79c-8c73-4fa8-bcb5-6f0b8f9e6f8f"), "ivory", "Ergonomic Wooden Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("17a00e5a-a487-444b-be23-4d8ee529df5f"), "violet", "Sleek Cotton Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("97939a48-8737-4325-9cf5-8344b6f7c747"), "lavender", "Handmade Granite Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a33738bf-2a09-4a3c-a04e-eaac48ad2c90"), "cyan", "Tasty Rubber Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("66a407cf-e355-4b0e-ae85-ed5da05c6d02"), "maroon", "Ergonomic Fresh Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("264b4d53-8444-4902-8ff9-85613545adc0"), "plum", "Licensed Frozen Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c58a05a4-51c4-4757-b9e0-27635ce8672e"), "olive", "Gorgeous Concrete Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c2f6ae8b-9e78-4cf4-a482-b87894db3dac"), "cyan", "Intelligent Wooden Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("93243136-b047-4377-9949-b3e7a62d0c91"), "olive", "Tasty Granite Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7a9775c2-cdbb-4b4d-9bca-7a0273a9d588"), "sky blue", "Unbranded Fresh Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("566524ac-3d06-46e1-b5bb-4e8a301a4178"), "maroon", "Refined Wooden Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6a86614-dd05-4d44-bdfb-5dec31f02b54"), "white", "Gorgeous Steel Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ed3f5feb-3072-4f9d-9d3e-2ebd7596329b"), "azure", "Generic Plastic Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f4d82b98-e052-454f-9dcc-827f4f5dd190"), "ivory", "Sleek Cotton Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("412deb9e-aa93-46e2-82ed-7e2e8e51dd46"), "lavender", "Practical Metal Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cf5cd0cc-e3e6-4436-a93f-35e6ca40485b"), "lime", "Generic Soft Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("46fd22f5-a661-40b1-a482-2afc85f0b74e"), "cyan", "Unbranded Rubber Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6cafca66-bdcc-4698-917e-26561de08cd4"), "orchid", "Ergonomic Plastic Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bd82cfef-ea83-4703-91ea-9a2ffde93b45"), "teal", "Unbranded Concrete Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("713133c7-5d49-4408-92b7-1200bab23806"), "blue", "Gorgeous Metal Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b0186c71-2bce-473a-a82a-dc89a0e11845"), "lime", "Sleek Wooden Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aa9de43b-4d44-44a6-8d30-69d464c74ebb"), "black", "Intelligent Rubber Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("628f5c7c-98d2-47cb-9cb3-fef767291d5f"), "mint green", "Generic Granite Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("203c82f4-59ab-4278-a0dd-a1e208061193"), "orange", "Gorgeous Plastic Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0547ed36-bd91-49bd-9991-f92e1028a0b4"), "gold", "Intelligent Rubber Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("108213a6-77c4-4d9b-bd11-341b770cc1ae"), "magenta", "Generic Fresh Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("81aa8bf5-5309-4365-ab33-90b8c9c1e44e"), "pink", "Rustic Plastic Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7d4e5226-7211-4682-a7c0-d8ce991c7f55"), "azure", "Incredible Granite Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("074b68c7-95ab-457f-bd82-fb17f90d260e"), "grey", "Practical Steel Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8a186fa8-057b-4f66-a2e3-1e429262e1b8"), "mint green", "Fantastic Fresh Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("302166a0-6719-4b96-a0cb-5f13c2a3b4ae"), "grey", "Unbranded Frozen Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dfaec343-d52c-4454-b6a8-fd7bdea13472"), "yellow", "Handmade Fresh Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("61a8f4fa-ebcc-44a4-a8a7-3f28272663f0"), "indigo", "Fantastic Plastic Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9a7dbd79-75f7-4df0-b7ff-7a6c0ef1ac86"), "olive", "Handcrafted Granite Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("18c3e451-7e4b-4d68-9e53-78cd8b3fb86e"), "lavender", "Unbranded Plastic Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3c098a3a-f2cd-4d13-ace7-645137130890"), "fuchsia", "Incredible Steel Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("100e3899-5037-4778-89ea-02ee29cc1994"), "red", "Practical Fresh Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dad30e91-e825-4ec0-96c6-6238f1e9d5ad"), "purple", "Intelligent Metal Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("70e71441-88f6-4c36-aaa2-5b231a46af16"), "orange", "Practical Fresh Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("65d44619-d1d3-41c1-a2ea-864e9d93dac1"), "red", "Rustic Wooden Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c5c83473-cc9f-4b4f-bf2b-492e99cc3026"), "maroon", "Licensed Cotton Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2dd8ef02-5ba4-4f4a-9bfb-a0de68e993bd"), "orange", "Generic Metal Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("109e18a0-dba0-4160-9555-8e8f1cfd95ae"), "indigo", "Handcrafted Soft Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("05755f2b-21d3-4fea-8f35-641b35959f14"), "orchid", "Awesome Rubber Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("860c0fc5-5c01-4f73-9fed-fd925b1b2fc3"), "teal", "Small Steel Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a59c807d-8def-48ae-883f-03946621f14a"), "pink", "Small Rubber Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4a2478ad-c1f1-4a49-befc-cd2b09912427"), "gold", "Rustic Frozen Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3762f389-c145-4c55-8aed-4a86a03139b1"), "ivory", "Ergonomic Soft Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3efe2008-2a1f-40a7-885c-86c5677b3f53"), "white", "Awesome Frozen Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("513dd9b0-5d59-485e-97f4-b1e29fae6f70"), "purple", "Generic Wooden Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6ff0949f-55f7-48bb-aa5d-5185b537ab50"), "fuchsia", "Awesome Plastic Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("94f2889e-87bf-424c-9815-991da5ff1d03"), "blue", "Licensed Frozen Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c9e3ee98-6ce2-413d-8928-1f7077663d50"), "maroon", "Small Metal Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7425548b-16e3-4b14-acb1-4dd90c4db43f"), "white", "Fantastic Granite Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("02dfaa0e-a61e-48c6-af5a-0ef79cbf1993"), "sky blue", "Fantastic Fresh Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b2b6755f-55d4-4e5d-ad7e-be18e70bd572"), "silver", "Practical Steel Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c66e68f4-d94d-42d9-8cf8-7e7b17ac443d"), "gold", "Tasty Granite Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("16f091b4-055c-46c5-af0f-3514b8064332"), "ivory", "Sleek Concrete Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e95ca227-7cf7-4f5c-8dca-91485ee8a904"), "silver", "Gorgeous Rubber Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("af073225-7de2-4930-ad5f-a0e028e0375b"), "pink", "Ergonomic Plastic Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("83df7118-7a61-4b2f-8117-337a3a025066"), "azure", "Rustic Wooden Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6ffbb099-6216-4ea4-b888-0e8b9ac03d80"), "gold", "Incredible Frozen Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("52931352-424b-45e7-9175-fd29ac0d99ff"), "olive", "Ergonomic Cotton Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("92ca4314-a8f2-470a-8b5c-9a152f95251a"), "maroon", "Fantastic Frozen Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8c277553-e8d3-4be3-8a90-7d1ef85bc779"), "fuchsia", "Small Granite Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1714ed82-7967-4ed5-94a2-48d049ceb2a9"), "fuchsia", "Generic Concrete Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4c8d1790-1a3e-4f89-a21f-626cadb67a6a"), "tan", "Handcrafted Wooden Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("89fb4d18-d543-443e-9eb0-08a6d4681d85"), "silver", "Practical Cotton Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cb5140ef-f419-4ca0-a8ac-da532701247f"), "silver", "Sleek Frozen Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1809186a-720b-471a-b0b8-397134e865dd"), "ivory", "Refined Wooden Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b34961e1-b51d-447b-9099-6ffffe8e015d"), "purple", "Small Rubber Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ce53fd3a-34b6-4c6b-a6ce-5490a220a324"), "red", "Ergonomic Rubber Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c2f050b4-9ca9-4a4f-be40-dbb22331aedb"), "black", "Rustic Soft Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0b3b1f75-3190-4b32-9d35-cb80ce6cbb68"), "lavender", "Tasty Plastic Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6ba74f13-b0c6-46b2-98d4-056586f8e17b"), "salmon", "Unbranded Concrete Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5baefbea-d48c-431d-97da-3b1dc3fb342d"), "azure", "Small Metal Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ce88ace8-9a95-46f7-adcb-9550f3457433"), "white", "Sleek Rubber Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c5ba0e71-e865-48e5-afe9-bc804919a153"), "fuchsia", "Rustic Steel Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3f23eabd-59c9-4a2d-ae98-65625a0c3561"), "azure", "Gorgeous Frozen Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("784eb5a5-766b-4c64-97aa-f88627b34c25"), "cyan", "Handmade Rubber Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("684ef5c7-3832-40ce-a750-ecd65cdcb65f"), "azure", "Generic Wooden Fish", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eb03c497-1e94-4069-8852-3c4ea28a892f"), "white", "Licensed Soft Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e1ad35ab-af6b-4b53-99f3-4ff43f53d86e"), "cyan", "Tasty Wooden Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0fbee71e-e11e-4f45-aa13-c629b8f0b483"), "indigo", "Awesome Cotton Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0ceaffa2-3e9a-4d0d-b1a8-ef556dff9ecb"), "cyan", "Unbranded Wooden Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c66b8f6a-2b80-44fe-8d72-79138ba1c764"), "lavender", "Handcrafted Wooden Hat", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5256f74c-90dc-4908-85d2-b69d76f25fcf"), "lavender", "Tasty Frozen Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("feb20787-3bf1-4a3a-a1d1-939f3e7d6dd0"), "black", "Generic Rubber Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ea83d4d1-8c81-4313-873e-3fd9ff5c74cd"), "maroon", "Refined Rubber Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("839068fd-686e-4a1e-abb7-e688aa561779"), "grey", "Small Steel Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fe29e053-bbeb-468c-a816-adbd70a54f7e"), "lime", "Ergonomic Concrete Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a8aee94f-07ee-4743-9b89-fb8d150921fd"), "white", "Rustic Rubber Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8e0108a5-65ae-4111-81d7-d36a9a91a330"), "sky blue", "Incredible Cotton Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aabbed1c-3df8-460a-a1ed-8c3964f8584c"), "green", "Unbranded Wooden Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67a26c9b-24ba-4818-a765-c767176f30c8"), "lime", "Licensed Concrete Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("45567bf1-7ae4-4549-a34b-551a7efdc48a"), "cyan", "Small Steel Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("379bd016-841e-4b12-8be5-e92204db83f4"), "plum", "Awesome Fresh Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("64b3d8b5-0021-4076-a52b-6a34b56e812c"), "ivory", "Unbranded Frozen Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ad52f809-e377-4312-a20e-5171d3ed27ea"), "gold", "Ergonomic Concrete Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ee2b57a3-96e9-4719-8dce-88c905b981d3"), "lime", "Unbranded Plastic Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9dc25a0f-ee5c-44a3-b90b-659b78fe08d8"), "magenta", "Unbranded Soft Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6bf16f1-5f7d-4873-b4ee-4fb10a9b821e"), "teal", "Refined Frozen Ball", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b3473fda-c95c-4550-b53e-980633285754"), "salmon", "Ergonomic Steel Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("45e765d4-a4db-45cd-9675-84c7abd8e3ad"), "mint green", "Practical Soft Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("99f61209-afd8-442a-adfc-36cbcb61d020"), "orchid", "Tasty Steel Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("62fc0b19-a0d3-4dfe-890b-85beddb71b02"), "red", "Awesome Fresh Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b229fbeb-d2df-4927-88da-141fefbb2b37"), "turquoise", "Handmade Rubber Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8a8ab655-b438-4911-9a37-826e18822524"), "silver", "Handmade Cotton Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("96eaa812-421a-4f93-9cd1-c9774879be0f"), "silver", "Tasty Metal Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("96c2104a-dee8-4c7d-9545-f24c36e1f45f"), "silver", "Tasty Cotton Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("121c9c9f-170a-4a19-8ba6-efb1b7510033"), "lavender", "Ergonomic Rubber Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8fe5ecc9-3955-4195-b322-d10399385889"), "yellow", "Unbranded Plastic Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("77b10122-5b5c-4200-93a0-a24e0c139137"), "salmon", "Tasty Granite Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("64e157d7-6bd4-48a1-a997-cc6201448270"), "indigo", "Practical Plastic Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d1c23cb5-8633-4ae6-9c1d-a63a79176648"), "orchid", "Small Fresh Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c672bf9e-4ecf-402c-840e-e552c279247f"), "orange", "Intelligent Wooden Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("561433d5-1b16-4d9d-916c-7783dfd0b1cd"), "violet", "Fantastic Metal Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a36e8b0f-e600-4f28-9b30-a46cbd7494fb"), "lime", "Rustic Steel Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6052a097-d3c5-43e0-9fe3-a481d283795d"), "teal", "Generic Fresh Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7ff5bc69-cbc0-40d5-857d-6d62200ee00f"), "red", "Generic Plastic Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("268f5f09-bfe3-4617-ba31-8c86f01b5d1e"), "sky blue", "Handmade Wooden Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("198fc52c-cfc9-4357-a968-4271b5f648b6"), "mint green", "Rustic Frozen Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a7532ffd-801c-442d-a17b-b2729a0237d1"), "turquoise", "Generic Plastic Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8c3da524-950d-4089-9791-f0739823038f"), "pink", "Refined Granite Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a84c7106-a2b3-4678-af5e-ced7e3e34f4a"), "tan", "Intelligent Granite Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac8c2df6-b5dd-4174-b666-99c9190cf505"), "ivory", "Incredible Steel Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1ff3c12f-4653-461a-83fd-99ad4c5bc54c"), "black", "Gorgeous Frozen Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("df36dc4c-62ae-4bdf-86fd-719e085d3853"), "ivory", "Tasty Plastic Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2c62e60a-0b59-4152-b405-cf108e8495ea"), "blue", "Tasty Granite Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("62e24a64-ca24-46af-b4ca-ef418f1cd1a0"), "purple", "Incredible Soft Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4bfdf798-106e-47a1-8ff9-3601ad6e7584"), "maroon", "Fantastic Cotton Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fae868d9-3b6b-4f63-9e66-f91399d21d3e"), "salmon", "Gorgeous Soft Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0a4f7cda-8e26-4cce-b077-a96ca9b3dec6"), "maroon", "Rustic Wooden Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("338ebe1a-71b3-4558-85a0-0c2c9f648db5"), "maroon", "Handcrafted Cotton Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5ea7d133-9991-40fb-8422-48d9961f24ab"), "turquoise", "Sleek Cotton Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7e2c4f95-e1d3-472f-af47-874a4f5dec03"), "salmon", "Handcrafted Steel Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d421872d-dd6d-4368-95ff-058400860d11"), "yellow", "Sleek Granite Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0061698c-5afc-4dff-ae91-e9b38ad1ef71"), "blue", "Refined Soft Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6f6d1b41-0569-406a-af6d-a6456c3f69b4"), "white", "Rustic Fresh Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bc7b8666-a4ab-4aa0-8bcd-60c0f5162dc4"), "orange", "Refined Steel Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("115c4c45-f5f2-4464-b26e-8495013efa33"), "olive", "Unbranded Fresh Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e9984090-93fa-4278-99c4-d379c15fd072"), "olive", "Tasty Metal Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0878cf13-0ef9-41f9-8463-8bf29b20f25d"), "azure", "Intelligent Granite Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7a1df27e-2ece-4a1b-9409-328b48e78bb1"), "silver", "Handcrafted Granite Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dbccddad-a2b5-4cb0-b0f7-e88b9cfc9898"), "orchid", "Unbranded Frozen Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d82f1b4a-dc5a-4773-ad5e-362e6d3674ba"), "ivory", "Handcrafted Fresh Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0e00567a-de6b-4602-89b3-79127fdc1380"), "black", "Handcrafted Steel Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c9a98d9d-a1a0-413f-b39a-04c5cd60cf1e"), "salmon", "Rustic Frozen Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ece1a589-49e0-4b1b-bd5b-de5654c8d6a4"), "lavender", "Rustic Plastic Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("45c0cd44-6e21-45e4-92c4-aad176911d39"), "azure", "Practical Rubber Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fb54dbcf-f6b3-4390-b3db-1fc19e04cf1b"), "azure", "Practical Cotton Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a4099df9-5afd-4ce2-b3af-5fa0253b53f8"), "orange", "Licensed Metal Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0c220451-ee10-46b9-aa57-c8904791d9c3"), "turquoise", "Fantastic Rubber Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a2136b4a-a698-49f4-961f-1d80f019124a"), "violet", "Incredible Rubber Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("87110d67-f057-42d7-8937-907649e5ee7c"), "grey", "Intelligent Cotton Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2527d453-6370-4e68-8c50-a04073a120ac"), "lavender", "Gorgeous Metal Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("02b7028e-f1b3-4cdf-93a5-d74a71bcf2b5"), "lavender", "Sleek Metal Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cc3e72fd-076d-4512-a644-e931db5604aa"), "ivory", "Unbranded Concrete Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e380fe0a-5d85-4a91-b725-d0f03a914c43"), "orange", "Gorgeous Plastic Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("08191e15-277b-49f4-bf31-d0471bc2b6e8"), "maroon", "Handcrafted Concrete Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("501df77d-f0d7-4c65-ac7f-9491419ed047"), "azure", "Generic Wooden Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("629ab2bc-a32d-4663-978e-c23a6690ad20"), "salmon", "Awesome Plastic Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("710518f5-fe79-419c-9aa8-0b65e1c82e5d"), "maroon", "Ergonomic Soft Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("03046cb2-0ccd-4771-b219-c9f6a1338979"), "indigo", "Generic Soft Hat", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c98df52d-a2bd-4462-b874-df4ecb3c438f"), "silver", "Ergonomic Soft Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20552292-f5f9-4b21-bee7-49306f2ad3ae"), "black", "Refined Granite Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eb4e5713-3129-49a2-822f-aab5fc7ebf59"), "salmon", "Tasty Soft Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1bc8d5ae-ca36-4799-874c-35fc279b51f7"), "grey", "Fantastic Frozen Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("088c8f93-589b-476a-b206-b6839a944fe8"), "mint green", "Awesome Soft Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5c169241-bc46-4994-bb0c-201e60ecdf4a"), "fuchsia", "Practical Granite Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5e0c1ac6-f51f-4423-81cf-49943ba0ba7c"), "grey", "Refined Soft Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e77a5365-77f7-42c5-a86f-544ad237806a"), "tan", "Refined Concrete Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8ea96dec-53af-4a5e-9086-fc675c4c2ffd"), "green", "Ergonomic Granite Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6dc74ce9-f6c3-4725-8258-4af43b3e2512"), "yellow", "Fantastic Plastic Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4d75f991-9e7d-466a-8fee-3e243e54e3a3"), "lime", "Handmade Frozen Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("97c680ae-1322-4b47-a46b-1962fc2f0d4d"), "orchid", "Incredible Granite Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("88555527-6d12-4ad0-9311-dda5443c0dbf"), "gold", "Incredible Steel Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9eaeed31-9817-4f3c-b15a-0095f3efad34"), "white", "Gorgeous Metal Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1f4e39ef-d584-4fed-a9f0-4e221754ddb5"), "ivory", "Tasty Granite Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("13d13b67-5f9e-4b25-9065-8da6358d6a09"), "plum", "Gorgeous Soft Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6ad8ba8-157c-4fec-bf91-b832f1f71c3b"), "grey", "Gorgeous Soft Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("814b4c3b-f568-4be0-a053-77f2a4885ebc"), "orange", "Unbranded Wooden Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e887bb72-f2f5-44ad-b3fa-13119fe730bf"), "fuchsia", "Handcrafted Steel Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6e783daf-e58a-4bb3-8a7a-f54679e4780a"), "purple", "Intelligent Soft Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20a2ceb1-9edb-49c7-bf43-5e9277aa42fb"), "sky blue", "Licensed Soft Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fbe2e5a5-ad54-4662-a380-b018fb1a6a9c"), "green", "Unbranded Wooden Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0b5d4e19-b19f-45b5-a34e-df8eb38d78c1"), "lavender", "Rustic Granite Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8188fea8-a202-4756-b821-3abda31147fa"), "green", "Practical Steel Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3a0cfd27-43ec-4026-891a-51988d50244c"), "maroon", "Licensed Fresh Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f9a7b005-0dba-4c6f-8a0a-bbe897a1f568"), "sky blue", "Ergonomic Steel Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8e19db84-ecf3-49a8-b220-e7bb518301ec"), "magenta", "Fantastic Metal Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("23eff128-e793-41b6-8eaa-42faa635a168"), "green", "Generic Steel Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1402a154-6705-40af-97da-24c6f832a42e"), "red", "Incredible Frozen Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("68fe7dff-c4b2-407f-9887-ea52db68f33c"), "purple", "Rustic Metal Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c9ad3499-c9ff-49e2-9f65-5bd195390593"), "ivory", "Rustic Frozen Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9eb8195d-e467-4268-9efb-2602eaaecbf6"), "purple", "Unbranded Fresh Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7fad749f-a686-46c1-91dc-458ade4ec621"), "plum", "Unbranded Wooden Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f74698a4-f412-40b2-a999-456cb7dd9446"), "cyan", "Practical Fresh Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3558a6ba-e25a-4111-840b-f7815e54ded4"), "pink", "Fantastic Soft Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("37e6dd1e-83fd-4d5e-82bc-c8d8a9ec57d5"), "olive", "Refined Rubber Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("19490d11-cf02-40e2-938f-a7d978e34285"), "ivory", "Incredible Frozen Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("53a469d2-8f38-4138-aaac-2721bb43b68e"), "white", "Fantastic Steel Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5dd3d2ed-3075-4372-9938-920c45855296"), "teal", "Sleek Frozen Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7bd6e3ac-a5d5-40e8-ab90-716de1f5f99e"), "turquoise", "Refined Frozen Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e2e0fc81-8570-4b4f-87b7-f248ef9ff16a"), "blue", "Incredible Steel Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aaf2ce2d-5947-499c-b9b8-0e1f24e8f9f5"), "olive", "Fantastic Wooden Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("57e2f992-0b6c-420c-8fe7-2e117a3e1b0d"), "fuchsia", "Incredible Granite Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7efcf711-cb30-4012-8307-9485a66855c3"), "olive", "Tasty Steel Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("496df63f-0700-4887-a4e5-1bf6220f9937"), "lime", "Incredible Frozen Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1054277d-432c-4a7a-9af1-30b73bed125e"), "salmon", "Practical Steel Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f8f30c28-28a5-4b1e-ae08-bf742402e2ef"), "indigo", "Unbranded Granite Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("340e544f-774f-4800-aa2c-c1c360f5c204"), "orchid", "Intelligent Wooden Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1307595c-5628-43e9-8a78-f91d6722ef50"), "plum", "Generic Frozen Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("18fdb56b-c45b-4e65-af66-e0047b92ec32"), "orchid", "Ergonomic Plastic Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1124c82f-2d33-481a-92b8-9b1d74acd12f"), "grey", "Practical Soft Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c39907e6-f6ae-4da7-ab3f-c0e0e9011c88"), "indigo", "Unbranded Cotton Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("34ce7424-54dd-4f08-b603-0b4151426cd4"), "salmon", "Gorgeous Steel Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("696bb503-d903-4eb0-b670-6f4923813f94"), "sky blue", "Fantastic Concrete Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("598dcebd-fa79-460b-9ba8-548f6800aa02"), "mint green", "Licensed Cotton Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eb6bc7f1-07cd-4b1c-9a56-af2cf69bd4eb"), "salmon", "Intelligent Rubber Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f215133a-cf5f-4657-b7cf-0266b06915e3"), "tan", "Ergonomic Wooden Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("398ce222-25a9-455d-b8b9-ab312c65ea21"), "grey", "Unbranded Fresh Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20139851-4ee0-4bb3-8db3-75211035de8b"), "blue", "Fantastic Cotton Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("627dfe73-9431-4410-9f37-5de8f382e806"), "cyan", "Tasty Rubber Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a9513aa9-f54b-434b-962f-b61e7d704728"), "grey", "Awesome Soft Cheese", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d19e0d5e-96e4-4a0a-917b-8d29b06dd84b"), "yellow", "Ergonomic Rubber Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e41726e0-761e-48e8-9cb7-b5e45f0f0acc"), "yellow", "Incredible Rubber Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a50be709-cdfc-4d0c-9af3-435cf44c395d"), "ivory", "Ergonomic Concrete Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a230d00b-67ad-45a3-902f-7084e051a15a"), "yellow", "Awesome Granite Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3abb943f-4818-4931-9374-8a633a9060ca"), "plum", "Fantastic Rubber Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec236a01-6c41-4d19-a32b-0eb7b109d763"), "teal", "Awesome Granite Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0828e947-81bf-4e0f-b175-742e3b6e75dc"), "mint green", "Incredible Cotton Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b1083df1-2b6c-455e-85b9-77ec35de8db7"), "salmon", "Incredible Wooden Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1052d6c2-e18d-4724-9b85-556a99cb7d2e"), "pink", "Refined Soft Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ef082035-0337-41fc-85f9-af20be33614b"), "magenta", "Handmade Granite Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("33dcac17-640e-445f-b05d-238ef862548d"), "green", "Ergonomic Fresh Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("09e8ed5c-85f6-47a3-9df2-7977a942452d"), "indigo", "Sleek Cotton Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c987580a-6b41-4132-a5f5-6d30c01ce460"), "red", "Refined Metal Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a7008e02-e365-4ae3-bef6-c1de615f410d"), "red", "Handcrafted Soft Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cf6930cc-90b0-4b27-b1ea-1ffbbf828aa3"), "red", "Practical Soft Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("20cfcc98-d3a2-4d42-889a-1ffac8f3eb16"), "blue", "Handcrafted Fresh Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("78ce327e-42e4-494d-a5dc-d276c22557a8"), "blue", "Licensed Steel Gloves", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6623d205-60a5-4906-a608-803e079b45db"), "grey", "Small Steel Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a96dc28e-4772-4290-910b-86b71d985743"), "silver", "Tasty Concrete Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bff1dd13-41e9-4c27-a6c2-8fbac0ba1574"), "grey", "Handcrafted Soft Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9ae0df3f-ac57-4662-97c6-847aeed5663b"), "sky blue", "Generic Concrete Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec256545-f156-4019-8276-7000f153d099"), "red", "Tasty Metal Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("553d6623-fbb2-484d-8e10-f403a52c8978"), "tan", "Awesome Granite Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("88377b80-f430-4922-b0fd-944f1e81ad0a"), "silver", "Awesome Fresh Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b191858d-caaf-4e33-a438-025018b60f02"), "yellow", "Rustic Concrete Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b67dc9b4-db16-4d3d-8c9e-6d28d4a8bec3"), "purple", "Licensed Wooden Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8acd18ba-d2ff-459e-9bc4-a726159aed6c"), "cyan", "Unbranded Frozen Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("23776a5a-0cb8-4f5b-846d-7b9759624532"), "white", "Practical Metal Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1af19b0a-de09-4f1a-9404-e4880befa012"), "teal", "Gorgeous Concrete Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("514edcae-3980-42fc-9d1f-0b8d86112281"), "indigo", "Gorgeous Wooden Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a444f8c0-64d1-4085-aa89-be6a3840f3a9"), "gold", "Small Fresh Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2e967000-74d1-40b8-beef-872ce5fbc0bb"), "sky blue", "Fantastic Granite Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c8c0940-b3d2-4fee-8b2d-4f33f3b0b9e1"), "violet", "Licensed Wooden Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a7c98dd0-18db-4c9e-9582-c8e296e2ab63"), "salmon", "Awesome Fresh Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9059cf7e-88bd-4db5-92f1-0bd870a1fa55"), "black", "Refined Soft Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ea4ace10-024d-4705-a183-1e128a6832d6"), "blue", "Unbranded Metal Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c9f64946-cd60-4013-9bf3-a6305bd1c4d9"), "gold", "Handcrafted Metal Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67bec602-3766-47dc-8b2d-40115f486e52"), "lavender", "Small Wooden Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a171bd6b-1ebb-43bb-a0f1-589867e571ad"), "indigo", "Unbranded Cotton Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fa32e962-a11e-4cf9-9cc8-3ec34a334cbe"), "orchid", "Rustic Soft Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("43a35237-6ffb-47d7-9431-391daaca735c"), "orchid", "Practical Frozen Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("29fea01f-dba9-4aa5-ab0f-ac3cab455045"), "white", "Intelligent Concrete Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fef08561-d3f2-47dd-a198-1ea922dc75b9"), "gold", "Handmade Frozen Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c19a390c-7e09-43c2-86a9-ced30787a948"), "fuchsia", "Rustic Plastic Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("63026239-29cb-469a-80ff-93f43c4b726e"), "red", "Fantastic Frozen Mouse", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("266432ac-861e-47a3-b7f5-1f107bcd36af"), "pink", "Practical Plastic Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d420fff0-3506-402b-ad62-9ef624e24c5f"), "plum", "Rustic Granite Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67ca7855-3f27-4339-968c-209ef13c3730"), "lavender", "Licensed Rubber Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5170e490-1911-4cea-b504-90bdb8ab6b59"), "white", "Sleek Metal Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ca5410d6-70ed-4b76-b6bc-aa1805cbb824"), "grey", "Unbranded Steel Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3ce72da1-acfd-4e0a-8aa5-748135732f84"), "lavender", "Intelligent Plastic Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ed6d7bb0-ad22-45dc-8b75-bc57a352b95e"), "orchid", "Practical Frozen Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1ee39308-21b9-48b3-8ae7-81db4d7c37da"), "red", "Refined Cotton Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("24b737b7-2de8-49cf-beeb-4cb3aaf4fde1"), "red", "Licensed Cotton Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1e715b80-8592-4f4f-bccc-8f854b37e3a5"), "white", "Licensed Concrete Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4d3bd9d1-1eff-41ae-a1b8-2d0058319e03"), "plum", "Small Fresh Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("382694c7-2fa0-46da-b1bb-b611ad91175e"), "yellow", "Tasty Concrete Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9b44d951-653a-4358-964c-cc04d106cabf"), "olive", "Incredible Rubber Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("56e32e31-7ff2-46b5-a5e8-ad94d44afd8d"), "orange", "Ergonomic Metal Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5a091234-ad18-4507-8610-4958845e7246"), "azure", "Small Fresh Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("00654053-a5ed-4f39-b127-53097d852db8"), "olive", "Gorgeous Plastic Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("01eb8456-2d36-4ad6-a641-e0ffd034993f"), "salmon", "Incredible Frozen Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3fb35466-9d9e-4902-b28b-bd2d624df501"), "gold", "Awesome Concrete Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7bd5ccf9-f39f-4af4-8002-afa74d5f0c40"), "sky blue", "Generic Frozen Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("82da92c7-ecbe-42fc-b4e6-57b82af5b48f"), "ivory", "Intelligent Granite Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("26e7ee7a-b8a9-4327-aebe-f3d3d901a3e8"), "azure", "Rustic Concrete Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d69a26b7-0eff-4eee-9acc-d947d2e06d96"), "green", "Rustic Cotton Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("52e6b4a3-356d-4c8e-9f44-cf044499e81d"), "gold", "Handcrafted Cotton Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8fac43e4-8640-4469-b155-57849188ea7a"), "orange", "Fantastic Concrete Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4124628b-9178-47ea-93d2-41ed590fd0c0"), "yellow", "Unbranded Soft Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("72e41b43-eb23-4812-aca3-0013de59ea41"), "gold", "Ergonomic Frozen Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("79822323-8a86-4cd1-89c2-c27565bbecdc"), "purple", "Licensed Rubber Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bf3943a5-6e27-40ea-a873-121ec91becea"), "fuchsia", "Rustic Cotton Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f5a6f683-4b8b-4199-8813-c7793307c9d6"), "white", "Rustic Plastic Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("36584251-2360-45a6-a19a-96f8d6d79d42"), "grey", "Intelligent Wooden Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("661e6238-abe1-4259-a630-b7ce36b82975"), "green", "Tasty Steel Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8c75efff-736a-47b5-bce5-2b3e2d1eb95b"), "white", "Incredible Frozen Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a8293c88-7e92-4514-afd2-eafde42b288a"), "olive", "Rustic Granite Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("01f6b138-14a4-4466-8aaf-e29e96ca57e2"), "orange", "Generic Fresh Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac02bf92-d5ff-4c7d-a492-a5fcc120bf1a"), "orange", "Handcrafted Soft Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("508688db-aad9-4d89-9c29-1d677e6887ee"), "pink", "Practical Fresh Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("26e5b966-0400-4be5-91da-044c5f8ad528"), "tan", "Ergonomic Wooden Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("40283711-7720-4118-866e-e32cdec90945"), "indigo", "Unbranded Rubber Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f4c0afe9-8f96-4e49-bf68-96fae7418af2"), "salmon", "Incredible Granite Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b44f3860-c1dc-45a6-b55f-0406e55a8add"), "teal", "Handcrafted Rubber Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fef61d8b-b009-47de-82ac-15c8692530f1"), "red", "Licensed Cotton Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("55271677-dccc-4864-8ad3-25b090034d83"), "gold", "Tasty Cotton Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6168b2c7-3589-4139-b949-ac1418239313"), "indigo", "Fantastic Frozen Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aa7e3f96-b54e-4d7e-8b14-1224bc0eca58"), "white", "Fantastic Concrete Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0158567d-a5dc-4db1-a019-90c31b5475e8"), "silver", "Practical Metal Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7f6c20ab-f08c-4ea1-953a-d9f8d0008108"), "lavender", "Tasty Steel Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9847936c-bee9-4743-a50b-86fbae7aecdb"), "teal", "Incredible Frozen Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("306a4902-334d-48f3-b9dd-4f71079bdcf7"), "green", "Licensed Concrete Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9fc48c63-2ea1-4e64-a244-68ab404484ae"), "gold", "Sleek Fresh Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b944653b-2211-47b4-b10d-754490b0fcb6"), "black", "Incredible Granite Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("416aebb3-c35e-4660-9bdc-cda9f095fa87"), "yellow", "Tasty Soft Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d38ce186-115b-4bb0-816c-6e61080a3572"), "salmon", "Practical Soft Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1dcfc4d1-c118-429e-b6df-11eb03df1492"), "orange", "Unbranded Rubber Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5778fe11-86b8-4b5c-974f-fa20c7b285e9"), "grey", "Fantastic Plastic Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5592c984-e8e9-44d1-90f7-d7d788c3e9d9"), "maroon", "Intelligent Granite Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("afa3d8e5-b34d-46b7-aba7-e6b4903c1568"), "lavender", "Awesome Wooden Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9c2d972d-29ad-4f1a-9ba7-bce7f3538049"), "red", "Practical Concrete Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0ef740cd-0cee-40b2-a2a2-56bc3f770082"), "turquoise", "Awesome Concrete Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c79e7a4f-0124-4b89-b96a-9d377eafcbec"), "yellow", "Licensed Wooden Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7c174568-9a56-4668-8dcd-ed5bd3074e4c"), "purple", "Unbranded Wooden Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("18fbfb2c-de3a-4a1e-8d86-bb4a5f6d784f"), "lime", "Small Soft Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("218b377d-9beb-4f12-9980-44122938e6b7"), "violet", "Tasty Frozen Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("07c01e7c-d59b-4c57-9f1f-43d5c413e718"), "azure", "Unbranded Plastic Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ad41b19a-5248-4840-ad2f-b19853b638b8"), "white", "Handmade Steel Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6a55db0a-3457-4208-ac0a-b9bb3d5efaf4"), "green", "Intelligent Concrete Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("79c1ddc6-4220-4aaf-b0a4-0bc81ecde606"), "orange", "Ergonomic Frozen Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d370e1b3-22f8-44de-89cc-23746973d681"), "plum", "Small Rubber Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cdfa667e-5994-4cf2-af67-4231b9ccf80b"), "indigo", "Ergonomic Concrete Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5e958a15-a33f-48fe-975f-b44bcedb6089"), "cyan", "Unbranded Rubber Shirt", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d3050319-83c5-4601-ac73-49779d7e9769"), "salmon", "Ergonomic Metal Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5409a33d-29ce-4eda-8d4e-260ecc6ac1c7"), "purple", "Awesome Granite Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("862e65c6-25c2-4e7e-8d06-98e4ff5c7ffe"), "mint green", "Sleek Wooden Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9062b7aa-c6a9-4ad1-93dc-91a65b43915f"), "purple", "Licensed Steel Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bbabc2a0-388b-4f99-8c12-3873a2801aae"), "sky blue", "Practical Soft Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4bfc17c8-29f1-47dd-9f75-cd42e9016fd0"), "maroon", "Generic Cotton Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7e7cc1ef-ad05-4cbc-850a-d227278674bd"), "red", "Handcrafted Steel Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7f052e90-04d9-4cb0-a476-1c76850924d5"), "azure", "Intelligent Cotton Salad", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0834fccd-278d-42f7-a1b7-a165eb03e6fa"), "red", "Handmade Metal Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("815391d0-e6ef-41bb-9f25-159d4fa69c4f"), "purple", "Gorgeous Frozen Tuna", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8ac638d2-b362-4e47-9951-5e8f0c6caf54"), "orange", "Gorgeous Granite Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c8fb036a-a633-4321-86e8-9ff915c581db"), "maroon", "Incredible Metal Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c5ed6426-595d-46f5-b4f1-d6da2bcc5783"), "purple", "Rustic Plastic Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ccf6ef05-b4bd-4352-8402-46c2bbd334f8"), "purple", "Practical Granite Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bc69b13f-46b6-40ce-9dd9-4622b524a219"), "silver", "Fantastic Concrete Cheese", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d41b6f9c-7062-4791-b059-70b2e90918e9"), "silver", "Handmade Frozen Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9f127e28-de7b-497f-98ca-58746f1a0ce2"), "silver", "Handcrafted Soft Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5a41045e-53ec-4f24-bb9c-13814ad5dc9e"), "silver", "Rustic Cotton Pants", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a122324d-21f0-43db-ba12-a560813c6a1f"), "red", "Sleek Wooden Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("987418f5-6170-41f2-b650-9921641b2ca2"), "yellow", "Practical Cotton Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("47288221-63a3-4237-b8df-3304e81bccb6"), "black", "Licensed Frozen Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("37355aee-c0e2-4369-9526-fc2f76c51f87"), "pink", "Ergonomic Soft Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c9c5145b-b35d-41f8-9c8d-4b4184e8a610"), "sky blue", "Fantastic Soft Pants", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("076278b1-3832-4454-90c9-b4aafbf40b61"), "maroon", "Fantastic Concrete Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d771346f-9b14-454a-9e40-b51197deca4b"), "turquoise", "Small Wooden Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("027534f9-3129-40c7-92ec-99d87dfdd983"), "silver", "Gorgeous Metal Fish", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f0126e98-532c-4e55-b22d-9f0810c37ce5"), "azure", "Incredible Concrete Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4aeab68b-7933-483a-97a4-688aba085c74"), "red", "Incredible Concrete Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c1e26e65-d9a0-464f-b216-6e512a590ab2"), "cyan", "Handmade Plastic Cheese", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("180a003d-ce48-4c05-87fc-1736956f3cfc"), "teal", "Fantastic Frozen Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("94696583-987b-40dc-a471-4fe58f657b27"), "violet", "Unbranded Plastic Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("622b645e-db41-4535-befc-a6ff1f40e363"), "fuchsia", "Generic Cotton Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2d6bf24e-1507-44b5-8ed4-b74aff779bf5"), "azure", "Generic Granite Car", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5f0bae5e-c966-4592-bd0b-f02f34479038"), "violet", "Intelligent Plastic Towels", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("29421bac-e80c-4a98-8a87-fbb1b9a052f2"), "mint green", "Licensed Metal Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e895ad12-5c75-4a0d-8aa6-0f406aa1877a"), "orange", "Ergonomic Wooden Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5a1a6454-9735-4a80-becf-bd14a5b35485"), "sky blue", "Intelligent Soft Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ae84bfca-a5e2-4adf-9513-a99dbfe84eab"), "fuchsia", "Licensed Fresh Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2893c49f-199c-44a6-a7e2-4d3763ec4f8c"), "grey", "Generic Soft Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f27d2caf-c227-4c2a-ad7d-395a2a46a831"), "white", "Small Fresh Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bf07710d-0993-43af-8c6f-19d792f85336"), "gold", "Refined Frozen Computer", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("118f331d-038c-413b-8319-049aa6e17b8c"), "ivory", "Rustic Rubber Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("80d6509b-6fe6-417e-b3a8-f29465570ac5"), "purple", "Sleek Granite Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6638771d-f555-4e4f-8940-698d056ab2ad"), "black", "Licensed Wooden Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dd18dd28-08eb-4ff9-8af4-163ebea4c2de"), "lime", "Incredible Wooden Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5957fcd6-249d-49de-bc14-4d459f3e15ec"), "silver", "Small Cotton Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0e5d71f6-ec21-45c8-b3d7-f1f24ed159fa"), "lime", "Intelligent Plastic Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8545e999-c1af-465c-9db6-7a082735e9a4"), "turquoise", "Intelligent Metal Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b1eeb08f-4cb3-4673-9311-7034ac1975dd"), "yellow", "Intelligent Rubber Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e96e6048-d4d7-4016-81f5-267358f31956"), "mint green", "Rustic Granite Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5fb67ff0-51ba-461e-b4d2-35177c84a00e"), "red", "Unbranded Plastic Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2f2f38d0-bd35-4841-af5f-3900f50a6c25"), "yellow", "Handmade Plastic Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9daebd75-d806-48ec-8b38-9193438a8aba"), "tan", "Licensed Frozen Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("46eeece6-bbed-49c6-895b-bcb0079f7b14"), "black", "Intelligent Soft Hat", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("11723bbb-0b10-4d15-a4d1-0303c116df1c"), "gold", "Rustic Granite Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1f98f1f3-db5b-4b6e-8362-c2c05a7d29df"), "tan", "Handmade Metal Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("66f30f16-bb8f-48a2-af2a-a2ce1010baa6"), "orchid", "Awesome Concrete Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c1ec038b-327e-43ac-acd8-1b6ea1455ad1"), "tan", "Unbranded Soft Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2923f850-807b-4c85-83c3-7874cd07bd05"), "plum", "Gorgeous Plastic Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f285d45f-dfef-4b00-9919-c3958bd27dc4"), "magenta", "Fantastic Soft Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cf43d9e5-a4b7-4892-9fb7-ae5cf810094e"), "indigo", "Handmade Soft Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a442c296-2d37-4f13-b2f8-ae1ec755a702"), "maroon", "Intelligent Concrete Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b804e48b-9b1a-4b04-85cf-427904f357fb"), "violet", "Rustic Steel Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("61c97010-1f23-49dd-9924-c49e790084a3"), "yellow", "Handmade Plastic Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3a138741-3672-43c9-b714-2158b59ee651"), "turquoise", "Practical Rubber Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9aef06b1-97e7-4baa-9314-5e2bea6b98a5"), "tan", "Ergonomic Soft Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a7fc9477-8d55-442e-830b-44f697218346"), "salmon", "Unbranded Frozen Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("064d6ed6-1c14-43ff-82fd-6434030d8f8b"), "sky blue", "Awesome Concrete Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c108b65a-070d-42ba-99ff-8f30b1965043"), "gold", "Refined Frozen Chicken", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("295edd85-3034-40c8-9b04-4f15f5bf839f"), "magenta", "Generic Cotton Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("38d481b2-f454-43fa-b2ca-386d87439932"), "cyan", "Unbranded Metal Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("07ba9705-38c6-43bf-855d-6cb386bd6eec"), "maroon", "Rustic Wooden Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("510c0ffe-03dc-411c-b806-3f359acbabd9"), "green", "Awesome Granite Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9c5bcdcf-6c95-44ef-90b5-cc76c92a3aa8"), "tan", "Intelligent Plastic Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("57d36d38-f77f-43ff-9721-827c1f42d4d9"), "yellow", "Sleek Soft Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a425bbc2-c7b6-49d0-98c3-a3df1e7402d2"), "teal", "Sleek Fresh Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7b0d331a-a471-42e3-a723-88d1ac46c9df"), "pink", "Generic Steel Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9539226a-4038-4285-9f02-634f9dd372e0"), "olive", "Gorgeous Frozen Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dcb292d3-65f5-480d-84fb-f1a8712594ff"), "purple", "Practical Soft Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bcce8923-a4d9-40bd-8c5d-a07f12654afd"), "turquoise", "Fantastic Granite Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("97728617-a823-4624-bbb9-46ddfb605062"), "plum", "Incredible Fresh Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d124a84e-015d-47de-99d2-7bb4d68db6e0"), "lavender", "Ergonomic Plastic Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0e72d4eb-6c49-4ebe-ba11-0dbf8b9519a9"), "teal", "Gorgeous Rubber Mouse", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("61655978-15c3-44f7-944d-610f1ea6ad1e"), "ivory", "Sleek Concrete Keyboard", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("64be0467-b74d-4bc8-8ff8-e7a7fef04e22"), "magenta", "Gorgeous Cotton Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2c8b0bf0-3820-4924-8840-622eef223fdb"), "orchid", "Handmade Soft Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a2d45b75-e868-4c70-a77c-c2c4210e7b71"), "purple", "Small Concrete Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e914acbe-597c-4b1a-a239-6987a6ff2339"), "magenta", "Licensed Metal Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("116ebf74-fc86-4b98-b374-54a6d4637e6a"), "black", "Tasty Wooden Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("605fd215-de4a-4c2c-994f-d2f30ff368b0"), "white", "Fantastic Granite Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f4d4b824-0453-4b32-b85a-882c950fa5a8"), "black", "Handmade Granite Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1ff69540-b5bd-43b4-bf82-2f612bca03cd"), "olive", "Intelligent Granite Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1615cb16-a685-4e1c-87c4-0e4d88badd70"), "grey", "Handmade Granite Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8f25f02f-62a6-4cfe-82c3-e0c4ff62bfe9"), "azure", "Handmade Frozen Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c0f9dc87-330e-4b4a-840f-b81f633da429"), "indigo", "Fantastic Steel Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("967ef658-ccc8-43ec-b10d-c025a2659d49"), "turquoise", "Rustic Fresh Shirt", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("adc9e77d-1c8b-45cd-9097-6e9a4166574c"), "ivory", "Ergonomic Cotton Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("dfd3920b-7f49-46c2-a96b-65d9fb753e6a"), "mint green", "Intelligent Steel Gloves", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1f69c3f9-1e17-401c-9ca3-8940c6cb7256"), "pink", "Sleek Soft Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a0901717-6f31-41fb-ba36-1e080d671cf8"), "azure", "Ergonomic Steel Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("daa4b6f7-7081-4b4e-8953-55a1dedadfb8"), "blue", "Refined Concrete Pizza", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ae8b5696-3c3f-4523-8c22-97ee5b98c3f0"), "lime", "Fantastic Concrete Bike", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fa0d1b8e-2cac-4349-a1c0-798a1594da77"), "orange", "Refined Plastic Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7e945d9a-49e0-459d-91bd-f31a81d5827a"), "blue", "Handmade Fresh Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c62c0a33-69ce-4400-b3fd-4dbdc817e268"), "green", "Unbranded Metal Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("019eccf1-1a33-4de0-a150-ce4ced9201b4"), "turquoise", "Generic Wooden Ball", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("53c062f1-5f15-4451-a4d6-53e87709029c"), "red", "Licensed Rubber Table", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1c76882d-5f60-4b8f-9e32-61e96763260e"), "yellow", "Rustic Cotton Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("84a69742-903d-4b50-b471-8444b9e16921"), "red", "Small Fresh Soap", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6a30bbec-eaf6-4b67-96ed-2c4cb8059569"), "indigo", "Rustic Plastic Soap", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d10b7bd3-a691-4b78-a5d3-34e7b3d74a9e"), "purple", "Gorgeous Granite Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b74f71a3-236e-47f1-bb30-0ee838b32a0c"), "indigo", "Intelligent Cotton Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d40071db-0a7e-4bee-ae03-73278b368ebb"), "fuchsia", "Gorgeous Frozen Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d799b88f-57f6-4eb1-a0b1-156b893807c8"), "olive", "Practical Fresh Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("48598144-04b3-4fe6-a6e9-62864c7a7deb"), "purple", "Rustic Rubber Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5702a7f7-3f70-417f-85a8-6ad30fa3ce0c"), "tan", "Licensed Steel Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2274d4da-d3be-4305-8b20-23b24ec6c9af"), "cyan", "Incredible Granite Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f536afb5-9c93-4cc1-9c5b-06d6dde7bd45"), "maroon", "Generic Steel Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec3e4747-d3fa-43ec-95bb-6f897dcb4bf4"), "fuchsia", "Practical Steel Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c2e7313f-3997-470a-bb90-e5a3c39673de"), "lavender", "Ergonomic Steel Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("686f65ae-e9fe-494a-835f-4ca69b8ed37f"), "blue", "Incredible Fresh Sausages", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6c4d8063-910c-43bd-999f-e915f7184cb9"), "tan", "Refined Rubber Ball", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3eb33ca0-3704-46b1-93df-8ce19daf49c5"), "purple", "Intelligent Granite Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e4d104b5-bd0e-42c8-8120-219c4c2441c7"), "black", "Awesome Frozen Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67aa40a4-22c2-4263-a39a-aa3ac88ce0cd"), "lime", "Tasty Plastic Computer", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ea911b4d-3e42-446b-bba0-ec295ad4187a"), "maroon", "Small Granite Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("86dfa7d6-d166-45ce-8973-706689ae0970"), "orange", "Ergonomic Frozen Towels", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f61289b2-9202-41d3-a6d5-6be1a812222d"), "grey", "Incredible Fresh Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f51e6507-2f73-4dd8-b952-6f216e85f545"), "cyan", "Intelligent Frozen Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ac6a3a41-2107-4a2e-84bf-4fef58b9e52f"), "red", "Small Wooden Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ec10e990-97c7-4daf-a5e6-a1c6aca9f70c"), "olive", "Tasty Plastic Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d007b1eb-72c0-4e56-8efb-5eb37e2b4d0d"), "tan", "Sleek Rubber Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("1242588f-69d5-40f9-b2d5-e3349c994d4f"), "salmon", "Fantastic Frozen Chair", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("72a2a7e9-d94e-4ea3-b7ec-c80ba322c97d"), "grey", "Rustic Metal Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eea17c0c-e93b-4e4a-8824-82a2162dbaa0"), "pink", "Small Steel Chicken", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("213ef6c5-f718-4445-9a4b-b9e8c9e53324"), "lavender", "Sleek Metal Hat", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4b188480-62e0-4e25-9867-6bffc2a770df"), "black", "Unbranded Metal Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("efd4d96b-f3f9-42ed-9b60-af409d31ab5a"), "maroon", "Licensed Wooden Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ce41555e-0ea8-41a2-bce3-4eb8bc3fdfb4"), "salmon", "Handcrafted Fresh Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("183857bd-a16b-41ee-8df9-75d1ddedfc4c"), "orange", "Gorgeous Frozen Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3e38dcc6-24de-4aed-af02-0ab1b8da7970"), "purple", "Incredible Frozen Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c61dfbda-a506-461d-b81a-292144b95335"), "lavender", "Tasty Rubber Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fdca1bea-953a-4e50-a50b-b85de72b2582"), "violet", "Licensed Wooden Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("63e5bab3-b116-49ae-bad4-a3faa0345987"), "plum", "Handmade Plastic Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("de8b027e-56a6-4802-9acc-50805b8ad98e"), "ivory", "Small Fresh Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("10d30ac6-624f-4966-a5f1-2f81a7a82088"), "salmon", "Ergonomic Fresh Computer", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("67709860-dc95-4a69-be9d-1b2ea9b80cc4"), "olive", "Awesome Wooden Bike", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9e33e1b2-f90f-4c5a-82df-f243067f3f45"), "purple", "Tasty Concrete Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("853c0e9f-a05c-4de4-a4f7-270bb94a16f0"), "silver", "Rustic Rubber Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("087aa9a1-6729-4531-b36b-f34481b60503"), "magenta", "Generic Fresh Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("78e96758-0f86-4df9-b1cc-8fa4522aca49"), "tan", "Tasty Wooden Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("818a3bc1-e6ca-407b-9858-eb012e73fd52"), "silver", "Sleek Wooden Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4e0d14f6-dbe5-43fb-9f8c-f521ed786a42"), "grey", "Fantastic Fresh Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("29649f94-aee0-4549-b119-a618a47bcfb6"), "tan", "Refined Metal Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("175de589-2527-4081-b1eb-64a17fb4c28c"), "tan", "Rustic Concrete Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f05d13e4-7d81-41e7-99b3-b8eed7e1b392"), "tan", "Refined Metal Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0cadf984-f314-4a27-8f33-38d21abb49b1"), "salmon", "Incredible Cotton Mouse", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("73de68e0-e976-435d-95d2-73cd2a14e2aa"), "grey", "Small Rubber Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("9be379de-7d8f-4c77-9691-757e92706908"), "lime", "Handmade Plastic Chair", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7d44a96d-67a7-4e4c-8877-702345a06261"), "lime", "Generic Rubber Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b3fbded2-4d36-4c78-b8cb-b5bce58f7df9"), "olive", "Licensed Plastic Keyboard", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b20cbb69-c67b-4b17-8ec0-f0c20fedd7e8"), "yellow", "Ergonomic Metal Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("51437161-09f7-4cc0-8b51-d435c79660bf"), "black", "Handcrafted Concrete Mouse", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("8580a1af-da0a-44b4-b748-e8a179af370c"), "black", "Licensed Frozen Bacon", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6e4faaff-dc37-4c67-b9c1-e13d8e38e676"), "white", "Practical Concrete Bacon", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3e3e3838-cfda-4874-adf9-359414b7d483"), "lavender", "Licensed Concrete Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bc42d291-261e-4e68-a3bc-824c53f730a8"), "maroon", "Incredible Steel Chicken", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e54ec57b-c275-418e-a70d-497f0e017e83"), "magenta", "Tasty Plastic Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b76b5f56-c7c2-4092-a642-c037096aad58"), "plum", "Fantastic Cotton Ball", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b521d291-70d4-4001-a7ec-05cbcad65160"), "turquoise", "Ergonomic Granite Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c8af09fa-4014-45e5-a38b-fe2ad79a3ff4"), "olive", "Practical Wooden Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("ecf35462-95a1-4eb6-bb60-0cdc800847ab"), "maroon", "Generic Rubber Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bb7cf0e5-504f-4b51-b916-b55c3f383c1b"), "red", "Refined Steel Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fc82e3ce-57fe-4b3f-bdd3-f3a5e9818081"), "blue", "Generic Rubber Cheese", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("95c8f862-87c8-4839-bb80-dc8dea751e89"), "lavender", "Sleek Cotton Keyboard", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("061d9edb-0b85-4016-8282-4bcf39fe9f93"), "sky blue", "Small Frozen Bike", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("32ffc23e-3403-4d2c-8e43-29c4df25cee9"), "azure", "Handmade Granite Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("27e4e950-c051-4b62-89eb-99c02a3624e1"), "grey", "Generic Soft Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f6c59b04-366b-4fcf-a6bb-82ca7d112769"), "orchid", "Practical Cotton Keyboard", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d6b96dbe-bc0e-4210-a0e3-68036598e62c"), "mint green", "Fantastic Wooden Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("655fb138-d11e-4fa5-81f3-55be229fe0bb"), "salmon", "Refined Plastic Tuna", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7cccc8e8-02bd-440c-847f-11d3a7b7f00c"), "teal", "Incredible Rubber Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("509995d5-04bd-40f9-a6eb-7a1c7c76dbcf"), "plum", "Handcrafted Plastic Pants", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("100d24c3-f48d-4d27-9340-f5e1ecdab884"), "plum", "Incredible Steel Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("65c09c9b-fefc-46cb-8492-761dd9bf43ad"), "ivory", "Handcrafted Soft Ball", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b9eebb21-a718-4fbf-ba2d-490fdcbfa102"), "grey", "Rustic Plastic Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2fad329a-5633-4e2a-8857-dd12f236cab0"), "magenta", "Handmade Fresh Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("046c0214-3c9a-4fbc-804e-831215a92c5c"), "lavender", "Fantastic Fresh Bacon", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("304f3c8c-d687-434c-9cd5-c166d367d9ff"), "orchid", "Unbranded Steel Sausages", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("88dea128-155e-4b8b-9f60-4bd5e9970bf1"), "silver", "Small Frozen Bacon", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("71aa67b9-a010-4c35-8cb3-8602afa56f57"), "silver", "Generic Plastic Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("38ac2e36-808c-4093-8420-f180a0af102b"), "teal", "Intelligent Granite Gloves", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("aca5db33-eefc-4710-b99a-772b419955d2"), "green", "Practical Metal Shirt", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("25de8170-4b6a-491a-8d40-f1c348def3b1"), "pink", "Ergonomic Steel Gloves", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("59d9ce13-dca9-4cd6-b56d-8e695dc04920"), "gold", "Handcrafted Wooden Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e698e10c-826b-41dc-9c9f-46d3000c875d"), "pink", "Fantastic Metal Pizza", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("311b72db-cef3-4edb-a468-28ba14b492a5"), "orange", "Rustic Soft Chair", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bbea7f76-6d88-4fc8-865a-1afa00a291dc"), "maroon", "Incredible Granite Car", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5c3ccbf6-ecd7-4357-a7bd-b79882d69f73"), "pink", "Generic Steel Fish", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("76672cdd-a74a-4c79-9050-686fdba3b3ba"), "sky blue", "Intelligent Rubber Salad", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("235f55f4-e6da-4bab-98ef-0684d6140a5c"), "olive", "Small Rubber Shoes", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c285dbdc-1f40-40fe-b3e8-dfbfe9480a54"), "violet", "Sleek Fresh Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3911d662-1948-4cd5-96a4-f9a943e53cfb"), "black", "Sleek Metal Chips", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c3e46e28-b003-4a32-9335-03b6a601865d"), "orchid", "Handcrafted Metal Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("5ce81061-84e0-4c74-9fd4-08782bcf1e6b"), "indigo", "Awesome Frozen Salad", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b65c5803-6e55-499a-9831-d96b9f5641b0"), "lime", "Generic Cotton Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("eec4529e-da56-420c-a89d-992176568531"), "violet", "Handmade Soft Gloves", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("a32ee1ac-4953-422c-af6c-9327c2e3aa03"), "fuchsia", "Awesome Plastic Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b663fa0e-c0c4-4879-929f-307f5ec54013"), "ivory", "Practical Rubber Tuna", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("61c2e749-03d3-44ef-91c9-c7b4276882b2"), "pink", "Tasty Steel Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("6979abaf-b612-4bf7-b346-145c6100c734"), "ivory", "Awesome Rubber Ball", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b7d47746-3c02-433d-be64-44affdf88836"), "azure", "Ergonomic Soft Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("35f2ff7d-96ef-41a4-b6ca-9ee12ce5cac2"), "yellow", "Ergonomic Fresh Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("3b93e23c-4f04-4b42-b722-07e55cbcd11d"), "grey", "Handmade Plastic Hat", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("98fb0e2d-4f6c-42f7-b98b-b3f170ca0542"), "lime", "Fantastic Plastic Bike", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("11757464-ff94-4671-9179-312ddcaeb172"), "tan", "Rustic Cotton Sausages", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("2c5b9fdf-01e5-4c13-82a6-9e905b98b4c1"), "violet", "Generic Concrete Car", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7cdde290-6abf-41b6-9ef2-1f21f7f558f9"), "turquoise", "Ergonomic Rubber Chair", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("106ffa3b-3594-4b5b-8c51-b316a6b4bda7"), "orange", "Fantastic Metal Shoes", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6a04afc-7b78-480a-8418-6ab5ec8c13bc"), "sky blue", "Intelligent Wooden Shirt", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bcd4e5dc-7021-49b9-bbf8-f0f7a33dfa8b"), "grey", "Fantastic Wooden Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4382b55f-ae7c-41d5-b2fd-2a9062a92c06"), "purple", "Licensed Rubber Towels", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("fe0aafe8-02f5-4246-b9cd-16dede8ffaa6"), "yellow", "Generic Rubber Shoes", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("014ae9cd-8036-489a-8926-e8faf883867b"), "indigo", "Handmade Granite Chips", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7c1d4be0-53b2-4682-9b84-192f42ad3dda"), "fuchsia", "Intelligent Rubber Pants", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("c6c7a9c2-82d7-4257-8f1e-a6ac6c3e23e8"), "maroon", "Generic Plastic Fish", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d801155c-fc22-40a2-a4fa-9922ea6e1410"), "lavender", "Unbranded Wooden Table", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0c63f78f-4729-435e-a083-cb9ddbbdcaba"), "violet", "Awesome Wooden Chips", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("82036baf-e244-4574-9251-6bf01370d90f"), "lime", "Tasty Wooden Table", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f89df6b7-62ee-40a1-a270-2f574b368f2a"), "cyan", "Licensed Cotton Chicken", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("b969aafe-4bd0-49f1-8da5-6f3841182b68"), "red", "Handcrafted Concrete Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("7c604ba1-5ae3-472f-bfe1-2da143624895"), "tan", "Licensed Soft Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("e0a1d154-10e0-47db-bbf1-795529be6ce2"), "orchid", "Sleek Soft Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("25fd77da-0612-425f-9197-24778770d212"), "pink", "Sleek Fresh Mouse", "XL" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("824b2bc1-b5fd-4411-91db-48fb35701cd8"), "magenta", "Awesome Rubber Towels", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("4d2970d8-ebb8-4714-a019-064e9820cce9"), "gold", "Ergonomic Wooden Soap", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("bcb1f3be-9246-4f2d-b5d3-72764bf4ad6b"), "salmon", "Gorgeous Metal Pizza", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0727a9cc-151f-43d3-a98b-7144e192e127"), "olive", "Handmade Granite Table", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0cb345e0-c187-4254-b72f-f93f2f51ddc6"), "gold", "Licensed Plastic Shoes", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("128828fe-a8b6-44d1-a0d3-2b9706721952"), "lime", "Ergonomic Frozen Computer", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("319eb9d8-b4c0-47b1-855f-90e2dc81a935"), "grey", "Generic Fresh Chips", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("f56df066-b6f3-468f-8928-bd44db0b36e9"), "violet", "Rustic Metal Sausages", "S" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0a921eb9-392e-4ce3-aded-2c7580a4a7ab"), "violet", "Generic Wooden Car", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("90f76777-8dcf-4543-86c7-3d6c00f68d55"), "teal", "Refined Frozen Soap", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("cb232642-a9bd-4385-a671-2b19165ce42e"), "green", "Small Metal Pizza", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("078c4e96-2c97-4ec8-9a90-5f8f18bcb68c"), "yellow", "Incredible Steel Fish", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("d0c861a5-c368-4fb9-8f4a-41fa0d996386"), "orange", "Ergonomic Steel Salad", "M" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("42a427e9-aa5a-4cbc-9a5a-f8a40b9ae9f7"), "magenta", "Sleek Wooden Hat", "L" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Color", "Name", "Size" },
                values: new object[] { new Guid("0e9d942e-59eb-4751-b180-f2b5763dcf4c"), "fuchsia", "Fantastic Cotton Computer", "L" });

            migrationBuilder.CreateIndex(
                name: "IX_Costumers_FirstName_LastName",
                table: "Costumers",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Costumers");
        }
    }
}
