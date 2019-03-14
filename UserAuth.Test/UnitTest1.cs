using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UserAuth.Domain;
using UserAuth.Infra;

namespace UserAuth.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InvalidUser()
        {
            IUser user = new User();

            Assert.ThrowsException<Exception>(() => user.SetName(""));
            Assert.ThrowsException<Exception>(() => user.SetName("abc"));
            Assert.ThrowsException<Exception>(() => user.SetEmail(""));
            Assert.ThrowsException<Exception>(() => user.SetEmail("abc"));
            Assert.ThrowsException<Exception>(() => user.SetPassword("",""));
            Assert.ThrowsException<Exception>(() => user.SetPassword("abc","def"));
            Assert.ThrowsException<Exception>(() => user.Validate());
        }

        [TestMethod]
        public void ValidUser()
        {
            User user = new User();
            user.SetName("Test Name");
            user.SetEmail("TestEmail@invent.com");
            user.SetPassword("TestPassword", "TestPassword");
            user.Validate();

            Assert.AreEqual(user.Name, "Test Name");
            Assert.AreEqual(user.Email, "TestEmail@invent.com");
            Assert.AreEqual(user.Password, "TestPassword");
        }

        [TestMethod]
        public void InvalidUserRepository()
        {
            UserRepository repository = new UserRepository();
            User user = new User();
            user.SetName("Test Name");
            user.SetEmail("TestEmail@invent.com");
            user.SetPassword("TestPassword", "TestPassword");
            user.Validate();

            repository.Add(user);
            Assert.ThrowsException<Exception>(() => repository.Add(user));
            Assert.ThrowsException<Exception>(() => repository.Delete("Invalid Email"));
            Assert.ThrowsException<Exception>(() => repository.GetByEmail("Invalid Email"));

            user.SetEmail("InvalidEmail@invent.com");
            Assert.ThrowsException<Exception>(() => repository.Update(user));
        }

        [TestMethod]
        public void ValidUserRepository()
        {
            UserRepository repository = new UserRepository();
            User user = new User();
            user.SetName("Test Name");
            user.SetEmail("TestEmail@invent.com");
            user.SetPassword("TestPassword", "TestPassword");
            user.Validate();

            repository.Add(user);

            user.SetName("Another Name");
            repository.Update(user);

            user = repository.GetByEmail(user.Email);
            Assert.AreEqual(user.Name, "Another Name");

            repository.Delete(user.Email);
            Assert.ThrowsException<Exception>(() => repository.GetByEmail(user.Email));
        }
    }
}
