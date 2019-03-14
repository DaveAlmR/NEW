using System;
using System.Collections.Generic;
using UserAuth.Domain;

namespace UserAuth.Infra
{
    public class UserRepository : IUserRepository
    {
        Dictionary<string, User> UsersDB = new Dictionary<string, User>();

        public void Add(User user)
        {
            if (UsersDB.ContainsKey(user.Email))
                throw new Exception("Existent Email!");
            UsersDB.Add(user.Email, user);
        }

        public void Delete(string Email)
        {
            if (!UsersDB.Remove(Email))
                throw new Exception("Nonexistent Email.");
        }

        public User GetByEmail(string Email)
        {
            CheckEmail(Email);
            return UsersDB[Email];
        }

        public List<User> GetUsers()
        {
            List<User> list = new List<User>();
            list.AddRange(UsersDB.Values);
            return list;
        }

        public void Update(User user)
        {
            CheckEmail(user.Email);
            UsersDB[user.Email] = user;
        }

        private void CheckEmail(string Email)
        {
            if (!UsersDB.ContainsKey(Email))
                throw new Exception("Nonexistent Email.");
        }
    }
}
