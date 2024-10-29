namespace _09_Generic;

class InvalidIntInputException : Exception
{
    public InvalidIntInputException(string message) : base(message) { }
}

class InvalidGenderException : Exception
{
    public InvalidGenderException(string message) : base(message) { }
}

class InvalidMeatTypeException : Exception
{
    public InvalidMeatTypeException(string message) : base(message) { }
}