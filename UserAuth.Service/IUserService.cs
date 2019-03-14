using System;
using System.Collections.Generic;
using System.Text;
using UserAuth.Domain;

namespace UserAuth.Service
{
    interface IUserService
    {
        void Add(User user);
        void Delete(string Email);
        User GetByEmail(string Email);
        void Update(User user);
    }
}
