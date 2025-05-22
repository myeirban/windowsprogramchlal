using ClassLibrary.Models;
using ClassLibrary.Repository;
using ClassLibrary.Service;


namespace ClassLibrary//POS system klass Class library namespace dotor bairlaj baigaa
{
    /// <summary>
    /// POS systemiin tov udirdlagin klass.
    /// Buh repository,uilcilgee,ogogdliin sangiin holboltiig zohion baiguulj,gadaad heregleend API helbereer dmjuldag.
    /// </summary>
    public class POSSystem
    {
        private const string DB_PATH = @"C:\Users\22B1NUM7158\Documents\school\windowsprogramchlal\windowsshuu\ConsoleApp\miniidatabase.db";
        private readonly DatabaseRepository databaseRepository;//SQLite ogogdliin sang udirdah repo 
        private readonly UserRepository userRepository;//hereglegchiin medeeleltei ajillah repo
        private readonly ProductRepository productRepository;//baraanii medeelliig urirdah repo
        private readonly CategoryRepository categoryRepository;//angilaliin medeelliig udirdah repo
        private readonly OrderService orderService;//hudaldan avaltiin logic
        private readonly ProductService productService;//baraanii nemelt logic
        private readonly PrintingService printingService;//barimt hevleh uilcilgee


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
        public POSSystem()
        {
            databaseRepository = new DatabaseRepository(DB_PATH);
            userRepository = new UserRepository(databaseRepository.GetConnection());
            productRepository = new ProductRepository(databaseRepository.GetConnection());
            categoryRepository = new CategoryRepository(databaseRepository.GetConnection());
            orderService = new OrderService(databaseRepository);
            productService = new ProductService(productRepository);
            printingService = new PrintingService();
        }

        /// <summary>
        /// POS sistemiig initsializ hiij buh hamaaral buhii achaaldag
        /// </summary>
        /// <param name="dbPath">DB iin zam</param>
        public POSSystem(string dbPath)
        {
            databaseRepository = new DatabaseRepository(dbPath);
            userRepository = new UserRepository(databaseRepository.GetConnection());
            productRepository = new ProductRepository(databaseRepository.GetConnection());
            categoryRepository = new CategoryRepository(databaseRepository.GetConnection());
            orderService = new OrderService(databaseRepository);
            productService = new ProductService(productRepository);
            printingService = new PrintingService();
        }

        /// <summary>
        /// hereglegchiin nevtreh ner bolon nuuts ugeer shalgana.
        /// </summary>
        /// <param name="username">hereglegchiin ner</param>
        /// <param name="password">nuuts ug</param>
        /// <returns>amjilttai bol true,esreg tohioldold false</returns>
        public bool Login(string username, string password)
        {
            
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
        /// <param name="barcode"></param>
        public void AddProduct(string name, decimal price, int stock, int categoryId, string barcode)
        {
            // This should call ProductRepository or a ProductService
            productRepository.AddProduct(new Product { Name = name, Price = price, Stock = stock, CategoryId = categoryId, Barcode = barcode });
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