
using Models;

namespace Service
{
    public class UserService
    {
        private List<User> users = new List<User>();

        public void Register(string username, string password, string role)
        {
            users.Add(new User(username, password, role));
            Console.WriteLine("User registered successfully.");
        }

        public User Login(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine("Login successful.");
                    return user;
                }
            }
            Console.WriteLine("Invalid username or password.");
            return null;
        }

        public void UpdateUserInfo(User user, string newUsername, string newPassword)
        {
            user.UpdateUserInfo(newUsername, newPassword);
            Console.WriteLine("User info updated successfully.");
        }
    }
}
