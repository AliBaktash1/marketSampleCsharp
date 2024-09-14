using Models;
using Service;
using System;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var itemService = new ItemService();
            User loggedInUser = null;

            while (true)
            {
                if (loggedInUser == null)
                {
                    Console.WriteLine("\n1. Register");
                    Console.WriteLine("2. Login");
                    Console.Write("Choose an option: ");
                    var choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.Write("Enter username: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var password = Console.ReadLine();
                        Console.Write("Enter role (admin/user): ");
                        var role = Console.ReadLine();

                        userService.Register(username, password, role);
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Enter username: ");
                        var username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var password = Console.ReadLine();

                        loggedInUser = userService.Login(username, password);
                    }
                }
                else
                {
                    if (loggedInUser.Role == "admin")
                    {
                        Console.WriteLine("\nAdmin Menu:");
                        Console.WriteLine("1. Add Item");
                        Console.WriteLine("2. Remove Item");
                        Console.WriteLine("3. Display Items");
                        Console.WriteLine("4. Logout");
                        Console.Write("Choose an option: ");
                        var choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            Console.Write("Enter item name: ");
                            var name = Console.ReadLine();
                            Console.Write("Enter item price: ");
                            var price = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter item ID: ");
                            var itemId = Console.ReadLine();

                            itemService.AddItem(new Item(name, price, itemId));
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter item ID to remove: ");
                            var itemId = Console.ReadLine();
                            itemService.RemoveItem(itemId);
                        }
                        else if (choice == "3")
                        {
                            itemService.DisplayItems();
                        }
                        else if (choice == "4")
                        {
                            loggedInUser = null;
                        }
                    }
                    else if (loggedInUser.Role == "user")
                    {
                        Console.WriteLine("\nUser Menu:");
                        Console.WriteLine("1. Display Items");
                        Console.WriteLine("2. Add Item to Cart");
                        Console.WriteLine("3. View Cart");
                        Console.WriteLine("4. Logout");
                        Console.Write("Choose an option: ");
                        var choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            itemService.DisplayItems();
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter item ID to add to cart: ");
                            var itemId = Console.ReadLine();
                            var item = itemService.GetItemById(itemId);

                            if (item != null)
                            {
                                loggedInUser.AddToCart(item);
                                Console.WriteLine("Item added to cart.");
                            }
                            else
                            {
                                Console.WriteLine("Item not found.");
                            }
                        }
                        else if (choice == "3")
                        {
                            Console.WriteLine("Your Cart:");
                            foreach (var item in loggedInUser.Cart)
                            {
                                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Item ID: {item.ItemId}");
                            }
                        }
                        else if (choice == "4")
                        {
                            loggedInUser = null; // Logout
                        }
                    }
                }
            }
        }
    }
}
