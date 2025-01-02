using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotDefterimApi.Migrations
{
    /// <inheritdoc />
    public partial class Ilk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuttuguTakim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "KullaniciAdi", "Parola", "TuttuguTakim" },
                values: new object[,]
                {
                    { 1, "serhatuzun", "1907", "Fenerbahçe" },
                    { 2, "burakozkan", "kumvarkumvarnebakıonkardes", "Galatasaray" },
                    { 3, "murataltinisik", "murat123?", "Fenerbahçe" }
                });

            migrationBuilder.InsertData(
                table: "Notlar",
                columns: new[] { "Id", "Baslik", "Icerik", "KullaniciId" },
                values: new object[,]
                {
                    { 1, "Cesurlar", "hayat cesurları sever", 1 },
                    { 2, "E-Posta", "E-Postaları kontrol et", 1 },
                    { 3, "Karaambar müdüriyetine", "müdürbey hastalanacak yerine bakılması şart", 2 },
                    { 4, "Sunum", "Proje sunumunu hazırla", 2 },
                    { 5, "Fenerbahçe neden hep kaybediyo", "oynamayı bilmiyolar", 3 },
                    { 6, "Aşk Acısı", "aldanma çocuksu, mahzun yüzüne\r\nmutlaka terkedip gidecek bir gun..", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notlar_KullaniciId",
                table: "Notlar",
                column: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
