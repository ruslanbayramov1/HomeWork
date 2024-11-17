using _13_EFCore.Contexts;
using _13_EFCore.Exceptions;
using _13_EFCore.Models;
using _13_EFCore.Repositories.Abstractions;

namespace _13_EFCore.Repositories.Implements;

class UserRepository : IUserRepository
{
    public User Login(string username, string password)
    {
        #region Explanation
        // enter name and username, check if they exists in database, if not throw exception
        // if exists, login and return user to save it at the top level
        // the information at top level will be used for operations requires userId for ex: AddToBasket, ShowUserProducts
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

    public void Register(string name, string surname, string username, string password)
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
}
