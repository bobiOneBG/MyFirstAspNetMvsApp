
namespace MyFirstMvsApp.Services
{
    using MyFirstMvsApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Count()
        {
            return db.Users.Count();
        }

        public IEnumerable<string> GetUsernames()
        {
            return db.Users.Select(u=>u.UserName).ToList();
        }

        public string LatestUsername()
        {
            return db.Users.OrderByDescending(u=>u.Email).Select(u => u.UserName).FirstOrDefault();
        }
    }
}
