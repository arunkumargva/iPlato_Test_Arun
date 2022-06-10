using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
    
namespace iPlato_Test.Models
{
    public class Person : Model
    {
        private int personId;
        private string name;
        private string dateOfBirth;
        private string profession;

        public int PersonId
        {
            get => personId;
            set
            {
                personId = value;
                OnPropertyChanged(nameof(PersonId));
            }
        }
        public string Name 
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }
        public string DateOfBirth 
        {
            get => dateOfBirth;
            set 
            { 
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string Profession 
        { 
            get => profession;
            set 
            { 
                profession = value;
                OnPropertyChanged(nameof(Profession));
            }
        }

    }
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
