using System.Text;

namespace _07_Indexers;

internal class ListInt
{
    private int[] _ints = new int[0];
    public int[] Ints { get; private set; }

    public int this[int index]
    {
        get => Ints[index];
        set
        {
            if (index >= _ints.Length) return;
            _ints[index] = value;
            Ints = _ints;
        }
    }

    public void Add(int num)
    {
        Array.Resize(ref _ints, _ints.Length + 1);
        _ints[_ints.Length - 1] = num;
        Ints = _ints;
    }

    public void Add(params int[] nums)
    {
        int total = _ints.Length + nums.Length;
        int numIndex = 0;
        int[] copyArray = new int[total];

        for (int i = 0; i < total; i++) // will fixed
        {
            if (i < _ints.Length) copyArray[i] = _ints[i];
            else
            { 
                copyArray[i] = nums[numIndex];
                numIndex++;
            }
        }
        _ints = copyArray;
        Ints = _ints;
    }

    public bool Contains(int num)
    {
        if (IndexOf(num) == -1) return false;

        return true;
    }

    public int Pop()
    {

        int poppedVal = _ints[^1];
        Array.Resize(ref _ints, _ints.Length - 1);
        Ints = _ints;

        return poppedVal;
    }

    public int Sum()
    {
        int sum = 0;
        foreach (int num in _ints) sum += num;

        return sum;
    }

    public int IndexOf(int num)
    {
        for (int i = 0; i < Ints.Length; i++)
        {
            if (Ints[i] == num) return i;
        }

        return -1;
    }

    public int LastIndexOf(int num)
    {
        for (int i = Ints.Length - 1; i >=0 ; i--)
        {
            if (Ints[i] == num) return i;
        }

        return -1;
    }

    public void Insert(int num, int index)
    {
        if (index >= Ints.Length) return;

        int[] copyArray = new int[Ints.Length + 1];

        for (int i = 0; i < copyArray.Length; i++)
        {
            if (i < index) copyArray[i] = Ints[i];
            else if (i == index) copyArray[i] = num;
            else copyArray[i] = Ints[i - 1]; 
        }

        _ints = copyArray;
        Ints = _ints;
    }

    public float Average()
    {
        int sum = 0;
        foreach (int i in Ints)
        {
            sum += i;
        }
        return (float)sum / Ints.Length;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < Ints.Length; i++)
        {
            if (i != _ints.Length - 1) sb.Append($"{Ints[i]}, ");
            else sb.Append(Ints[i]);
        }
        return sb.ToString();
    }
}
