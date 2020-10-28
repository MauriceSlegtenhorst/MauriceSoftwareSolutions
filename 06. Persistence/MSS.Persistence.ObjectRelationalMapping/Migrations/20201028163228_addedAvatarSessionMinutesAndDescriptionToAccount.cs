using Microsoft.EntityFrameworkCore.Migrations;

namespace MSS.Persistence.ObjectRelationalMapping.Migrations
{
    public partial class addedAvatarSessionMinutesAndDescriptionToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a652007-2b59-442d-9948-23234713abde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5875237-3e18-4a3f-a194-f9420180c365");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "20d5598f-d724-46c0-8e95-d8cdfc983b4a", "89117d00-9da7-48ef-8672-220ce82df13c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3af3698b-80b5-41d3-8df6-741b0fdc5af5", "89117d00-9da7-48ef-8672-220ce82df13c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "62e6f1b4-95fc-4a4b-843d-28aaac1941ad", "411f2bc3-5ea0-4877-aa67-b15846c44a5e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6e528c37-afb7-474a-bbe4-5a8e9e24d20b", "bb41cb6d-e04a-4fba-82df-d4a501109fbe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d0dbd5a1-2521-4003-bfb2-b877a1ce90f4", "99f1c328-4932-4b6b-a354-519fcd46ce19" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e1bc4584-7092-4b9d-a0b7-f1d5c6e50b65", "89117d00-9da7-48ef-8672-220ce82df13c" });

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "Id",
                keyValue: "23c10c40-f245-440c-b62c-73d83cf76b45");

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "Id",
                keyValue: "d108ec3f-71f4-4a51-828e-7e04b61f6cd2");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "2f28bfa3-19a8-49b8-a157-81b39b4c3a97");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "5ebd0afa-4a30-4485-a52d-f72ecb4eda7b");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "64459974-6426-4b70-8ec1-6d6a27c08e20");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "c0866589-ebcb-4b6b-8f63-7df50fbdb284");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "411f2bc3-5ea0-4877-aa67-b15846c44a5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89117d00-9da7-48ef-8672-220ce82df13c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99f1c328-4932-4b6b-a354-519fcd46ce19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb41cb6d-e04a-4fba-82df-d4a501109fbe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20d5598f-d724-46c0-8e95-d8cdfc983b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3af3698b-80b5-41d3-8df6-741b0fdc5af5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62e6f1b4-95fc-4a4b-843d-28aaac1941ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e528c37-afb7-474a-bbe4-5a8e9e24d20b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d0dbd5a1-2521-4003-bfb2-b877a1ce90f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1bc4584-7092-4b9d-a0b7-f1d5c6e50b65");

            migrationBuilder.AddColumn<string>(
                name: "AvatarLink",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HTMLDescription",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionTimeMinutes",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57", "a102ed38-3ad9-432c-a435-9cdfbdabf630", "Administrator", "ADMINISTRATOR" },
                    { "af9961f5-cd2e-4664-a20c-c5be32cb0125", "7cc82936-905c-4fd3-af9a-d8018e0395ec", "Employee", "EMPLOYEE" },
                    { "c55a5d82-7454-4205-a53a-fa6608723ecb", "439d6c4c-bdcb-4077-9c35-da71c387bb49", "Volenteer", "VOLENTEER" },
                    { "34e49450-a541-419d-8877-b1ebc5e75139", "6747ca20-1f08-4f15-98b9-9efaa6b7cb6a", "PrivilegedUser", "PRIVILEGEDUSER" },
                    { "f57b1b17-7225-4820-ad10-9bfc0a5ff0ef", "f63212df-4bf6-4906-b5ff-1754c1c294e7", "StandardUser", "STANDARDUSER" },
                    { "b1369f51-9042-4a57-82d1-ec43f75cd38e", "9236505b-0088-445e-be3b-f4066f60f621", "PrivilegedEmployee", "PRIVILEGEDEMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Affix", "AvatarLink", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "HTMLDescription", "IsAdmitted", "LastName", "LockoutEnabled", "LockoutEnd", "ModificationDateUTC", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SessionTimeMinutes", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4cdceea4-bd1b-4fdd-b7f5-6cdbae25f6bd", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "f6578eb4-5409-4e3f-8ac4-4b0dbf61ceb1", "standarduser01@mss.nl", true, "StandardUser_01", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "None", true, null, null, "STANDARDUSER01@MSS.NL", "STANDARDUSER01@MSS.NL", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "060000073565", true, "c4af593e-aecb-44c6-a936-44f574e359fe", 10, false, "standarduser01@mss.nl" },
                    { "737ef0f7-2b06-437b-9803-0337cab0087b", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "595f798f-8a62-4b67-9884-c278314987d1", "employee01@mss.nl", true, "Employee_01", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "None", true, null, null, "EMPLOYEE01@MSS.NL", "EMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "060000729371", true, "5d8a93af-f0f4-4b73-b68e-b6475446f814", 10, false, "employee01@mss.nl" },
                    { "039b8205-9888-478e-a68d-5dd53030de40", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "f9dd0c8e-12fd-47bb-b9a4-575db7ac3ad3", "privilegedemployee01@mss.nl", true, "PrivilegedEmployee_01", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "None", true, null, null, "PRIVILEGEDEMPLOYEE01@MSS.NL", "PRIVILEGEDEMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "060000613018", true, "983faa56-fbcc-42b6-ba2c-27b906bafc7b", 10, false, "privilegedemployee01@mss.nl" },
                    { "93420010-a0f1-4861-9188-971bc75236c0", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "d53194ca-35e6-4049-96f4-07dd018c3440", "hanneke.slegtenhorst1@gmail.com", true, "Hanneke", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "Slegtenhorst", true, null, null, "HANNEKE.SLEGTENHORST1@GMAIL.COM", "HANNEKE.SLEGTENHORST1@GMAIL.COM", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "060000210826", true, "de7d5489-2776-41f8-82d0-72de2a69052b", 10, false, "hanneke.slegtenhorst1@gmail.com" },
                    { "ffff255c-4499-4cef-92fb-6965e83370f6", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "f199b8ab-7607-4d08-a1c1-56dc3f696b50", "maurice.slegtenhorst@outlook.com", true, "Maurice", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "Slegtenhorst", true, null, null, "MAURICE.SLEGTENHORST@OUTLOOK.COM", "MAURICE.SLEGTENHORST@OUTLOOK.COM", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "0645377536", true, "3feddadf-d954-4264-8c6d-2de27faac393", 10, false, "maurice.slegtenhorst@outlook.com" },
                    { "18636492-975a-4917-a3ee-2b7794672251", 0, null, "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg", "27884315-9915-4157-9286-7b67a14ce4fe", "mauricesoftwaresolution@outlook.com", true, "Maurice", "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>", true, "Slegtenhorst", true, null, null, "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "AQAAAAEAACcQAAAAEAYzvSEjXHpeBksADojyfhWipzFSJ2cVxoTKtkNkZpn7Tkl41u16FSpBKOLF0MI8ww==", "0645377536", true, "8fcc2316-1305-481c-ba8d-e83f3850c012", 10, false, "mauricesoftwaresolution@outlook.com" }
                });

            migrationBuilder.InsertData(
                table: "CreditCategories",
                columns: new[] { "Id", "Description", "ModificationDateUTC", "SubTitle", "Title" },
                values: new object[,]
                {
                    { "3a76466f-24f4-4abc-bf20-3b4d04f5ab6a", null, null, "Sources that helped me gaining knowledge  about programming related subjects", "Food for the brain" },
                    { "452c9c48-2535-460f-af33-df8292dd13d2", null, null, "Sources that made UI development easier", "Don't reinvent the wheel" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "Id", "CreditCategoryFK", "CreditCategoryId", "HTMLDescription", "HTMLGotFrom", "HTMLMadeBy", "LinkToImage", "ModificationDateUTC", "SubTitle", "Title" },
                values: new object[,]
                {
                    { "144dd825-c8ca-4344-82e4-ef2c291e5a89", "3a76466f-24f4-4abc-bf20-3b4d04f5ab6a", null, "<p>Pluralsight has helped me better understand software architecture and desighn patterns. The video's are very thorough and helpfull. One thing is that there is so much info that sometimes it takes long to find something specific.</p>", "ITvitae giving me an account on <a href='https://www.pluralsight.com/'>Pluralsight</a>", "<a href='https://www.pluralsight.com/content/pluralsight/en/about/jcr:content/main/generic_block_167843627/parsys/columns/column-parsys-1/executive/parsys/executive_member/gridimage-res.img.75734133-ac30-41ab-8e2a-4b7033ca7e10.jpg'>CEO Aaron Skonnard</a>", "https://pbs.twimg.com/profile_images/1291779527576653824/vifRmgyc.jpg", null, "Best educational video streaming service", "Pluralsight" },
                    { "082a64c1-712b-4f96-8ff9-46eca9e9baeb", "3a76466f-24f4-4abc-bf20-3b4d04f5ab6a", null, "<p>Tim Corey provides many educational video's and tutorials about programming. His content is focused on C# but he covers other languages too. His goal is to make learning C# easier. Awesome guy.</p>", "Searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#", "<a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>", "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4", null, "Youtuber with the best C# tuturials", "Tim Corey" },
                    { "8b271d71-2c29-42a6-9e08-0248a1d6dde5", "3a76466f-24f4-4abc-bf20-3b4d04f5ab6a", null, "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>", "<a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>", "<a href='https://useiconic.com/open'>Open-Iconic</a>", "https://img.stackshare.io/service/3029/iconic.png", null, "Provider of fonts and icons", "Open Iconic" },
                    { "c0719349-3072-48bc-8b68-a44e20879456", "452c9c48-2535-460f-af33-df8292dd13d2", null, "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>", "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>", "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>", "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png", null, "Easy to use premade Blazor components", "Syncfusion" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "4cdceea4-bd1b-4fdd-b7f5-6cdbae25f6bd", "f57b1b17-7225-4820-ad10-9bfc0a5ff0ef" },
                    { "737ef0f7-2b06-437b-9803-0337cab0087b", "af9961f5-cd2e-4664-a20c-c5be32cb0125" },
                    { "039b8205-9888-478e-a68d-5dd53030de40", "b1369f51-9042-4a57-82d1-ec43f75cd38e" },
                    { "ffff255c-4499-4cef-92fb-6965e83370f6", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" },
                    { "18636492-975a-4917-a3ee-2b7794672251", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" },
                    { "93420010-a0f1-4861-9188-971bc75236c0", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34e49450-a541-419d-8877-b1ebc5e75139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c55a5d82-7454-4205-a53a-fa6608723ecb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "039b8205-9888-478e-a68d-5dd53030de40", "b1369f51-9042-4a57-82d1-ec43f75cd38e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "18636492-975a-4917-a3ee-2b7794672251", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4cdceea4-bd1b-4fdd-b7f5-6cdbae25f6bd", "f57b1b17-7225-4820-ad10-9bfc0a5ff0ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "737ef0f7-2b06-437b-9803-0337cab0087b", "af9961f5-cd2e-4664-a20c-c5be32cb0125" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "93420010-a0f1-4861-9188-971bc75236c0", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ffff255c-4499-4cef-92fb-6965e83370f6", "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57" });

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "Id",
                keyValue: "3a76466f-24f4-4abc-bf20-3b4d04f5ab6a");

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "Id",
                keyValue: "452c9c48-2535-460f-af33-df8292dd13d2");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "082a64c1-712b-4f96-8ff9-46eca9e9baeb");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "144dd825-c8ca-4344-82e4-ef2c291e5a89");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "8b271d71-2c29-42a6-9e08-0248a1d6dde5");

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "Id",
                keyValue: "c0719349-3072-48bc-8b68-a44e20879456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c6f6617-d4ef-4eb7-8d47-9c89fd944f57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af9961f5-cd2e-4664-a20c-c5be32cb0125");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1369f51-9042-4a57-82d1-ec43f75cd38e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f57b1b17-7225-4820-ad10-9bfc0a5ff0ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "039b8205-9888-478e-a68d-5dd53030de40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18636492-975a-4917-a3ee-2b7794672251");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cdceea4-bd1b-4fdd-b7f5-6cdbae25f6bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "737ef0f7-2b06-437b-9803-0337cab0087b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93420010-a0f1-4861-9188-971bc75236c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffff255c-4499-4cef-92fb-6965e83370f6");

            migrationBuilder.DropColumn(
                name: "AvatarLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HTMLDescription",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SessionTimeMinutes",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89117d00-9da7-48ef-8672-220ce82df13c", "44c5f1c1-58a4-4c8e-9566-3a9c6d9ba19c", "Administrator", "ADMINISTRATOR" },
                    { "bb41cb6d-e04a-4fba-82df-d4a501109fbe", "7d36e474-ea2d-4db2-8bb5-61810a6d8e0d", "Employee", "EMPLOYEE" },
                    { "b5875237-3e18-4a3f-a194-f9420180c365", "e34eb78a-64fd-4d32-9506-6a00d08f0079", "Volenteer", "VOLENTEER" },
                    { "9a652007-2b59-442d-9948-23234713abde", "b838b45a-572e-4060-a17b-de25aece38f3", "PrivilegedUser", "PRIVILEGEDUSER" },
                    { "99f1c328-4932-4b6b-a354-519fcd46ce19", "274c76ae-562f-4793-828d-3f21718d5ffe", "StandardUser", "STANDARDUSER" },
                    { "411f2bc3-5ea0-4877-aa67-b15846c44a5e", "e1666af2-45bb-4982-8c1b-a825d91e871c", "PrivilegedEmployee", "PRIVILEGEDEMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Affix", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmitted", "LastName", "LockoutEnabled", "LockoutEnd", "ModificationDateUTC", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d0dbd5a1-2521-4003-bfb2-b877a1ce90f4", 0, null, "fddde952-2948-49e0-acdb-79c18ae6f3b4", "standarduser01@mss.nl", true, "StandardUser_01", true, "None", true, null, null, "STANDARDUSER01@MSS.NL", "STANDARDUSER01@MSS.NL", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "060026515782", true, "8748c8ab-2cc4-4229-a48a-d704f254f821", false, "standarduser01@mss.nl" },
                    { "6e528c37-afb7-474a-bbe4-5a8e9e24d20b", 0, null, "5cd5c5eb-453c-4f7b-8485-2616d66fd1d7", "employee01@mss.nl", true, "Employee_01", true, "None", true, null, null, "EMPLOYEE01@MSS.NL", "EMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "060089732641", true, "559b89b7-f246-4cf4-9ef3-781cadcdcd10", false, "employee01@mss.nl" },
                    { "62e6f1b4-95fc-4a4b-843d-28aaac1941ad", 0, null, "1f7246a3-a735-4a05-ae41-b028a4639c21", "privilegedemployee01@mss.nl", true, "PrivilegedEmployee_01", true, "None", true, null, null, "PRIVILEGEDEMPLOYEE01@MSS.NL", "PRIVILEGEDEMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "060009960925", true, "0d57f85d-2093-4885-8a13-4aef55690350", false, "privilegedemployee01@mss.nl" },
                    { "e1bc4584-7092-4b9d-a0b7-f1d5c6e50b65", 0, null, "43e437f6-c961-4319-8ad9-f0d1c7e5b26b", "hanneke.slegtenhorst1@gmail.com", true, "Hanneke", true, "Slegtenhorst", true, null, null, "HANNEKE.SLEGTENHORST1@GMAIL.COM", "HANNEKE.SLEGTENHORST1@GMAIL.COM", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "060032679792", true, "d7ee83e7-79e9-451e-825b-9cbf9351a5be", false, "hanneke.slegtenhorst1@gmail.com" },
                    { "20d5598f-d724-46c0-8e95-d8cdfc983b4a", 0, null, "bea99a71-014f-44ba-aa28-593c072d72ba", "maurice.slegtenhorst@outlook.com", true, "Maurice", true, "Slegtenhorst", true, null, null, "MAURICE.SLEGTENHORST@OUTLOOK.COM", "MAURICE.SLEGTENHORST@OUTLOOK.COM", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "0645377536", true, "ebb81d6b-8cd2-4fa5-b56b-adbba6d20f6d", false, "maurice.slegtenhorst@outlook.com" },
                    { "3af3698b-80b5-41d3-8df6-741b0fdc5af5", 0, null, "8bdeb224-7ef6-4fd2-8bca-1804fb3e14e5", "mauricesoftwaresolution@outlook.com", true, "Maurice", true, "Slegtenhorst", true, null, null, "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "AQAAAAEAACcQAAAAEBagDji8zpO0r7B54U0YvmEUuG28Jf3uBJzuE/GecANeaqLt6/hp+mziYGJQre+FZg==", "0645377536", true, "b39b5dd4-2891-4120-979c-e93aea777ad5", false, "mauricesoftwaresolution@outlook.com" }
                });

            migrationBuilder.InsertData(
                table: "CreditCategories",
                columns: new[] { "Id", "Description", "ModificationDateUTC", "SubTitle", "Title" },
                values: new object[,]
                {
                    { "d108ec3f-71f4-4a51-828e-7e04b61f6cd2", null, null, "Sources that helped me gaining knowledge  about programming related subjects", "Food for the brain" },
                    { "23c10c40-f245-440c-b62c-73d83cf76b45", null, null, "Sources that made UI development easier", "Don't reinvent the wheel" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "Id", "CreditCategoryFK", "CreditCategoryId", "HTMLDescription", "HTMLGotFrom", "HTMLMadeBy", "LinkToImage", "ModificationDateUTC", "SubTitle", "Title" },
                values: new object[,]
                {
                    { "5ebd0afa-4a30-4485-a52d-f72ecb4eda7b", "d108ec3f-71f4-4a51-828e-7e04b61f6cd2", null, "<p>Pluralsight has helped me better understand software architecture and desighn patterns. The video's are very thorough and helpfull. One thing is that there is so much info that sometimes it takes long to find something specific.</p>", "ITvitae giving me an account on <a href='https://www.pluralsight.com/'>Pluralsight</a>", "<a href='https://www.pluralsight.com/content/pluralsight/en/about/jcr:content/main/generic_block_167843627/parsys/columns/column-parsys-1/executive/parsys/executive_member/gridimage-res.img.75734133-ac30-41ab-8e2a-4b7033ca7e10.jpg'>CEO Aaron Skonnard</a>", "https://pbs.twimg.com/profile_images/1291779527576653824/vifRmgyc.jpg", null, "Best educational video streaming service", "Pluralsight" },
                    { "c0866589-ebcb-4b6b-8f63-7df50fbdb284", "d108ec3f-71f4-4a51-828e-7e04b61f6cd2", null, "<p>Tim Corey provides many educational video's and tutorials about programming. His content is focused on C# but he covers other languages too. His goal is to make learning C# easier. Awesome guy.</p>", "Searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#", "<a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>", "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4", null, "Youtuber with the best C# tuturials", "Tim Corey" },
                    { "64459974-6426-4b70-8ec1-6d6a27c08e20", "d108ec3f-71f4-4a51-828e-7e04b61f6cd2", null, "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>", "<a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>", "<a href='https://useiconic.com/open'>Open-Iconic</a>", "https://img.stackshare.io/service/3029/iconic.png", null, "Provider of fonts and icons", "Open Iconic" },
                    { "2f28bfa3-19a8-49b8-a157-81b39b4c3a97", "23c10c40-f245-440c-b62c-73d83cf76b45", null, "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>", "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>", "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>", "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png", null, "Easy to use premade Blazor components", "Syncfusion" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "d0dbd5a1-2521-4003-bfb2-b877a1ce90f4", "99f1c328-4932-4b6b-a354-519fcd46ce19" },
                    { "6e528c37-afb7-474a-bbe4-5a8e9e24d20b", "bb41cb6d-e04a-4fba-82df-d4a501109fbe" },
                    { "62e6f1b4-95fc-4a4b-843d-28aaac1941ad", "411f2bc3-5ea0-4877-aa67-b15846c44a5e" },
                    { "20d5598f-d724-46c0-8e95-d8cdfc983b4a", "89117d00-9da7-48ef-8672-220ce82df13c" },
                    { "3af3698b-80b5-41d3-8df6-741b0fdc5af5", "89117d00-9da7-48ef-8672-220ce82df13c" },
                    { "e1bc4584-7092-4b9d-a0b7-f1d5c6e50b65", "89117d00-9da7-48ef-8672-220ce82df13c" }
                });
        }
    }
}
