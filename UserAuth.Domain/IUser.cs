using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuth.Domain
{
    public interface IUser
    {
        void SetName(string Name);
        void SetEmail(string Email);
        void SetPassword(string Password, string Confirmation);

        void Validate();
    }
}
