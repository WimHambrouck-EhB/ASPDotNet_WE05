using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Werkcollege05.Oef02.Data;
using Werkcollege05.Oef02.Models;

namespace Werkcollege05.Oef02.Controllers
{ 
    public class AuthController : Controller
    {
        private readonly Werkcollege05Oef02Context _context;

        public AuthController(Werkcollege05Oef02Context context)
        {
            _context = context;
        }
        
        // routering instellen, zodat zowel /Auth als /Auth/Login naar deze actie verwijzen
        // als beide attributen weggelaten worden, zal /Auth geen pagina laten, omdat MVC standaard naar /Index zoekt.
        [Route("[controller]/")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Login()
        {
            return View(await _context.Gebruiker.ToListAsync());
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Naam,Wachtwoord,WachtwoordControle")] Gebruiker gebruiker)
        {
            if (GebruikerExists(gebruiker.Naam))
            {
                throw new NotImplementedException();
            }

            if (ModelState.IsValid)
            {
                
                gebruiker.Wachtwoord = HashPassword(gebruiker.Wachtwoord);

                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(gebruiker);
        }

        // bron: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-2.1
        private static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        private bool GebruikerExists(string id)
        {
            return _context.Gebruiker.Any(e => e.Naam == id);
        }
    }
}
