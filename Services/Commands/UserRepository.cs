using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Utils;
using Services.DTOs;
using Services.Interfaces;
using Services.Models;

namespace Services.Commands
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext, IMapper mapper): base(dbContext, mapper)
        {
        }

        public async Task<UserDto> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Login information is required.");
            }

            var user = await Context.Users.Include(u => u.UserRoles).ThenInclude(u => u.Role)
                                            .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.IsDel != true);
            if (user != null)
            {
                var result = Common.VerifyPassword(email, password, user.PasswordHash);
                if (result)
                {
                    return _mapper.Map<UserDto>(user);
                }
            }

            return null;
        }
        public async Task<UserDto> GetUser(Guid userId)
        {
            var user = await Context.Users.Where(u => u.UserId == userId)
                            .Include(u => u.UserRoles).ThenInclude(u => u.Role)
                            .FirstOrDefaultAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}