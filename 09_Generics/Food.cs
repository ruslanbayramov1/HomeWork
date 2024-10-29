using _09_Generic;
using System.Reflection;

namespace _09_Generics;

abstract class Food
{
    private int _calorie;
    public int Calorie 
    {
        get => _calorie;
        set
        {
            if (value <= 0)
                throw new InvalidIntInputException("Calorie can not be less and equal than 0!");

            _calorie = value;
        }
    }

    protected Food() { }

    protected Food(int calorie)
    {
        Calorie = calorie;
    }
}

class Meat : Food
{
    private string _type;
    private enum MeatType
    {
        Lamb = 1,
        Pork,
        Beef,
        Goat
    }

    private string meats = string.Join(" or ", Enum.GetValues(typeof(MeatType)).Cast<MeatType>().Select(g => g.ToString()));

    public string Type
    {
        get => _type;
        set
        {
            if (CheckMeat(value) == false)
                throw new InvalidMeatTypeException($"Meat type can only be {meats} !!!");

            _type = value;
        }
    }

    public Meat() { }
    public Meat(string type, int calorie) : base(calorie)
    {
        Type = type;
    }

    private bool CheckMeat(string gender)
    {
        foreach (var value in Enum.GetValues(typeof(MeatType)))
        {
            if (gender.ToLower().Trim() == value.ToString().ToLower().Trim())
                return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split('.')[^1]} {{ Calorie: {Calorie}, Type: {Type} }}";
    }
}

class Grass : Food
{
    public string Name { get; set; }

    public Grass() { }

    public Grass(string name, int calorie) : base(calorie)
    {
        Name = name;
    }
}

class ZooCage<T, U> where T : Animal, new() 
    where U : Food, new()
{ 
    public T Animal { get; set; }
    public U Food { get; set; }

    public ZooCage(T animal, U food)
    {
        Animal = animal;
        Food = food;
    }

    public void EatFood(T animal)
    {
        animal.HP += (Food.Calorie) / 10;
    }
}

