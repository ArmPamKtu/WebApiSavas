using HugDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HugDb.Repositories
{
    public class UserRepository
    {
        private HugDbContext _context;
        public UserRepository(HugDbContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Single(x => x.Id == id);
        }

        public User GetUserWithHugs(int id)
        {
            //grazina hugs lista, kur sutampa su user id
            return _context.Users.Include(navigationPropertyPath: x =>x.Hugs)
                .Single(x => x.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.Take(100).ToList();
        }

        public List<User> GetUserByName(string name)
        {
            //lazy loading 2ia tik u=klausa parasyta bet duomenu dar nera is db
            var users = _context.Users.Where(x => x.FirstName.Equals(name));
            var result = users.ToList();
            return result;
        }

        public void Delete(int userid)
        {
            var user = GetUser(userid);
            _context.Users.Remove(user);
            //po delete,add,update reikia, kad sinchronizuotu su duombaze
            _context.SaveChanges();
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

     

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
