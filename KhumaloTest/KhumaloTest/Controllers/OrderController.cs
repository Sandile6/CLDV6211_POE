using KhumaloTest.Models;
using Microsoft.AspNetCore.Mvc;
using KhumaloTest.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace KhumaloTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly KhumaloTestContext _context;

        public OrderController(KhumaloTestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int CraftworkId, int quantity, string clientName, string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                user = new User { UserName = clientName, Email = email, PasswordHash = "", Role = "Client" };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            var order = new Order { UserId = user.Id, OrderDate = DateTime.Now };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderItem = new OrderItem { OrderId = order.Id, CraftworkId = CraftworkId, Quantity = quantity };
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyOrders", new { email = email });
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders(string email)
        {
            var orders = await _context.Orders
                .Where(o => o.User.Email == email)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Craftwork)
                .ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> AdminOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Craftwork)
                .ToListAsync();
            return View(orders);
        }
    }
}