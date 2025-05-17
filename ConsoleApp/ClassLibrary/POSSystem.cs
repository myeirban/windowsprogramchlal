using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary
{
    public class POSSystem
    {
        private readonly DatabaseHelper db;

        public POSSystem(string dbPath)
        {
            db = new DatabaseHelper(dbPath);
        }

        public bool Login(string username, string password)
        {
            var user = db.GetUser(username);
            return user != null && user.Password == password;
        }

        public User GetUser(string username)
        {
            return db.GetUser(username);
        }

        public void AddProduct(string name, decimal price, int stock, int categoryId, string barcode)
        {
            db.AddProduct(name, price, stock, categoryId, barcode);
        }

        public void UpdateProduct(int id, string name, decimal price, int stock, int categoryId, string barcode)
        {
            db.UpdateProduct(id, name, price, stock, categoryId, barcode);
        }

        public void DeleteProduct(int id)
        {
            db.DeleteProduct(id);
        }

        public void AddCategory(string name)
        {
            db.AddCategory(name);
        }

        public void DeleteCategory(int id)
        {
            db.DeleteCategory(id);
        }

        public void ProcessSale(List<SaleItem> items, string cashierName, string paymentMethod)
        {
            db.ProcessSale(items, cashierName, paymentMethod);
        }

        public List<Product> GetProducts()
        {
            return db.GetProducts();
        }

        public Product GetProductById(int id)
        {
            return db.GetProductById(id);
        }

        public List<Category> GetCategories()
        {
            return db.GetCategories();
        }
    }
} 