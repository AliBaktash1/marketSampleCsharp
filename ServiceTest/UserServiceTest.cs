using Models;
using NUnit.Framework;
using Service;
using Assert = Xunit.Assert;


namespace ServiceTest
{
    public class UserServiceTest
    {
        [Test]
        public void Register_ShouldAddUser()
        {
            var userService = new UserService();
            userService.Register("user1", "password1", "user");

            var user = userService.Login("user1", "password1");
            Assert.NotNull(user);
        }

        [Test]
        public void Login_ShouldReturnNullForInvalidUser()
        {
            var userService = new UserService();
            userService.Register("user1", "password1", "user");

            var user = userService.Login("invalid", "password");
            Assert.Null(user);
        }
    }
}
