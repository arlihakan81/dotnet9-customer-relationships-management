using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCitiesAndCountriesTablesAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IsActive", "Name", "PhoneCode" },
                values: new object[,]
                {
                    { new Guid("132144df-5225-4408-826d-fcc378c0f74f"), "TR", true, "Türkiye", "+90" },
                    { new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), "GB", true, "İngiltere", "+44" },
                    { new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), "US", true, "Amerika Birleşik Devletleri", "+1" },
                    { new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), "FR", true, "Fransa", "+33" },
                    { new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), "DE", true, "Almanya", "+49" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CountryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("0088610b-1c8c-4ecd-8b8f-e0ce33c43e20"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Los Angeles" },
                    { new Guid("03456984-e0c9-4333-9762-8f2795bcd4aa"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Duisburg" },
                    { new Guid("0568abe7-ec7d-474d-9048-2d339531bf4c"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Trabzon" },
                    { new Guid("07a91c4e-c934-429b-8df5-6702f0cd914f"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Kütahya" },
                    { new Guid("19331d5c-9a11-492e-a854-dbaeff3ecb6f"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Adana" },
                    { new Guid("1946c5c9-1918-4f01-b771-b0507bccad87"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Nevşehir" },
                    { new Guid("1a391c42-5792-4fb6-a554-d007a3d14361"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Angers" },
                    { new Guid("1d259b43-3f3d-44e5-9e07-3b4ca1b34ffc"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Newcastle" },
                    { new Guid("1d956265-f939-41a4-858e-ca1b89fac2e7"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "San Antonio" },
                    { new Guid("1dc11c27-0909-4492-b09f-bf6f1d4c6122"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Denizli" },
                    { new Guid("1eeab416-36f9-4243-ba86-e7466dab1147"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Nantes" },
                    { new Guid("1f76975a-2b82-48ec-a49c-d1b9aa10989e"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Sivas" },
                    { new Guid("203a3d68-fa7a-4cc0-9ab8-7fcc6a0cdad2"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Dallas" },
                    { new Guid("259282bb-fa7a-43e9-b55e-cd5a6e7bbe38"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Köln" },
                    { new Guid("25a6ddce-b444-4328-af59-6a2c3e06966b"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Hamburg" },
                    { new Guid("2dc8fd0a-db77-4f63-9b0b-92f119325748"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Leicester" },
                    { new Guid("2ecf7973-0591-43db-839d-85122da9d380"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Berlin" },
                    { new Guid("332325b1-a6d8-453e-8b23-341bace22dab"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Aksaray" },
                    { new Guid("37518f8c-4edc-49d1-9a4f-f7897adaed02"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Uşak" },
                    { new Guid("39569c67-b536-43b7-abcb-37ca622ef90e"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Nîmes" },
                    { new Guid("3f721690-7919-4295-8481-4f6ac41bb921"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Charlotte" },
                    { new Guid("3f9899cb-a03a-4a15-8482-d021b773db44"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Mannheim" },
                    { new Guid("3fc8d333-6b4c-4a1e-8c9d-e521bcb48c78"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Strazburg" },
                    { new Guid("4259c332-50a3-4c82-832c-9b57fc713bde"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Bursa" },
                    { new Guid("44aa8553-413e-4b76-bac0-62d55ee286e5"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Antalya" },
                    { new Guid("45aba4d7-d7e4-4dd7-b837-32bc98a49079"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Toulon" },
                    { new Guid("46b2de2c-8dcd-4485-bb20-bef2214b2d02"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Marsilya" },
                    { new Guid("49894086-5e32-4611-a8d8-4d6458a55d8a"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Mersin" },
                    { new Guid("4ae0ad6e-2875-4dca-af71-fe26fdc31499"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Clermont-Ferrand" },
                    { new Guid("4ddba39d-c99f-43ed-a87a-c40a5358f934"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Kırşehir" },
                    { new Guid("4e3ea7f4-5d32-4772-b7cc-34561a15aefe"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Kayseri" },
                    { new Guid("4e40c7bb-8190-4aec-8c2d-519c08218462"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Münih" },
                    { new Guid("4e5fc982-4641-4ec2-b85c-33949b9b7366"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Saint-Étienne" },
                    { new Guid("4f9b6cc8-5576-475a-b088-498985e656bb"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Ankara" },
                    { new Guid("506d6742-06c2-493c-8e38-27d8fc217545"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Liverpool" },
                    { new Guid("52ecad15-b70b-40f7-a9bd-0565af94ad7c"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Manchester" },
                    { new Guid("5579f22c-9b76-42a8-a4bd-fab8f45c4e52"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Columbus" },
                    { new Guid("578151c6-4e76-4d41-8489-af8ce7b0d1cf"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Nice" },
                    { new Guid("5ab988ec-f87f-4f43-ae8c-cf25ee072040"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Sheffield" },
                    { new Guid("5ba0f0d1-ab69-4aa7-8fad-d30203aaccdb"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Gaziantep" },
                    { new Guid("5e9a6eeb-e3f0-4a1d-a9b8-2adc5f500c6d"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Tours" },
                    { new Guid("603bc9c5-3c82-41f8-94f4-b69b63adea5d"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "İzmir" },
                    { new Guid("616cb9d3-e807-45a5-b006-2e34b421d97d"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Reims" },
                    { new Guid("63cd73bc-62ff-493c-bb2d-f52536d1d13e"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Düsseldorf" },
                    { new Guid("642e9d3b-0446-462d-a274-614e43060933"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "San Diego" },
                    { new Guid("6595a174-1ac5-4237-81af-42dbbd015b07"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Brest" },
                    { new Guid("66673ebf-97e8-4ff7-940c-b9044d84d835"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Jacksonville" },
                    { new Guid("6788c496-0bba-4635-82da-af4590052aa8"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Malatya" },
                    { new Guid("6d6bce59-8f2b-45a1-a3cf-b87a1fa84544"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Phoenix" },
                    { new Guid("709a09b7-5545-4f19-bf84-c7222a193762"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Essen" },
                    { new Guid("781e2dac-ac41-4b8b-9463-889a1e8766ac"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Bremen" },
                    { new Guid("7c4868e4-d950-432d-b5ab-5243007387d5"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Niğde" },
                    { new Guid("81d7abc9-e37a-40da-882b-5a1b5fd44da2"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Wuppertal" },
                    { new Guid("821d5944-0d99-4c09-8c15-b215326f16a2"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "New York" },
                    { new Guid("8285a86a-e310-4e6d-864d-fa0fc0bd2a00"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Bristol" },
                    { new Guid("8364063c-c2f6-4866-a2ef-21faad0b4099"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Grenoble" },
                    { new Guid("855cd093-f688-475a-9879-1d22548b1ad3"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Bielefeld" },
                    { new Guid("861f2ec4-cfae-4cca-adbf-997f594b8b54"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Van" },
                    { new Guid("8907022e-3df6-49f8-82c9-4dc6b1cf4615"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Lille" },
                    { new Guid("8a0a6a77-fe06-43f4-b877-ac0b01e2c669"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Birmingham" },
                    { new Guid("8d0e2826-254e-4d21-a2c1-24267befe436"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Kocaeli" },
                    { new Guid("8df339bb-d6a9-46d8-9d9c-0c6ad1494e0a"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Aydın" },
                    { new Guid("8ed3ff06-ed09-416f-9273-2e84c7d6ef6b"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Nottingham" },
                    { new Guid("91f8e6ee-2809-46b0-bf42-c18960b5c96b"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Stuttgart" },
                    { new Guid("96f98ebf-826c-4f36-b27b-03bab2afa113"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Fort Worth" },
                    { new Guid("9846e683-7f10-4748-b998-91d50d211590"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Leeds" },
                    { new Guid("997d87c4-26d5-424f-9519-6b9c06766950"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Rennes" },
                    { new Guid("9c27d03e-4b20-44ef-ab5b-b505daad655e"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Bonn" },
                    { new Guid("9e2cc3dc-d201-4e89-86e4-9558ee6afee3"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Bradford" },
                    { new Guid("a0b5e21f-8381-4d72-959f-6bf68fc911de"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Londra" },
                    { new Guid("a1abf398-d027-4870-bcda-631057e9591d"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Philadelphia" },
                    { new Guid("a7287e8f-9131-4ce1-b68a-139d1626215f"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Villeurbanne" },
                    { new Guid("a7e795d5-7f69-4b6c-b86f-befd65a4c4cc"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Bochum" },
                    { new Guid("a7ee2d0d-4807-4ce1-82e4-20af30e6b74a"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Le Havre" },
                    { new Guid("aa406209-fcf1-431d-aaf7-53ca4b246326"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Dresden" },
                    { new Guid("aebae0b7-7909-4540-95c1-f2a4a243a317"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Samsun" },
                    { new Guid("bcc8279c-ace7-493f-8d6d-4068bfbab187"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Houston" },
                    { new Guid("bd1d490b-4818-425a-a08b-79f33faad0d0"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Dortmund" },
                    { new Guid("be759822-e3ea-4b94-9343-770bfc3b4243"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Eskişehir" },
                    { new Guid("be9e6d13-1d73-492d-a28b-a54049d34fee"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Austin" },
                    { new Guid("c2ca97d4-b1b5-4a9a-a3ad-d371bb0dbe05"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Belfast" },
                    { new Guid("c41c269a-2b51-456a-877b-08f06d2db633"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Sunderland" },
                    { new Guid("c95e0848-3396-4d65-8a12-5decfe1904c9"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Aix-en-Provence" },
                    { new Guid("ce02cf54-98b9-4b19-a135-64e777abd8cc"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Toulouse" },
                    { new Guid("cefe0767-484f-4ea8-9fe5-733b46cff5da"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "İstanbul" },
                    { new Guid("d0a3935e-18df-496b-82fa-959dbd08a1f9"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Lyon" },
                    { new Guid("d0df355c-97a8-4df8-954f-51421080c1bc"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Balıkesir" },
                    { new Guid("d132cdb6-5f6d-4402-a509-ef85f82ac0c0"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Nürnberg" },
                    { new Guid("d161cd9e-e4d9-4990-bf01-4cff8b8d4219"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Konya" },
                    { new Guid("dcb3eb7f-9f2c-4e20-a669-830c8a821f35"), "", new Guid("1b1da575-eabe-4d8c-8c29-daa4ab7f5432"), true, "Coventry" },
                    { new Guid("ddbb6019-b778-49e5-859a-a1167fc61954"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Leipzig" },
                    { new Guid("e85267ec-f437-4693-b516-dc08a174a6e4"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Le Mans" },
                    { new Guid("ea2a1e7d-b0d8-4dcc-aa71-09da69438317"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Sakarya" },
                    { new Guid("ea9fbf79-53a2-4a8b-9ba1-eaf9c288c286"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "San Jose" },
                    { new Guid("f0da3d2c-489c-46bd-92c1-798dd2c95e84"), "", new Guid("132144df-5225-4408-826d-fcc378c0f74f"), true, "Erzurum" },
                    { new Guid("f1132f1a-c96c-4d15-80f1-f16dbf1b76a9"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Hannover" },
                    { new Guid("f37ccf52-73d1-41e2-8e2f-68a6ca23b7d1"), "", new Guid("45bfd61d-9433-4471-9465-bd1baa24b7ef"), true, "Chicago" },
                    { new Guid("f566dbba-1f6a-42a2-b93f-2f24111a7aac"), "", new Guid("bfc27405-1111-42d8-8888-1292364f5c42"), true, "Frankfurt" },
                    { new Guid("f59491f9-1949-4652-919d-6de0bbd778bf"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Dijon" },
                    { new Guid("f7a3baf5-6dd9-4171-a993-4da9232d5c94"), "", new Guid("72f3a930-add3-484a-af1a-9a9d61785ec4"), true, "Paris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Countries_CountryId",
                table: "Companies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_CityId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Countries_CountryId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CityId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CountryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
