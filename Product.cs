using System;

namespace GlowMate
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // For display/report
        public int Quantity { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
        public string ProductDetails { get; set; }
        public byte[] Image { get; set; }

        public Product() { }

        public Product(int productId, string productName, int categoryId, string categoryName, int quantity,
                       DateTime manufacturedDate, DateTime expiryDate,
                       string status, string productDetails, byte[] image)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Quantity = quantity;
            ManufacturedDate = manufacturedDate;
            ExpiryDate = expiryDate;
            Status = status;
            ProductDetails = productDetails;
            Image = image;
        }
    }
}
