using _13_EFCore.Exceptions;
using _13_EFCore.Extensions;
using _13_EFCore.Models;
using _13_EFCore.Repositories.Abstractions;
using _13_EFCore.Repositories.Implements;

namespace _13_EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isShown = true;
            bool isShown2 = true;
            string loginMenu = """
                1. Login
                2. Register
                0. See menu
                """;
            string userMenu = """
                1. Add products
                2. Delete products
                3. Exit from account
                0. See menu
                """;
            bool isContinue = true;
            bool isLoggedIn = false;
            string code;
            int prodId;
            int prodBaskId;
            string username;
            string password;
            string name;
            string surname;
            User user = new User();

            IUserRepository userRep = new UserRepository();
            IProductRepository prodRep = new ProductRepository();
            IBasketRepository basketRep = new BasketRepository();

            while (isContinue)
            {
                if (!isLoggedIn)
                {
                    if (isShown)
                    {
                        Console.WriteLine(loginMenu);
                    }

                    Console.Write("Enter action code: ");
                    code = Console.ReadLine()!;
                    Console.WriteLine();
                    isShown = false;
                    switch (code)
                    {
                        case "1":
                            Console.Write("Enter your username: ");
                            username = Console.ReadLine()!;

                            Console.Write("Enter your password: ");
                            password = Console.ReadLine()!;

                            try
                            {
                                user = userRep.Login(username, password);
                                Console.WriteLine("Logging in...");
                                Thread.Sleep(2000);
                                Console.WriteLine($"Welcome {username}! \n");
                                isLoggedIn = true;
                            }
                            catch (Exception ex) when (ex is UserNotFoundException || ex is Exception)
                            {
                                Console.WriteLine(ex.GetType().ToString().Split('.')[^1] + ": " + ex.Message);
                            }
                            break;
                        case "2":
                            Console.Write("Enter your name: ");
                            name = Console.ReadLine()!;

                            Console.Write("Enter your surname: ");
                            surname = Console.ReadLine()!;

                            Console.Write("Enter your username: ");
                            username = Console.ReadLine()!;

                            Console.Write("Enter your password: ");
                            password = Console.ReadLine()!;

                            userRep.Register(name, surname, username, password);

                            Console.WriteLine("Creating user...");
                            Thread.Sleep(2000);
                            Console.WriteLine("User created, now try log in!");
                            break;
                        case "0":
                            Console.WriteLine(loginMenu);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                else
                {
                    if (isShown2)
                    {
                        Console.WriteLine(userMenu);
                    }

                    Console.Write("Enter action code: ");
                    code = Console.ReadLine()!;
                    isShown2 = false;
                    Console.WriteLine();
                    switch (code)
                    {
                        case "1":
                            prodRep.ShowAllProducts().Print();
                            Console.Write("Enter product id to add basket: ");
                            try
                            {
                                prodId = Convert.ToInt32(Console.ReadLine());
                                basketRep.AddToBasket(user.Id, prodId);
                            }
                            catch (Exception ex) when (ex is ProductNotFoundException || ex is Exception)
                            {
                                Console.WriteLine(ex.GetType().ToString().Split('.')[^1] + ": " + ex.Message);
                            }
                            break;
                        case "2":
                            if (!prodRep.ShowUserProducts(user.Id).Print())
                            {
                                Console.WriteLine("No product to remove! Add some :)");
                                break;
                            }

                            Console.Write("Enter product's basket id to remove from basket: ");
                            try
                            {
                                prodBaskId = Convert.ToInt32(Console.ReadLine());
                                if (basketRep.RemoveFromBasket(user.Id, prodBaskId))
                                {
                                    Console.WriteLine($"Product with id {prodBaskId} successfully removed");
                                }
                            }
                            catch (Exception ex) when (ex is ProductNotFoundException || ex is Exception)
                            {
                                Console.WriteLine(ex.GetType().ToString().Split('.')[^1] + ": " + ex.Message);
                            }
                            break;
                        case "3":
                            Console.WriteLine("You are logging out...");
                            Thread.Sleep(2000);
                            isLoggedIn = false;
                            isShown = true;
                            isShown2 = true;
                            break;
                        case "0":
                            Console.WriteLine(userMenu);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
            }
        }
    }
}
