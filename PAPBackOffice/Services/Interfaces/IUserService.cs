using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAPBackOffice.Data.Entities;
using PAPBackOffice.Data;

namespace PAPBackOffice.Services.Interfaces
{
    public class IUserService
    {
        public Task<User> GetUserByAccessTokenAsync(string accessToken);
        public Task<User> LoginAsync(User user);
        public Task<User> RefreshTokenAsync(RefreshRequest refreshRequest);
        public Task<User> RegisterUserAsync(User user);
    }
}
