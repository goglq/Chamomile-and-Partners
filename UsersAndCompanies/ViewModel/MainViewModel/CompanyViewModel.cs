using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UsersAndCompanies.Model;
using UsersAndCompanies.View;

namespace UsersAndCompanies.ViewModel
{
    class CompanyViewModel : BindableBase
    {
        private UsersAndCompaniesContext context;

        private IList<Company> companies;
        public IList<Company> Companies
        {
            get => companies;
            set => SetProperty(ref companies, value);
        }

        private Company selectedCompany;
        public Company SelectedCompany
        {
            get => selectedCompany;
            set => SetProperty(ref selectedCompany, value);
        }

        public ICommand OnEditClick { get; set; }
        public ICommand OnDeleteClick { get; set; }
        public ICommand OnCreateClick { get; set; }

        public CompanyViewModel()
        {
            context = UsersAndCompaniesContext.Instance;

            Companies = context.Companies.Include("Users").ToList();

            OnEditClick = new DelegateCommand(EditClick);
            OnDeleteClick = new DelegateCommand(DeleteClick);
            OnCreateClick = new DelegateCommand(CreateClick);
        }

        private void CreateClick()
        {
            CreateCompanyWindow createCompanyWindow = new CreateCompanyWindow();
            if (createCompanyWindow.ShowDialog() == false)
                return;
            context.SaveChanges();
            Companies = context.Companies.Include("Users").ToList();
        }

        private void EditClick()
        {
            if (SelectedCompany is null)
            {
                MessageBox.Show("Select company first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            EditCompanyWindow companyEditWindow = new EditCompanyWindow(SelectedCompany);
            if (companyEditWindow.ShowDialog() == false)
                return;
            context.SaveChanges();
            Companies = context.Companies.Include("Users").ToList();
            UserViewModel.Refresh?.Invoke();
        }

        private void DeleteClick()
        {
            context.Companies.Remove(SelectedCompany);
            context.SaveChanges();
            Companies = Companies = context.Companies.Include("Users").ToList();
        }
    }
}
