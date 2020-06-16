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
using UsersAndCompanies.View;

namespace UsersAndCompanies.ViewModel
{
    class UserViewModel : BindableBase
    {
        public static Action Refresh;

        private UsersAndCompaniesContext context;

        private IList<User> users;
        public IList<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }

        private User selectedUser;
        public User SelectedUser
        {
            get => selectedUser;
            set => SetProperty(ref selectedUser, value);
        }

        public ICommand OnEditClick { get; set; }
        public ICommand OnDeleteClick { get; set; }
        public ICommand OnCreateClick { get; set; }

        public UserViewModel()
        {
            context = UsersAndCompaniesContext.Instance;

            Users = context.Users.ToList();

            OnEditClick = new DelegateCommand(EditClick);
            OnDeleteClick = new DelegateCommand(DeleteClick);
            OnCreateClick = new DelegateCommand(CreateClick);

            Refresh += RefreshUsers;
        }

        private void CreateClick()
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            if (createUserWindow.ShowDialog() == false)
                return;
            context.SaveChanges();
            Users = context.Users.ToList();
        }

        private void EditClick()
        {
            if (SelectedUser is null)
            {
                MessageBox.Show("Select user first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            EditUserWindow editUserWindow = new EditUserWindow(SelectedUser);
            if (editUserWindow.ShowDialog() == false)
                return;
            context.SaveChanges();
            Users = context.Users.ToList();
        }

        private void DeleteClick()
        {
            context.Users.Remove(SelectedUser);
            context.SaveChanges();
            Users = context.Users.ToList();
        }

        private void RefreshUsers() {
            Users = context.Users.ToList();
        }
    }
}
