﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSS_Backend_Opgave.Repositories.Models.Dtos.UserDtos
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }
    }
}