using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobEye.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobEye.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void EmptyConstructorTest()
        {
            User user = new User();
            Assert.IsNotNull(user);
        }

        [TestMethod()]
        public void ConstructorTest()
        {
            User user = new User("User","User123");
            Assert.AreEqual(user.Username, "User");
            Assert.AreEqual(user.Password, "User123");
        }

        [TestMethod()]
        public void SetUsernameTest()
        {
            User user = new User();
            user.Username = "User";
            Assert.AreEqual(user.Username, "User");
        }

        [TestMethod()]
        public void SetPasswordTest()
        {
            User user = new User();
            user.Password = "User123";
            Assert.AreEqual(user.Password, "User123");
        }
    }
}

namespace MobEyeTests.Models
{
    class UserTests
    {
    }
}
