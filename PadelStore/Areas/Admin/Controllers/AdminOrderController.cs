using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PadelStore.Data.Models.Enums;
using PadelStore.ViewModels.Admin;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Areas.Admin.Controllers
{
    public class AdminOrderController : BaseAdminController
    {
        private readonly IOrderService orderService;

        public AdminOrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAllAsync();
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(Guid id, OrderStatus status)
        {
            await orderService.ChangeStatusAsync(id, status);

            return RedirectToAction(nameof(Index));
        }
    }
}

