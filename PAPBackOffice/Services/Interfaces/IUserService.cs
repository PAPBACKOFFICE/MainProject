using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAPBackOffice.Data.Entities;
using PAPBackOffice.Data;

namespace PAPBackOffice.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByAccessTokenAsync(string accessToken);
        Task<User> LoginAsync(User user);
        Task<User> RefreshTokenAsync(RefreshRequest refreshRequest);
        Task<User> RegisterUserAsync(User user);
    }
}
