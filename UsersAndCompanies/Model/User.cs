using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UsersAndCompanies.Model
{
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        private string name;
        public string Name { 
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            } 
        }

        [Required, MaxLength(30)]
        private string login;
        public string Login { 
            get => login;
            set
            {
                if (login == value)
                    return;
                login = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        [Required, MaxLength(30)]
        private string password;
        public string Password { 
            get => password;
            set
            {
                if (password == value)
                    return;
                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        [Required]
        private Company company;
        public virtual Company Company { 
            get => company;
            set
            {
                if (company == value)
                    return;
                company = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Company)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public User() { }

        public User(string name, string login, string password, Company company = null)
        {
            Name = name;
            Login = login;
            Password = password;
            Company = company;
        }
    }
}
