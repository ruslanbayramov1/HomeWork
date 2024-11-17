namespace _13_EFCore.Repositories.Abstractions;

interface IBasketRepository
{
    void AddToBasket(int userId, int productId);
    bool RemoveFromBasket(int userId, int productBasketId);
}
