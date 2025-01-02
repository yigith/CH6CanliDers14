using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NotDefterimApi.Data;
using NotDefterimApi.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotDefterimApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirisController : ControllerBase
    {
        private readonly UygulamaDbContext _db;
        private readonly IConfiguration _config;

        public GirisController(UygulamaDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost]
        public IActionResult PostGiris(GirisDto dto)
        {
            var kullanici = _db.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == dto.KullaniciAdi && k.Parola == dto.Parola);

            if (kullanici == null)
            {
                return BadRequest("Kullanıcı adı veya parola hatalı!");
            }

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, kullanici.KullaniciAdi),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                new Claim(ClaimTypes.Role, "StandartUye"), // opsiyonel: rollere örnek olarak
                new Claim("Takim", kullanici.TuttuguTakim ?? ""), // opsiyonel: custom bir claim
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [Authorize(Roles = "StandartUye")]
        [HttpGet("Bilgi")]
        public IActionResult GetKullaniciBilgi()
        {
            var takim = User.FindFirstValue("Takim");
            var rol = User.FindFirstValue(ClaimTypes.Role);
            var kullaniciAdi = User.Identity!.Name;

            return Ok(new
            {
                TuttuguTakim = takim,
                Rol = rol,
                KullaniciAdi = kullaniciAdi,
                NotAdedi = _db.Notlar.Where(n => n.Kullanici.KullaniciAdi == kullaniciAdi).Count()
            });
        }
    }
}
