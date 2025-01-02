using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotDefterimApi.Data;
using NotDefterimApi.Dtos;

namespace NotDefterimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotlarController : ControllerBase
    {
        private readonly UygulamaDbContext _db;

        public NotlarController(UygulamaDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public List<NotDto> GetNotlar()
        {
            var kullaniciAdi = User.Identity!.Name;

            return _db.Notlar
                .Where(x => x.Kullanici.KullaniciAdi == kullaniciAdi)    
                .Select(x => new NotDto()
                {
                    Id = x.Id,
                    Baslik = x.Baslik,
                    Icerik = x.Icerik
                }).ToList();
        }
    }
}
