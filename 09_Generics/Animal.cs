using _09_Generic;

namespace _09_Generics;

abstract class Animal
{
    private int _avgLifeTime;
    private string _gender;
    private int _hp;
    private enum GenderAnimal
    {
        Male = 1,
        Female = 2
    }
    private string genders = string.Join(" or ", Enum.GetValues(typeof(GenderAnimal)).Cast<GenderAnimal>().Select(g => g.ToString()));

    public int AvgLifeTime 
    {
        get => _avgLifeTime;
        set
        {
            if (value <= 0)
                throw new InvalidIntInputException("Average life time can not be less and equal than 0!");

            _avgLifeTime = value;
        }
    }
    public string Gender 
    {
        get => _gender;
        set
        {
            if (CheckGender(value) == false)
            { 
                
                throw new InvalidGenderException($"Genders can only be {genders} !!!");
            }
                
            _gender = value;
        }
    }
    public string Breed { get; set; }
    public int HP 
    {
        get => _hp;
        set
        {
            if (value <= 0)
                throw new InvalidIntInputException("HP can not be less and equal than 0!");

            _hp = value;
        }
    }

    protected Animal() { }

    protected Animal(int avgTime, string gender, string breed, int hp)
    {
        AvgLifeTime = avgTime;
        Gender = gender;
        Breed = breed;
        HP = hp;
    }

    private bool CheckGender(string gender)
    {
        foreach (var value in Enum.GetValues(typeof(GenderAnimal)))
        { 
            if (gender.ToLower().Trim() == value.ToString().ToLower().Trim())
                return true;
        }

        return false;
    }
}

class Wolf : Animal
{
    private int _attackDamage;
    public bool IsPrideLeader { get; set; }
    public int AttackDamage 
    {
        get => _attackDamage;
        set
        {
            if (value <= 0)
                throw new InvalidIntInputException("Attack damage can not be less or equal than 0 !");
        }
    }
    public void Hunt<T>(T animal) where T : Animal, new() // generic method
    { 
        if (IsPrideLeader)
            animal.HP -= 4 * AttackDamage;
        else 
            animal.HP -= AttackDamage;
    }

    public Wolf() { }

    public Wolf(bool isPrideLeader, int attackDamage, int avgTime, string gender, string breed, int hp) : base (avgTime, gender, breed, hp)
    {
        IsPrideLeader = isPrideLeader;
        AttackDamage = attackDamage;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split('.')[^1]} {{ AvgLifeTime: {AvgLifeTime}, Gender: {Gender}, Breed: {Breed}, HP: {HP}, IsPrideLeader: {IsPrideLeader}, AttackDamage: {AttackDamage} }}";
    }
}

class Elephant : Animal
{ 
    private double _weight { get; set; }
    public bool IsTrained { get; set; }

    public double Weight
    {
        get => _weight;
        set
        {
            if (value <= 0)
                throw new InvalidIntInputException("Weight can not be less or equal than 0 !");
        }
    }

    public Elephant() { }

    public Elephant(double weight, bool isTrained, int avgTime, string gender, string breed, int hp) : base(avgTime, gender, breed, hp)
    {
        Weight = weight;
        IsTrained = isTrained;
    }

    public override string ToString()
    {
        return $"{this.GetType().ToString().Split('.')[^1]} {{ AvgLifeTime: {AvgLifeTime}, Gender: {Gender}, Breed: {Breed}, HP: {HP}, Weight: {Weight}, IsTrained: {IsTrained} }}";
    }
}
