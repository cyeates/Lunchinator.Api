using Lunchinator.Data;
using Lunchinator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchinator.Data.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        void Save();
    }

    public class UserRepository : IUserRepository
    {
        private LunchinatorContext _context;
        public UserRepository(LunchinatorContext context)
        {
            _context = context;
        }

        public User GetById(int id)
        {
            return _context.Users.Include("Ratings").FirstOrDefault(u => u.UserId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
