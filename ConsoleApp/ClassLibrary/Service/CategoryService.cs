using ClassLibrary.Repository;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Service
{
    /// <summary>
    /// angilaltai holbootoi biznes logiciig hariutssan  uilcilgeenii klass.
    /// </summary>
    public class CategoryService
    {
        private readonly CategoryRepository categoryRepository;

        /// <summary>
        /// CategoryService iin shine exzamplyariig uusgeh
        /// </summary>
        /// <param name="categoryRepository">angilaliin ogogdoltoi haritsah repo</param>
        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// buh angilaluudiig avch iren
        /// </summary>
        /// <returns>angilaliin jagsaalt</returns>
        public List<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        /// <summary>
        /// shine angilal nemen
        /// </summary>
        /// <param name="name">angilaliin ner</param>
        public void AddCategory(string name)
        {
            categoryRepository.AddCategory(name);
        }

        /// <summary>
        /// angilal shineclene
        /// </summary>
        /// <param name="id">angilaliin id </param>
        /// <param name="name">shine ner</param>
        public void UpdateCategory(int id, string name)
        {
            categoryRepository.UpdateCategory(id, name);
        }

        /// <summary>
        /// angilaliig ustgah 
        /// </summary>
        /// <param name="id">ustgah angilaliin id</param>
        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }
    }
} 