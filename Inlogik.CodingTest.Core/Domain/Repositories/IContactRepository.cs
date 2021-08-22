using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inlogik.CodingTest.Core.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
    }
}
