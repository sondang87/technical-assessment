using System;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> Login(string email, string password);
        Task<UserDto> GetUser(Guid userId);
    }
}