using System.Drawing;
using System.Drawing.Printing;
using ClassLibrary.Models;

namespace ClassLibrary.Service
{
    /// <summary>
    /// Barimt hevleh uilcilgeeg hariutssan klass
    /// Hudaldan abaltiin medeellees print document uusgene.
    /// </summary>
    public class PrintingService
    {
        /// <summary>
        /// Hudaldan avaltiin medeelel deer undslen hevlehed velen printDocument uusgene
        /// </summary>
        /// <param name="items">Sagsand baigaa baraanuud</param>
        /// <param name="cashierName">Hudaldan avalt hiisen kasschni ner</param>
        /// <param name="totalAmount">Hudaldan avaltiin niit dun</param>
        /// <param name="paymentMethod">Tolboriin helber</param>
        /// <returns>print document obiekt</returns>
        public PrintDocument CreateReceiptPrintDocument(List<SaleItem> items, string cashierName, decimal totalAmount, string paymentMethod)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, e) =>
            {
                Graphics graphics = e.Graphics;
                Font titleFont = new Font("Arial", 14, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10);
                Font boldFont = new Font("Arial", 10, FontStyle.Bold);
                float yPos = 50;
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;

                // Print header
                graphics.DrawString("ХУДАЛДААНЫ БАРИМТ", titleFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                graphics.DrawString($"Огноо: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 20;
                graphics.DrawString($"Кассчин: {cashierName}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;

                // Print items
                graphics.DrawString("Бараа", boldFont, Brushes.Black, leftMargin, yPos);
                graphics.DrawString("Тоо", boldFont, Brushes.Black, leftMargin + 150, yPos);
                graphics.DrawString("Үнэ", boldFont, Brushes.Black, leftMargin + 200, yPos);
                graphics.DrawString("Нийт", boldFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 20;

                foreach (var item in items)
                {
                    graphics.DrawString(item.Product.Name, normalFont, Brushes.Black, leftMargin, yPos);
                    graphics.DrawString(item.Quantity.ToString(), normalFont, Brushes.Black, leftMargin + 150, yPos);
                    graphics.DrawString(item.Product.Price.ToString("C"), normalFont, Brushes.Black, leftMargin + 200, yPos);
                    graphics.DrawString(item.Total.ToString("C"), normalFont, Brushes.Black, leftMargin + 300, yPos);
                    yPos += 20;
                }

                // Print total
                yPos += 20;
                graphics.DrawString("Нийт дүн:", boldFont, Brushes.Black, leftMargin + 200, yPos);
                graphics.DrawString(totalAmount.ToString("C"), boldFont, Brushes.Black, leftMargin + 300, yPos);
                yPos += 20;
                graphics.DrawString($"Төлбөрийн хэлбэр: {paymentMethod}", normalFont, Brushes.Black, leftMargin, yPos);
                yPos += 30;
                graphics.DrawString("Баярлалаа!", titleFont, Brushes.Black, leftMargin, yPos);
            };
            return pd;
        }
    }
} 