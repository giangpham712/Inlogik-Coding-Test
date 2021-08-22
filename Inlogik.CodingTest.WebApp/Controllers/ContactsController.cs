using Inlogik.CodingTest.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlogik.CodingTest.Application.Dtos;

namespace Inlogik.CodingTest.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactDto>> GetContacts()
        {
            return await _contactService.GetContacts();
        }

        [HttpPost]
        public async Task<ContactDto> CreateContact([FromBody] CreateContactDto input)
        {
            return await _contactService.CreateContact(input);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ContactDto> CreateContact([FromRoute] int id, [FromBody] UpdateContactDto input)
        {
            return await _contactService.UpdateContact(id, input);
        }
    }
}
