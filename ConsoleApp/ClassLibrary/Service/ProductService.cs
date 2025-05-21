using ClassLibrary.Repository;
using ClassLibrary.Models;
using System;
using System.IO;
using System.Drawing;

namespace ClassLibrary.Service
{
    public class ProductService
    {
        private ProductRepository productRepository;

        public ProductService(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProductWithImage(Product product, Image? image, string imageSaveDirectory)
        {
            try
            {
                productRepository.AddProduct(product);
            }
            catch (Exception dbEx)
            {
                // Re-throw with a more specific message
                throw new Exception($"Өгөгдлийн санд бараа нэмэхэд алдаа гарлаа: {dbEx.Message}", dbEx);
            }

            if (image != null)
            {
                try
                {
                    Directory.CreateDirectory(imageSaveDirectory);
                    string imagePath = Path.Combine(imageSaveDirectory, $"{product.Code}.jpg");
                    image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                catch (Exception imgEx)
                {
                    // Re-throw the exception to be handled by the calling code (UI layer)
                    throw new Exception($"Зураг хадгалахад алдаа гарлаа: {imgEx.Message}", imgEx);
                }
            }
        }
    }
}