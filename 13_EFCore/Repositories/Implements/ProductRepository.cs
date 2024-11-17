using _13_EFCore.Contexts;
using _13_EFCore.Models;
using _13_EFCore.Repositories.Abstractions;

namespace _13_EFCore.Repositories.Implements;

class ProductRepository : IProductRepository
{
    public List<Product> ShowAllProducts()
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

    public List<Product> ShowUserProducts(int usId)
    {
        #region Explanation
        // join baskets with products ON id, then return products but not their original id, instead id in basket (location)
        // because 2 same products can have same product id, but not same basketId
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
}
