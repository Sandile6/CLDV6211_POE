using KhumaloTest.Data;
using KhumaloTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace KhumaloTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly KhumaloTestContext _context;

        public AccountController(KhumaloTestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string email, string password)
        {
            var user = new User
            {
                UserName = userName,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = "Client"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                // Handle login success (e.g., set authentication cookie)
                return RedirectToAction("Index", "Home");
            }
            // Handle login failure
            return View();
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}