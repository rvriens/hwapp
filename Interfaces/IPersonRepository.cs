using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> ListAll();
        void Add(Person person);
    }
}