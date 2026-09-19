using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalShopDataAccessLayer.DTOs
{
    public class AuthDTO
    {
        public class Login
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
        public class NewPerson
        {
            public string FirstName { get; set; } = null!;

            public string LastName { get; set; } = null!;

            public string Email { get; set; } = null!;

            public string Password { get; set; } = null!;

            public DateTime? DateOfBirth { get; set; }

            public string Phone { get; set; } = null!;

        }
            
    }
}
