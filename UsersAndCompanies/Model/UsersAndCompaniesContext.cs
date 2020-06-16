using System.Data.Entity;

namespace UsersAndCompanies.Model
{
    class UsersAndCompaniesContext : DbContext
    {
        private const int ItemAdditionNumber = 10;
        private const string connectionName = "UsersAndCompanies";

        private static UsersAndCompaniesContext instance;
        public static UsersAndCompaniesContext Instance
        {
            get
            {
                if (instance is null)
                    instance = new UsersAndCompaniesContext();
                return instance;
            }
        }

        private UsersAndCompaniesContext() : base(connectionName)
        {
            bool isDataBaseExist = !Database.Exists(connectionName);

            Database.SetInitializer(new CreateDatabaseIfNotExists<UsersAndCompaniesContext>());
            if(isDataBaseExist)
                AddData();
        }

        //Функции для добавления данных для теста
        #region AddingFunctions
        private void AddData()
        {
            AddContactStatuses();
            AddCompanies();
            SaveChanges();
        }

        private void AddContactStatuses()
        {
            foreach(ContactStatus contactStatus in ContactStatus.Statuses)
            {
                ContactStatuses.Add(contactStatus);
            }
            SaveChanges();
        }

        private void AddCompanies()
        {
            for (int i = 0; i < ItemAdditionNumber; i++)
                Companies.Add(Company.Generate());
        }
        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContactStatus> ContactStatuses { get; set; }
    }
}
