using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GlowMate
{
    public static class ReportGenerator
    {
        public static void GenerateInventoryReport(List<Product> productList, string filePath)
        {
            try
            {
                if (productList == null || productList.Count == 0)
                {
                    File.WriteAllText(filePath, "No product data available to generate report.");
                    return;
                }

                var categorySummary = productList
                    .Where(p => !string.IsNullOrEmpty(p.CategoryName))
                    .GroupBy(p => p.CategoryName)
                    .Select(g => new { Category = g.Key, Count = g.Count() });

                int expiredCount = productList.Count(p => p.ExpiryDate < DateTime.Now);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GlowMate – Inventory Summary Report");
                sb.AppendLine($"Generated on: {DateTime.Now}");
                sb.AppendLine(new string('-', 60));
                sb.AppendLine("Product Count by Category:");

                foreach (var cat in categorySummary)
                {
                    sb.AppendLine($"- {cat.Category}: {cat.Count} item(s)");
                }

                sb.AppendLine();
                sb.AppendLine($"Total Products: {productList.Count}");
                sb.AppendLine($"Expired Products: {expiredCount}");

                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception ex)
            {
                File.WriteAllText(filePath, "Error generating report: " + ex.Message);
            }
        }
    }
}
