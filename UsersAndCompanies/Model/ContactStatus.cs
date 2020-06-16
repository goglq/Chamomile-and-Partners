using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersAndCompanies.Model
{
    [Table("ContactStatuses")]
    public class ContactStatus : INotifyPropertyChanged
    {
        public static IReadOnlyList<ContactStatus> Statuses { get; set; } = new List<ContactStatus>()
        {
            new ContactStatus("Not Yet Concluded"),
            new ContactStatus("Concluded"),
            new ContactStatus("Terminated")
        };

        [Key]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        private IList<Company> companies;
        public IList<Company> Companies { 
            get => companies;
            set
            {
                if (companies == value)
                    return;
                companies = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Companies)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactStatus() { }

        public ContactStatus(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
