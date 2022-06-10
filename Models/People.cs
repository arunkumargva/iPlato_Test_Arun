using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPlato_Test.Models
{
    public class People: ObservableCollection<Person>
    {
        public People()
        {
            GetPeopleData();
        }
        public void GetPeopleData()
        {
            this.Items.Add(new Person() { PersonId = 1, Name = "Arun", DateOfBirth = "21-05-1983", Profession = "Developer" });
            this.Items.Add(new Person() { PersonId = 2, Name = "Deepika", DateOfBirth = "22-10-1984", Profession = "Tester" });
            this.Items.Add(new Person() { PersonId = 3, Name = "Rithvik", DateOfBirth = "10-10-2018", Profession = "Singer" });


        }
    }
}
