using _13_EFCore.Models;

namespace _13_EFCore.Repositories.Abstractions;

interface IProductRepository
{
    List<Product> ShowAllProducts();
    List<Product> ShowUserProducts(int userId);
}
