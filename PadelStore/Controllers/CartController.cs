using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PadelStore.Data;
using PadelStore.Data.Models;
using PadelStore.ViewModels;
using PadelStrore.Services.Core.Contracts;

namespace PadelStore.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;
       

        public CartController(ICartService cartService,
                              UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            
        }
        public async Task<IActionResult> Index()
        {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            IEnumerable<CartItemViewModel> cart = await cartService.GetCartAsync(userId);

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Guid productId)
        {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            await cartService.AddToCartAsync(userId, productId);

            return RedirectToAction("Index", "Cart");
        }

        public async Task<IActionResult> Remove(Guid id)
        {

            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            bool isOwner = await cartService.IsOwnerAsync(id, userId);

            if (!isOwner)
            {
                return NotFound(); 
            }

            await cartService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Increase(Guid id)
        {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            

            if (!await cartService.IsOwnerAsync(id, userId))
            {
                return NotFound();
            }

            await cartService.IncreaseQuantityAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Decrease(Guid id)
        {
            Guid userId = Guid.Parse(userManager.GetUserId(User)!);

            

            if (!await cartService.IsOwnerAsync(id, userId))
            {
                return NotFound();
            }
            await cartService.DecreaseQuantityAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
