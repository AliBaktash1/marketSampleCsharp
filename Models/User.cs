namespace Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Item> Cart { get; set; } 

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
            Cart = new List<Item>();
        }

        public void UpdateUserInfo(string newUsername, string newPassword)
        {
            Username = newUsername;
            Password = newPassword;
        }

        public void AddToCart(Item item)
        {
            Cart.Add(item);
        }
    }
}
