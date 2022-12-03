using Microsoft.EntityFrameworkCore;
using Project_ITAcademy.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Project_ITAcademy.Domain.Models;

namespace Project_ITAcademy.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<User>> GetAllAsync()
        {

            return await _db.Users.ToListAsync();
        }

        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
