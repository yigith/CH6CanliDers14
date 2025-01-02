using Microsoft.EntityFrameworkCore;

namespace NotDefterimApi.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Not> Notlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici()
                {
                    Id = 1,
                    KullaniciAdi = "serhatuzun",
                    Parola = "1907",
                    TuttuguTakim = "Fenerbahçe"
                },
                new Kullanici()
                {
                    Id = 2,
                    KullaniciAdi = "burakozkan",
                    Parola = "kumvarkumvarnebakıonkardes",
                    TuttuguTakim = "Galatasaray"
                },
                new Kullanici()
                {
                    Id = 3,
                    KullaniciAdi = "murataltinisik",
                    Parola = "murat123?",
                    TuttuguTakim = "Fenerbahçe"
                }
            );

            modelBuilder.Entity<Not>().HasData(
                new Not()
                {
                    Id = 1,
                    Baslik = "Cesurlar",
                    Icerik = "hayat cesurları sever",
                    KullaniciId = 1
                },
                new Not()
                {
                    Id = 2,
                    Baslik = "E-Posta",
                    Icerik = "E-Postaları kontrol et",
                    KullaniciId = 1
                },
                new Not()
                {
                    Id = 3,
                    Baslik = "Karaambar müdüriyetine",
                    Icerik = "müdürbey hastalanacak yerine bakılması şart",
                    KullaniciId = 2
                },
                new Not()
                {
                    Id = 4,
                    Baslik = "Sunum",
                    Icerik = "Proje sunumunu hazırla",
                    KullaniciId = 2
                },
                new Not()
                {
                    Id = 5,
                    Baslik = "Fenerbahçe neden hep kaybediyo",
                    Icerik = "oynamayı bilmiyolar",
                    KullaniciId = 3
                },
                new Not()
                {
                    Id = 6,
                    Baslik = "Aşk Acısı",
                    Icerik = "aldanma çocuksu, mahzun yüzüne\r\nmutlaka terkedip gidecek bir gun..",
                    KullaniciId = 3
                }
            );
        }
    }
}
