using _13_EFCore.Contexts;
using _13_EFCore.Exceptions;
using _13_EFCore.Extensions;
using _13_EFCore.Models;

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
                                user = Login(username, password);
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

                            Register(name, surname, username, password);

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
                            ShowAllProducts().Print();
                            Console.Write("Enter product id to add basket: ");
                            try
                            {
                                prodId = Convert.ToInt32(Console.ReadLine());
                                AddToBasket(user.Id, prodId);
                            }
                            catch (Exception ex) when (ex is ProductNotFoundException || ex is Exception)
                            {
                                Console.WriteLine(ex.GetType().ToString().Split('.')[^1] + ": " + ex.Message);
                            }
                            break;
                        case "2":
                            if (!ShowUserProducts(user.Id).Print())
                            {
                                Console.WriteLine("No product to remove! Add some :)");
                                break;
                            }

                            Console.Write("Enter product's basket id to remove from basket: ");
                            try
                            {
                                prodBaskId = Convert.ToInt32(Console.ReadLine());
                                if (RemoveFromBasket(user.Id, prodBaskId))
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

        public static User Login(string username, string password)
        {
            #region Explanation
            // enter name and username, check if they exists in database, if not throw exception
            // if exists, login and return user (needs to select its Id to do operations based on user id)
            #endregion
            using (AppDbContext context = new AppDbContext())
            { 
                var user = context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new UserNotFoundException();
                }
            }
        }

        public static void Register(string name, string surname, string username, string password)
        {
            #region Explanation
            // add/create user based on given data.
            // save changes
            #endregion
            using (AppDbContext context = new AppDbContext())
            {
                context.Users.Add(new User
                {
                    Name = name,
                    Surname = surname,
                    Username = username,
                    Password = password,
                });
                context.SaveChanges();
            }
        }

        public static List<Product> ShowAllProducts()
        {
            #region Explanation
            // return all products because when user want to add, it needs to see all of them
            #endregion
            using (AppDbContext context = new AppDbContext())
            {
                List<Product> products = [];
                var query = context.Products.AsQueryable();
                products = query.ToList();

                return products;
            }
        }

        public static void AddToBasket(int usId, int prId)
        {
            #region Explanation
            // check if given id is valid for products, if id is not true throw exception
            // if id is valid based on user id which we take in login procces, add it to baskets which have relations
            // save changes
            #endregion
            using (AppDbContext context = new AppDbContext())
            {
                var pr = context.Products.FirstOrDefault(pr => pr.Id == prId);

                if (pr != null)
                {
                    context.Baskets.Add(new Basket
                    {
                        ProductId = prId,
                        UserId = usId,
                    });
                    context.SaveChanges();
                }
                else
                {
                    throw new ProductNotFoundException();
                }
            }
        }

        public static List<Product> ShowUserProducts(int usId)
        {
            #region Explanation
            // join baskets with products ON id, then return products but not their original id, instead id in basket (location)
            // because 2 same products have same productId but not same basketId
            #endregion
            using (AppDbContext context = new AppDbContext())
            {
                var query = context.Baskets.Where(b => b.UserId == usId).Join(context.Products, b => b.ProductId, p => p.Id, (basket, product) => new { basket, product }).AsQueryable();
                var userBasket = query.ToList();

                List<Product> products = userBasket.Select(ub => new Product
                { 
                    Id = ub.basket.Id,
                    Name = ub.product.Name,
                    Price = ub.product.Price,
                }).ToList();

                return products;
            }
        }

        public static bool RemoveFromBasket(int usId, int prBskId)
        {
            #region Explanation
            // return products based on userid, user need to enter products basket id. if not true, throw exception
            // if true, delete id based on id and save changes
            #endregion
            var products = ShowUserProducts(usId);
            using (AppDbContext context = new AppDbContext())
            {
                var pr = products.FirstOrDefault(p => p.Id == prBskId);
                if (pr != null)
                {
                    context.Baskets.Remove(new Basket
                    {
                        Id = prBskId
                    });
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new ProductNotFoundException($"Not product in basket with given id {prBskId}");
                }
            }
        }
    }
}
