using _13_EFCore.Contexts;
using _13_EFCore.Exceptions;
using _13_EFCore.Models;
using _13_EFCore.Repositories.Abstractions;

namespace _13_EFCore.Repositories.Implements;

class BasketRepository : IBasketRepository
{
    public void AddToBasket(int usId, int prId)
    {
        #region Explanation
        // check if given product id(prId) is valid for products, if not throw exception
        // if product id is valid, add it to baskets with user id(usId) and product id(prId)
        // it takes user id from top level variable when we log in, it saves user info and reuse it for operations needs user id like this
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

    public bool RemoveFromBasket(int usId, int prBskId)
    {
        IProductRepository prodRep = new ProductRepository();
        #region Explanation
        // return products based on userid
        // Doing search operation FirstOrDefault on user's products is crucial, it prevents user to delete product from someone else's basket
        // if its a invalid id throw exception
        // if true, delete product based on id which is products basket id
        // save changes
        #endregion
        var products = prodRep.ShowUserProducts(usId);
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
