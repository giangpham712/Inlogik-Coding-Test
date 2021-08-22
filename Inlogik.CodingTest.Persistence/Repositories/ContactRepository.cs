using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inlogik.CodingTest.Core.Domain;
using Inlogik.CodingTest.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inlogik.CodingTest.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Set<Contact>().AsNoTracking().ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
    }
}
