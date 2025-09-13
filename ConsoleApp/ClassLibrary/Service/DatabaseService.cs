using ClassLibrary.Repository;

namespace ClassLibrary.Service
{
    /// <summary>
    /// ogogdliin sangiin holbolt,anhni tohirgoo zergiig hariutsan uilcilgeenii klass
    /// Data repo g damjuulan ajilladag
    /// </summary>
    public class DatabaseService
    {
        private readonly DatabaseRepository databaseRepository;

        /// <summary>
        /// DatabaseService iin shine examplyariig uusgeh
        /// </summary>
        /// <param name="databaseRepository"></param>
        public DatabaseService(DatabaseRepository databaseRepository)
        {
            this.databaseRepository = databaseRepository;
        }

        
    }
} 