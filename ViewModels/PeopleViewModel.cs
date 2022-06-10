using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using iPlato_Test.Models;
using iPlato_Test.Commands;
using System.Windows;
using iPlato_Test.Extensions;

namespace iPlato_Test.ViewModels
{
    public class PeopleViewModel : ViewModel
    {

        public Person Person
        {
            get => person;
            set
            {
                person = value;
                OnPropertyChanged(nameof(Person));
            }
        }
        private People _People;
        public People People
        {
            get
            {
                if(_People==null)
                {
                    _People = new People();
                }
                return _People;
            }
        }        
        private Person _SelectedPerson;
        private Person person;

        public Person SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                _SelectedPerson = value;
                if (_SelectedPerson != null)
                {
                    Person = _SelectedPerson;
                }
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }
        public PeopleViewModel()
        {
            this.CommandAdd = new RelayCommand(CommandAddExecute);
            this.CommandUpdate = new RelayCommand(CommandUpdateExecute, CanCommandUpdateExecute);
            this.CommandDelete = new RelayCommand(CommandDeleteExecute, CanCommandDeleteExecute);
            if (SelectedPerson == null)
            {
                SelectedPerson = new Person();
            }
            if (Person == null)
            {
                Person = new Person();
            }
        }
        public void ResetPerson()
        {
           Person=new Person();
           SelectedPerson = new Person();
        }
       
        public ICommand CommandAdd { set; get; }
        public ICommand CommandUpdate { set; get; }
        public ICommand CommandDelete { set; get; }

        private void CommandAddExecute()
        {
            if(this.People==null || this.SelectedPerson==null)
            {
                return;
            }
            var newPerson = SelectedPerson.CreateNewPerson(People);
            this.People.Add(newPerson);
            ResetPerson();
            MessageBox.Show("Saved!", "Message");
        }
       
        private void CommandUpdateExecute()
        {
            if (this.People == null || this.SelectedPerson == null)
            {
                return;
            }
            var currentPerson = this.People.FirstOrDefault(x => x.PersonId == SelectedPerson?.PersonId);
            var index = this.People.IndexOf(currentPerson);
           // this.People[index] = SelectedPerson;
           // ResetPerson();
            
        }
        private void CommandDeleteExecute()
        {
            if (this.People == null || this.SelectedPerson == null)
            {
                return;
            }
            var currentPerson = this.People.FirstOrDefault(x => x.PersonId == SelectedPerson?.PersonId);
            this.People?.Remove(currentPerson);
            ResetPerson();
            MessageBox.Show("Deleted", "Message");
        }
        private bool CanCommandDeleteExecute()
        {
            if(this.Person.PersonId==0)
            {
                return false;
            }
            return true;
        }
        private bool CanCommandUpdateExecute()
        {
            if (this.Person.PersonId == 0)
            {
                return false;
            }
            return true;
        }
    }

}
