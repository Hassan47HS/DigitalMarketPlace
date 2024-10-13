namespace UoNMarketPlace.Model
{
    public class sellProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? ImagePath { get; set; }
        public int Views { get; set; }
        public DateTime DateUploaded { get; set; }
        public string SellerId { get; set; }
        public double Rating { get; set; } // Average rating of the product
        public ICollection<ProductReview> Reviews { get; set; } // Collection of reviews
        public bool IsFlagged { get; set; } // Indicates if product is flagged
        public string? FlagReason { get; set; } // Reason for flagging
        public bool IsApproved { get; set; } // Indicates if admin has approved the product
    }
}
