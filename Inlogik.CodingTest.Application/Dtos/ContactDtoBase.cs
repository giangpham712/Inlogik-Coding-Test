using System;
using System.Collections.Generic;
using System.Text;

namespace Inlogik.CodingTest.Application.Dtos
{
    public abstract class ContactDtoBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
