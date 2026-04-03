using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService,
                               UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            string? userIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return Unauthorized();
            }

            await orderService.CreateOrderAsync(userId);

            return View();
        }

        public async Task<IActionResult> MyOrders()
        {
            string? userIdString = userManager.GetUserId(User);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return Unauthorized();
            }

            IEnumerable<OrderViewModel> orders = await orderService.GetByUserIdAsync(userId);

            return View(orders);
        }
    

    public async Task<IActionResult> Details(Guid id)
        {
            OrderDetailsViewModel? order = await orderService.GetDetailsAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
