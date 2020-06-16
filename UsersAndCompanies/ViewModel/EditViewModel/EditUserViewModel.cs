using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UsersAndCompanies.Model;

namespace UsersAndCompanies.ViewModel
{
    class EditUserViewModel : BindableBase
    {
        private User user;
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

        public ICommand OnOkClick { get; set; }
        public ICommand OnCancelClick { get; set; }

        public EditUserViewModel(Window window, User user)
        {
            parentWindow = window;

            this.user = user;

            Companies = UsersAndCompaniesContext.Instance.Companies.ToList();

            UserName = user.Name;
            Login = user.Login;
            Password = user.Password;
            Company = user.Company;

            OnOkClick = new DelegateCommand(OkClick);
            OnCancelClick = new DelegateCommand(CancelClick);
        }

        private void OkClick()
        {
            user.Name = userName;
            user.Login = login;
            user.Password = password;
            user.Company = company;
            parentWindow.DialogResult = true;
        }

        private void CancelClick()
        {
            parentWindow.DialogResult = false;
        }
    }
}
