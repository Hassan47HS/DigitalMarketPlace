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

    }
}
