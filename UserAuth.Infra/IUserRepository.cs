using System;
using System.Collections.Generic;
using System.Text;
using UserAuth.Domain;

namespace UserAuth.Infra
{
    interface IUserRepository
    {
        void Add(User user);
        void Delete(string Email);
        User GetByEmail(string Email);
        List<User> GetUsers();
        void Update(User user);
    }
}
