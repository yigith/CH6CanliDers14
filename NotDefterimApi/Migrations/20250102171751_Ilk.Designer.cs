﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotDefterimApi.Data;

#nullable disable

namespace NotDefterimApi.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20250102171751_Ilk")]
    partial class Ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NotDefterimApi.Data.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TuttuguTakim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KullaniciAdi = "serhatuzun",
                            Parola = "1907",
                            TuttuguTakim = "Fenerbahçe"
                        },
                        new
                        {
                            Id = 2,
                            KullaniciAdi = "burakozkan",
                            Parola = "kumvarkumvarnebakıonkardes",
                            TuttuguTakim = "Galatasaray"
                        },
                        new
                        {
                            Id = 3,
                            KullaniciAdi = "murataltinisik",
                            Parola = "murat123?",
                            TuttuguTakim = "Fenerbahçe"
                        });
                });

            modelBuilder.Entity("NotDefterimApi.Data.Not", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Notlar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Baslik = "Cesurlar",
                            Icerik = "hayat cesurları sever",
                            KullaniciId = 1
                        },
                        new
                        {
                            Id = 2,
                            Baslik = "E-Posta",
                            Icerik = "E-Postaları kontrol et",
                            KullaniciId = 1
                        },
                        new
                        {
                            Id = 3,
                            Baslik = "Karaambar müdüriyetine",
                            Icerik = "müdürbey hastalanacak yerine bakılması şart",
                            KullaniciId = 2
                        },
                        new
                        {
                            Id = 4,
                            Baslik = "Sunum",
                            Icerik = "Proje sunumunu hazırla",
                            KullaniciId = 2
                        },
                        new
                        {
                            Id = 5,
                            Baslik = "Fenerbahçe neden hep kaybediyo",
                            Icerik = "oynamayı bilmiyolar",
                            KullaniciId = 3
                        },
                        new
                        {
                            Id = 6,
                            Baslik = "Aşk Acısı",
                            Icerik = "aldanma çocuksu, mahzun yüzüne\r\nmutlaka terkedip gidecek bir gun..",
                            KullaniciId = 3
                        });
                });

            modelBuilder.Entity("NotDefterimApi.Data.Not", b =>
                {
                    b.HasOne("NotDefterimApi.Data.Kullanici", "Kullanici")
                        .WithMany("Notlar")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("NotDefterimApi.Data.Kullanici", b =>
                {
                    b.Navigation("Notlar");
                });
#pragma warning restore 612, 618
        }
    }
}
