using Microsoft.AspNetCore.Mvc;
using UoNMarketPlace.DataContext;
using UoNMarketPlace.Model;

namespace UoNMarketPlace.Controllers
{
    public class AdminController : Controller
    {
        private readonly UoNDB _context;

        public AdminController(UoNDB context)
        {
            _context = context;
        }

        public IActionResult AdminLandingPage()
        {
            // Fetch flagged products for review
            var flaggedProducts = _context.Products.Where(p => p.IsFlagged && !p.IsApproved).ToList();
            return View(flaggedProducts);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Admin approves the product
            product.IsApproved = true;
            product.IsFlagged = false; // Remove flag after approval
            product.FlagReason = null; // Clear the flag reason

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminLandingPage");
        }

        [HttpPost]
        public async Task<IActionResult> RejectProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Admin rejects the product (delete from the database)
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("AdminLandingPage");
        }
    }
}
