﻿using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Text;

namespace OnlieShop.Domain.Models.Entities
{
    class ApplicationRole:IdentityRole
    {
        public ApplicationRole() { }
        public string Description { get; set; } 
    }
}
