using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Input;
using UsersAndCompanies.Model;

namespace UsersAndCompanies.ViewModel
{
    class EditCompanyViewModel : BindableBase
    {
        private Window parentWindow;

        private Company company;

        private IList<User> users;
        public IList<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }

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

        public IEnumerable<ContactStatus> ContactStatuses { get; }

        public ICommand OnOkClick { get; set; }
        public ICommand OnCancelClick { get; set; }

        public EditCompanyViewModel(Window window, Company company)
        {
            parentWindow = window;

            this.company = company;

            ContactStatuses = UsersAndCompaniesContext.Instance.ContactStatuses.ToList();

            Users = company.Users;
            CompanyName = company.Name;
            ContactStatus = company.ContactStatus;

            OnOkClick = new DelegateCommand(OkClick);
            OnCancelClick = new DelegateCommand(CancelClick);
        }

        private void CancelClick()
        {
            parentWindow.DialogResult = false;
        }

        private void OkClick()
        {
            company.Name = companyName;
            company.ContactStatus = contactStatus;
            company.Users = users;
            parentWindow.DialogResult = true;
        }
    }
}
