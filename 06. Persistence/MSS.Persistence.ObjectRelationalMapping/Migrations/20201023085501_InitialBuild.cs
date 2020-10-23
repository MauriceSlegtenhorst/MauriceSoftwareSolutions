using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSS.Persistence.ObjectRelationalMapping.Migrations
{
    public partial class InitialBuild : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreationDateUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModificationDateUTC = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    Affix = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    IsAdmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDateUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModificationDateUTC = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDateUTC = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModificationDateUTC = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    CreditCategoryFK = table.Column<string>(nullable: true),
                    CreditCategoryId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 80, nullable: true),
                    HTMLDescription = table.Column<string>(nullable: true),
                    HTMLMadeBy = table.Column<string>(nullable: false),
                    HTMLGotFrom = table.Column<string>(nullable: false),
                    LinkToImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_CreditCategories_CreditCategoryId",
                        column: x => x.CreditCategoryId,
                        principalTable: "CreditCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CreditCategoryId",
                table: "Credits",
                column: "CreditCategoryId");
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
                name: "Credits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CreditCategories");
        }
    }
}
