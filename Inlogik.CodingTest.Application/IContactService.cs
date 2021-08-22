using System.Collections.Generic;
using System.Threading.Tasks;
using Inlogik.CodingTest.Application.Dtos;

namespace Inlogik.CodingTest.Application
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetContacts();
        Task<ContactDto> CreateContact(CreateContactDto createContactInput);
        Task<ContactDto> UpdateContact(int id, UpdateContactDto updateContactInput);
    }
}