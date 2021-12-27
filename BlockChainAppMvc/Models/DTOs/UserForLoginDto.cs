using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.DTOs
{
    [Keyless]
    public class UserForLoginDto : IDto
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
    }

    
}
