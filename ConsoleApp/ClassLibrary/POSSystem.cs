using System.Collections.Generic;
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repository;
using ClassLibrary.Service;


namespace ClassLibrary
{
    /// <summary>
    /// POS systemiin tov udirdlagin klass.
    /// Buh repository,uilcilgee,ogogdliin sangiin holboltiig zohion baiguulj,gadaad heregleend API helbereer dmjuldag.
    /// </summary>
    public class POSSystem
    {
        private readonly DatabaseRepository databaseRepository;
        private readonly UserRepository userRepository;
        private readonly AuthService authService;
        private readonly ProductRepository productRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly OrderService orderService;
        private readonly ProductService productService;
        private readonly PrintingService printingService;
        

        /// <summary>
        /// hereglegchiin repo
        /// </summary>
        public UserRepository UserRepository => userRepository;
        /// <summary>
        /// baraanii repo 
        /// </summary>
        public ProductRepository ProductRepository => productRepository;
        /// <summary>
        /// baraanii angilaliin repo
        /// </summary>
        public CategoryRepository CategoryRepository => categoryRepository;
        /// <summary>
        /// zahialga bolovsruulah uilcilgee
        /// </summary>
        public OrderService OrderService => orderService;
        /// <summary>
        /// ogogdliin sngin repo
        /// </summary>
        public DatabaseRepository DatabaseRepository => databaseRepository;

        /// <summary>
        /// baraanii uilcilgee
        /// </summary>
        public ProductService ProductService => productService;
        /// <summary>
        /// barimt hvleh uilchilgee
        /// </summary>

        public PrintingService PrintingService => printingService;
        // Add properties for other services as needed

        /// <summary>
        /// POS sistemiig initsializ hiij buh hamaaral buhii achaaldag
        /// </summary>
        /// <param name="dbPath">DB iin zam</param>
        public POSSystem(string dbPath)
        {
            databaseRepository = new DatabaseRepository(dbPath);
            userRepository = new UserRepository(databaseRepository.GetConnection());
            authService = new AuthService(); // Assuming AuthService doesn't need a connection initially
            productRepository = new ProductRepository(databaseRepository.GetConnection());
            categoryRepository = new CategoryRepository(databaseRepository.GetConnection());
            orderService = new OrderService(databaseRepository); // OrderService needs DatabaseRepository
            productService = new ProductService(productRepository);
            printingService = new PrintingService();
            // Initialize other repositories and services
        }

        /// <summary>
        /// hereglegchiin nevtreh ner bolon nuuts ugeer shalgana.
        /// </summary>
        /// <param name="username">hereglegchiin ner</param>
        /// <param name="password">nuuts ug</param>
        /// <returns>amjilttai bol true,esreg tohioldold false</returns>
        public bool Login(string username, string password)
        {
            // Delegate login logic to AuthService or UserRepository
            // For now, directly using UserRepository as AuthService is empty
            var user = userRepository.GetUser(username);
            return user != null && user.Password == password;
        }

        /// <summary>
        /// hereglegchiin nereer hereglegchiin medeelel butsaana
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            return userRepository.GetUser(username);
        }

        /// <summary>
        /// baraa nemeh
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        /// <param name="categoryId"></param>
        public void AddProduct(string name, decimal price, int stock, int categoryId)
        {
            // This should call ProductRepository or a ProductService
            productRepository.AddProduct(new Product { Name = name, Price = price, Stock = stock, CategoryId = categoryId});
        }

        /// <summary>
        /// baraanii medeelliig shinecleh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        /// <param name="categoryId"></param>
        /// <param name="barcode"></param>
        public void UpdateProduct(int id, string name, decimal price, int stock, int categoryId, string barcode)
        {
            productRepository.UpdateProduct(id, name, price, stock, categoryId, barcode);
        }

        /// <summary>
        /// baraag id aar ni haij olood ustgah
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            // This should call ProductRepository or a ProductService
            productRepository.DeleteProduct(id);
        }

        /// <summary>
        /// angilal nemeh
        /// </summary>
        /// <param name="name"></param>
        public void AddCategory(string name)
        {
            // This should call CategoryRepository or a CategoryService
            categoryRepository.AddCategory(name);
        }

        /// <summary>
        /// angilal shinecleh
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void UpdateCategory(int id, string name)
        {
            // This should call CategoryRepository or a CategoryService
            categoryRepository.UpdateCategory(id, name);
        }

        /// <summary>
        /// angilal ustgah
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategory(int id)
        {
            // This should call CategoryRepository or a CategoryService
            categoryRepository.DeleteCategory(id);
        }

        /// <summary>
        /// buh baraanuudiig butsaah 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            // This should call ProductRepository or a ProductService
            return productRepository.GetProducts();
        }
        /// <summary>
        /// id aar ni baraa avah 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            // This should call ProductRepository or a ProductService
            return productRepository.GetProductById(id);
        }

        /// <summary>
        /// buh angilaluudiig butsaah 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            // This should call CategoryRepository or a CategoryService
            return categoryRepository.GetCategories();
        }

        /// <summary>
        /// db iin holbolt butsaana
        /// </summary>
        /// <returns></returns>
        public System.Data.SQLite.SQLiteConnection GetConnection()
        {
            // This method might be removed if connection handling is fully within repositories/services
            return databaseRepository.GetConnection();
        }

        /// <summary>
        /// Hudaldan avaltiin processiig guitsetgej,zahialgiig hadgalna.
        /// </summary>
        /// <param name="saleItems"></param>
        /// <param name="cashierName"></param>
        /// <param name="paymentMethod"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ProcessSale(List<Models.SaleItem> saleItems, string cashierName, string paymentMethod)
        {
            if (saleItems == null || !saleItems.Any())
            {
                throw new ArgumentException("Sale items cannot be empty");
            }

            // Delegate the sale processing to the OrderService
            orderService.ProcessSale(saleItems, cashierName, paymentMethod);
        }
    }
} 