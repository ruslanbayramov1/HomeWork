namespace _13_EFCore.Exceptions;

class ProductNotFoundException : Exception
{
    public ProductNotFoundException() : base("No product with given id!")
    {
        
    }

    public ProductNotFoundException(string message) : base(message)
    {
        
    }
}
