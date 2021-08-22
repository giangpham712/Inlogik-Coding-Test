using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlogik.CodingTest.Application.Dtos;
using Inlogik.CodingTest.Application.Exceptions;
using Inlogik.CodingTest.Core.Domain;
using Inlogik.CodingTest.Core.Domain.Repositories;

namespace Inlogik.CodingTest.Application
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            var contacts = await _contactRepository.GetContacts();
            return contacts.Select(x => new ContactDto()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone
            });
        }

        public async Task<ContactDto> CreateContact(CreateContactDto createContactInput)
        {
            var created = await _contactRepository.AddContact(new Contact()
            {
                Name = createContactInput.Name,
                Phone = createContactInput.Phone,
                Email = createContactInput.Email,
            });

            return new ContactDto()
            {
                Id = created.Id,
                Name = created.Name,
                Email = created.Email,
                Phone = created.Phone
            };
        }

        public async Task<ContactDto> UpdateContact(int id, UpdateContactDto updateContactInput)
        {
            var existingContact = await _contactRepository.GetContactById(id);
            if (existingContact == null)
            {
                throw new EntityNotFoundException();
            }

            existingContact.Name = updateContactInput.Name;
            existingContact.Phone = updateContactInput.Phone;
            existingContact.Email = updateContactInput.Email;

            await _contactRepository.UpdateContact(existingContact);

            return new ContactDto()
            {
                Id = existingContact.Id,
                Name = existingContact.Name,
                Email = existingContact.Email,
                Phone = existingContact.Phone
            };
        }
    }
}
