using System.Windows;
using UsersAndCompanies.Model;
using UsersAndCompanies.ViewModel;

namespace UsersAndCompanies.View
{
    partial class EditCompanyWindow : Window
    {
        public EditCompanyWindow(Company company)
        {
            InitializeComponent();

            DataContext = new EditCompanyViewModel(this, company);
        }
    }
}
