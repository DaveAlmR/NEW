using System;

namespace UserAuth.Domain
{
    public class User : IUser
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetEmail(string Email)
        {
            ValidateEmail(Email);
            this.Email = Email;
        }

        private void ValidateEmail(string Email)
        {
            if ( Email == null || !Email.Contains("@") || !Email.Contains(".") || Email.Length < 5)
                throw new Exception("Invalid Email.");
        }

        public void SetName(string Name)
        {
            ValidateName(Name);
            this.Name = Name;
        }

        private void ValidateName(string Name)
        {
            if ( Name == null || Name.Length < 4 )
                throw new Exception("Invalid Name.");
        }

        public void SetPassword(string Password, string Confirmation)
        {
            ValidatePassword(Password, Confirmation);
            this.Password = Password;
        }

        private void ValidatePassword(string Password, string Confirmation)
        {
            if (Password == null || Password.Length < 6)
                throw new Exception("Invalid Password.");

            if (Password != Confirmation)
                throw new Exception("Invalid Confirmation");
        }

        public void Validate()
        {
            if (this.Name == null)
                throw new Exception("Name can't be null.");

            if (this.Email == null)
                throw new Exception("Email can't be null.");

            if (this.Password == null)
                throw new Exception("Password can't be null.");
        }
    }
}
