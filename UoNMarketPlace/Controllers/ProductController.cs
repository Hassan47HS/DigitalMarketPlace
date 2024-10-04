using Microsoft.AspNetCore.Mvc;
using UoNMarketPlace.DataContext;
using UoNMarketPlace.ViewModel;
using UoNMarketPlace.Model;
using System.Security.Claims;

namespace UoNMarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private readonly UoNDB _context;
        public ProductController(UoNDB context)
        {
            _context = context;
        }

        public IActionResult LandingPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sell()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Sell(sellViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (sellerIdClaim == null)
                {
                    return Unauthorized(); // If the user is not authenticated
                }

                var sellerId = sellerIdClaim.Value;
                var imagePaths = await SaveImages(model.ProductImages); // Modify to save multiple images
                var product = new sellProduct
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category,
                    ImagePath = string.Join(",", imagePaths),// Join the image paths as a comma-separated string
                    SellerId = sellerId,
                    DateUploaded = DateTime.Now
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("SellerDashboard");
            }

            return View(model);
        }
        public IActionResult Buy()
        {
            // Fetch all products from the database
            var products = _context.Products.ToList();

            return View(products);
        }
        public IActionResult ProductDetails(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // If the current user is not the seller, increment views
            if (sellerIdClaim != null && sellerIdClaim.Value != product.SellerId)
            {
                product.Views++;
                _context.SaveChanges();
            }


            return View(product);
        }

        public IActionResult SellerDashboard(string sortBy = "dateUploaded", string filterBy = "")
        {
            // Retrieve the seller's ID from the claims
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (sellerIdClaim == null)
            {
                return Unauthorized(); // If the user is not authenticated
            }

            var sellerId = sellerIdClaim.Value; // Extract the seller ID from the claim

            // Get all products for the current seller
            var products = _context.Products.Where(p => p.SellerId == sellerId);

            // Apply filtering if provided
            if (!string.IsNullOrEmpty(filterBy))
            {
                products = products.Where(p => p.Name.Contains(filterBy) ||
                                               p.Description.Contains(filterBy) ||
                                               p.Category.Contains(filterBy)); 
            }

            // Apply sorting based on the sortBy parameter
            switch (sortBy)
            {
                case "views":
                    products = products.OrderByDescending(p => p.Views);
                    break;
                case "dateUploaded":
                default:
                    products = products.OrderByDescending(p => p.DateUploaded);
                    break;
            }

            // Pass sortBy and filterBy values to the view for UI state preservation
            ViewBag.SortBy = sortBy;
            ViewBag.FilterBy = filterBy;

            // Return the products to the view
            return View(products.ToList());
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            // You should also delete it from the buy list or any other related tables.
            return RedirectToAction("SellerDashboard");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // Ensure that the product belongs to the current seller
            if (sellerIdClaim == null || sellerIdClaim.Value != product.SellerId)
            {
                return Unauthorized(); // Only the seller can edit their product
            }

            var model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ExistingImages = product.ImagePath.Split(',').ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = await _context.Products.FindAsync(model.Id);

            if (product == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // Ensure that the product belongs to the current seller
            if (sellerIdClaim == null || sellerIdClaim.Value != product.SellerId)
            {
                return Unauthorized();
            }

            // Update product details
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Category = model.Category;

            // Handle new image uploads
            if (model.ProductImages != null && model.ProductImages.Any())
            {
                var newImagePaths = await SaveImages(model.ProductImages);
                product.ImagePath = string.Join(",", newImagePaths);
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("SellerDashboard");
        }

        #region
        private async Task<List<string>> SaveImages(List<IFormFile> imageFiles)
        {
            var imagePaths = new List<string>();

            // Define the image directory path
            var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            // Check if the directory exists, if not, create it
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            // Loop through the files and save them
            foreach (var imageFile in imageFiles)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(imageDirectory, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    imagePaths.Add("/images/" + fileName); // Store the relative path
                }
            }

            return imagePaths;
        }
        #endregion


    }
}
