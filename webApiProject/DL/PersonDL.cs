using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
	public class PersonDL : IPersonDL
	{
		HeartFailureContext _heartFailureContext;

		public PersonDL(HeartFailureContext heartFailureContext)
		{
			_heartFailureContext = heartFailureContext;
		}
		public async Task<Person> getPerson(string login, string password)
		{
			Person person = await _heartFailureContext.Person.Where(data => data.Email.Equals(login) && data.Password.Equals(password)).FirstOrDefaultAsync();
			return person;
		}
		public async Task AddPerson(Person p)
		{
			await _heartFailureContext.Person.AddAsync(p);
			await _heartFailureContext.SaveChangesAsync();
		}
		public async Task<Person> changePerson(Person p, int id)
		{

				Person PersonToUpdate1 = await _heartFailureContext.Person.FindAsync(id);

				if (PersonToUpdate1 == null)
				{
					return null;
				}
				p.PersonId = PersonToUpdate1.PersonId;
				_heartFailureContext.Entry(PersonToUpdate1).CurrentValues.SetValues(p);
				await _heartFailureContext.SaveChangesAsync();
				return p;
			
		}


	}
}


