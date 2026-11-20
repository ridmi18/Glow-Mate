using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlowMate
{
    internal class Category
    {
        public int CategoryId { get; set; }         // Unique ID for each category
        public string CategoryName { get; set; }    // Name of the category (e.g., Skincare)
        public bool IsActive { get; set; }          // Whether the category is in use
        public int ProductCount { get; set; }       // Number of products under this category

        // Constructor
        public Category(int id, string name, bool isActive, int productCount)
        {
            CategoryId = id;
            CategoryName = name;
            IsActive = isActive;
            ProductCount = productCount;
        }

        // For display in dropdowns, etc.
        public override string ToString()
        {
            return CategoryName;
        }
    }
}
