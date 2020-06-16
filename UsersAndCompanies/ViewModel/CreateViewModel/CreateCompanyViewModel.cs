using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UsersAndCompanies.Model;

namespace UsersAndCompanies.ViewModel
{
    class CreateCompanyViewModel : BindableBase
    {
        private Window parentWindow;

        private string companyName;
        public string CompanyName
        {
            get => companyName;
            set => SetProperty(ref companyName, value);
        }

        private ContactStatus contactStatus;
        public ContactStatus ContactStatus
        {
            get => contactStatus;
            set => SetProperty(ref contactStatus, value);
        }

        public IList<ContactStatus> ContactStatuses { get; }

        public ICommand OnCreateClick { get; set; }
        public ICommand OnCancelClick { get; set; }

        public CreateCompanyViewModel(Window window)
        {
            parentWindow = window;

            ContactStatuses = UsersAndCompaniesContext.Instance.ContactStatuses.ToList();

            OnCreateClick = new DelegateCommand(CreateClick);
            OnCancelClick = new DelegateCommand(CancelClick);
        }

        private void CancelClick()
        {
            parentWindow.DialogResult = false;
        }

        private void CreateClick()
        {
            if(string.IsNullOrWhiteSpace(companyName) || contactStatus is null)
            {
                MessageBox.Show("Fill all forms.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Company company = new Company(CompanyName, ContactStatus);
            UsersAndCompaniesContext.Instance.Companies.Add(company);
            parentWindow.DialogResult = true;
        }
    }
}
