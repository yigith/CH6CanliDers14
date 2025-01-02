namespace NotDefterimApi.Data
{
    public class Not
    {
        public int Id { get; set; }

        public string Baslik { get; set; } = "";

        public string Icerik { get; set; } = "";

        public int KullaniciId { get; set; }


        public Kullanici Kullanici { get; set; } = null!;
    }
}
