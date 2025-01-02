namespace NotDefterimApi.Data
{
    public class Kullanici
    {
        public int Id { get; set; }

        public string KullaniciAdi { get; set; } = "";

        public string Parola { get; set; } = "";

        public string? TuttuguTakim { get; set; }


        public List<Not> Notlar { get; set; } = new();
    }
}
