using ClassLibrary;
using ClassLibrary.Models;


namespace TestProject
{
    [TestClass]
    public sealed class POSTests
    {
        private POSSystem posSystem;

        [TestInitialize]
        public void Setup()
        {
            posSystem = new POSSystem();
            CleanupTestData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            CleanupTestData();
        }

        private void CleanupTestData()
        {
            foreach (var product in posSystem.GetProducts())
                posSystem.DeleteProduct(product.Id);

            foreach (var category in posSystem.GetCategories())
                posSystem.DeleteCategory(category.Id);
        }

        [TestMethod]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            Assert.IsTrue(posSystem.Login("admin", "admin"));
        }

        [TestMethod]
        public void Login_WithInvalidCredentials_ShouldFail()
        {
            Assert.IsFalse(posSystem.Login("invalid", "wrong"));
        }

        [TestMethod]
        public void Category_CRUD_Operations_ShouldWorkCorrectly()
        {
            string name = "Category_" + DateTime.Now.Ticks;
            string updatedName = name + "_Updated";

            posSystem.AddCategory(name);
            var category = posSystem.GetCategories().FirstOrDefault(c => c.Name == name);
            Assert.IsNotNull(category);

            posSystem.UpdateCategory(category.Id, updatedName);
            category = posSystem.GetCategories().FirstOrDefault(c => c.Id == category.Id);
            Assert.AreEqual(updatedName, category.Name);

            posSystem.DeleteCategory(category.Id);
            Assert.IsNull(posSystem.GetCategories().FirstOrDefault(c => c.Id == category.Id));
        }

        

        
        

        [TestMethod]
        public void UserRepository_ShouldAddAndRetrieveUser()
        {
            string username = "user_" + DateTime.Now.Ticks;
            var user = new User { Username = username, Password = "pass", Role = "User" };
            posSystem.UserRepository.AddUser(user);

            var retrieved = posSystem.UserRepository.GetUser(username);
            Assert.IsNotNull(retrieved);
            Assert.AreEqual(username, retrieved.Username);
        }

       

        
    }
}