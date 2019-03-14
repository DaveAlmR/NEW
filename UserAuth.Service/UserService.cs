using System;
using UserAuth.Domain;
using UserAuth.Infra;

namespace UserAuth.Service
{
    public class UserService : IUserService
    {
        UserRepository repository = new UserRepository();

        public void Add(User user)
        {
            user.Validate();
            this.repository.Add(user);
        }

        public void Delete(string Email)
        {
            this.repository.Delete(Email);
        }

        public User GetByEmail(string Email)
        {
            return this.repository.GetByEmail(Email);
        }

        public void Update(User user)
        {
            user.Validate();
            this.repository.Update(user);
        }
    }
}
