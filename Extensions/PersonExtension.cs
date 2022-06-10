using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPlato_Test.Models;

namespace iPlato_Test.Extensions
{
    public static class PersonExtension
    {
        public static Person CreateNewPerson(this Person person,People people)
        {
            int latestPersonId = people.OrderByDescending(x => x.PersonId).FirstOrDefault().PersonId;
            var newPerson = new Person();
            newPerson.PersonId = latestPersonId + 1;
            newPerson.Name = person.Name;
            newPerson.DateOfBirth = person.DateOfBirth;
            newPerson.Profession = person.Profession;
            return newPerson;
        }
    }
}
