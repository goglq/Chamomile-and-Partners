using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UsersAndCompanies.Model
{
    [Table("Companies")]
    public class Company : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        private string name;
        public string Name {
            get => name;
            set {
                if (name == value)
                    return;
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private ContactStatus contactStatus;
        public virtual ContactStatus ContactStatus {
            get => contactStatus;
            set
            {
                if (contactStatus == value)
                    return;
                contactStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContactStatus)));
            }
        }

        private IList<User> users;
        public IList<User> Users { 
            get => users; 
            set
            {
                if (users == value)
                    return;
                users = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Company() {
            Users = new List<User>();
        }

        public Company(string name, ContactStatus contactStatus, params User[] users)
        {
            Name = name;
            ContactStatus = contactStatus;
            Users = users.ToList();
        }

        public static Company Generate()
        {
            Random random = new Random();
            return new Company(
                RandomStringGenerator.GenerateCompanyName(), 
                ContactStatus.Statuses[random.Next(0, ContactStatus.Statuses.Count)]);
        }

        public override string ToString() => name;
    }
}
