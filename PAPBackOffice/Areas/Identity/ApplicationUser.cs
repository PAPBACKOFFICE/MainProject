using Microsoft.AspNetCore.Identity;
using System;

namespace PAPBackOffice.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}