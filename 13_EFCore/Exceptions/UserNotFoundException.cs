namespace _13_EFCore.Exceptions;

class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User not found! Try again!")
    {
        
    }
    public UserNotFoundException(string message) : base(message)
    {

    }
}
