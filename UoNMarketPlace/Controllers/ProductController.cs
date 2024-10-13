using Microsoft.AspNetCore.Mvc;
using UoNMarketPlace.DataContext;
using UoNMarketPlace.ViewModel;
using UoNMarketPlace.Model;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace UoNMarketPlace.Controllers
{
    public class ProductController : Controller
    {
        private readonly UoNDB _context;
        public ProductController(UoNDB context)
        {
            _context = context;
        }

        #region Landing Page
        public IActionResult LandingPage()
        {
            return View();
        }
        #endregion

        #region Sell
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
                    DateUploaded = DateTime.Now,
                    IsApproved = true // New products are approved by default
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("SellerDashboard");
            }

            return View(model);
        }
        #endregion

        #region Buy
        public IActionResult Buy(string search = "", string category = "") //, decimal minPrice = 0, decimal maxPrice = 1000000m
        {
            // Fetch all products from the database
            var products = _context.Products.Where(p => p.IsApproved && !p.IsFlagged).AsQueryable();

            // Apply search by product name or description
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search) || p.Description.Contains(search));
            }

            // Apply category filter
            else if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            // Apply price range filter
            //products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            // Return the filtered products to the view
            return View(products.ToList());
        }

        #endregion

        #region Product details
        public IActionResult ProductDetails(int id)
        {
            // Fetch the product by ID along with reviews
            // Fetch the product by ID, even if flagged, but exclude it from reviews display
            var product = _context.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Check if the product is flagged and show an appropriate message
            if (product.IsFlagged)
            {
                ViewBag.Message = "This product is pending review for being flagged as inappropriate.";
            }

            // For unapproved or flagged products, don't display reviews
            if (!product.IsApproved || product.IsFlagged)
            {
                return View("FlaggedProductDetails", product); // Create a separate view for flagged products
            }

            // Load reviews for approved and non-flagged products only
            product = _context.Products
                .Include(p => p.Reviews)
                .FirstOrDefault(p => p.Id == id && p.IsApproved && !p.IsFlagged);


            // If the current user is not the seller, increment views
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var sellerIdClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (sellerIdClaim == null || sellerIdClaim.Value != product.SellerId)
            {
                product.Views++;
                _context.SaveChanges();
            }

            // Calculate average rating if there are reviews
            if (product.Reviews.Any())
            {
                product.Rating = product.Reviews.Average(r => r.Rating);
            }

            return View(product);
        }

        #endregion

        #region Seller Dashboard
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

        #endregion 

        #region Delete
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
        #endregion

        #region Edit
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
        #endregion

        #region Review
        [HttpPost]
        public async Task<IActionResult> SubmitReview(int productId, int rating, string reviewText)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.Identity.Name;

            var review = new ProductReview
            {
                ProductId = productId,
                UserId = userId,
                UserName = userName,
                Rating = rating,
                ReviewText = reviewText,
                DateReviewed = DateTime.Now
            };

            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.Reviews.Add(review);
                product.Rating = product.Reviews.Average(r => r.Rating); // Update average rating

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ProductDetails", new { id = productId });
        }

        #endregion

        #region Flagged Product
        [HttpGet]
        public IActionResult FlagProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || !product.IsApproved)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> FlagProduct(int productId, string reason)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Flag the product as inappropriate
            product.IsFlagged = true;
            product.FlagReason = reason;
            product.IsApproved = false; // Pending admin review

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            // Optionally, redirect to a confirmation page or the product details page
            return RedirectToAction("FlagConfirmation");
        }
        // Confirmation view after flagging a product
        public IActionResult FlagConfirmation()
        {
            return View();
        }
        #endregion

        #region Private functions
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
