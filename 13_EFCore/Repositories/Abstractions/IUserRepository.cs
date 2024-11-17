using _13_EFCore.Models;

namespace _13_EFCore.Repositories.Abstractions;

interface IUserRepository
{
    User Login(string username, string password);
    void Register(string name, string surname, string username, string password);
}
