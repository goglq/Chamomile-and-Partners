using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UsersAndCompanies.Model;

namespace UsersAndCompanies.ViewModel
{
    class CreateUserViewModel : BindableBase
    {
        private Window parentWindow;

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string login;
        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private Company company;
        public Company Company
        {
            get => company;
            set => SetProperty(ref company, value);
        }

        public IList<Company> Companies { get; }

        public ICommand OnCreateClick { get; set; }
        public ICommand OnCancelClick { get; set; }

        public CreateUserViewModel(Window window)
        {
            parentWindow = window;

            Companies = UsersAndCompaniesContext.Instance.Companies.ToList();

            OnCreateClick = new DelegateCommand(CreateClick);
            OnCancelClick = new DelegateCommand(CancelClick);
        }

        private void CreateClick()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || Company is null)
            {
                MessageBox.Show("Fill all forms.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User user = new User(UserName, Login, Password, Company);
            UsersAndCompaniesContext.Instance.Users.Add(user);
            parentWindow.DialogResult = true;
        }

        private void CancelClick()
        {
            parentWindow.DialogResult = false;
        }
    }
}
