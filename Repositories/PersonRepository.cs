using System;
using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class PersonRepository : Interfaces.IPersonRepository
    {


private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(Person person)
        {
            this._dbContext.Persons.Add(person);
            this._dbContext.SaveChanges();
        }

        public IEnumerable<Person> ListAll()
        {
            return this._dbContext.Persons;
        }
    }
}