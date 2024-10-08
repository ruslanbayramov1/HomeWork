#region Task 1: Faktorial tapin
/*int fac = 5;
int result = 1;

for (int i = 0; i <= fac; i++)
{
    if (i == 0)
    {
        result = 1;
        continue;
    }
    result *= i;
}
Console.WriteLine(result);*/
#endregion

#region Task 2: Fibonacci ededlerini sirala
/*int[] arr = new int[10];
arr[0] = 0;
arr[1] = 1;

for (int i = 1; i < arr.Length - 1; i++)
{
    arr[i + 1] = arr[i] + arr[i - 1];
}

foreach (int i in arr)
{
    Console.Write(i + " ");
}*/
#endregion

#region Task 3: Ne qeder a herfi oldugunu tap
/*string text = "Salam men Ruslan Bayramov";
int total = 0;

foreach (char letter in text)
{ 
    if (letter == 'a') total++;
}
Console.WriteLine(total);*/
#endregion

#region Task 4: Salam sozunu tap
/*string text = "SaSSalamlar, necesiniz ?";
string search = "Salam";
int keyI = 0;
for (int i = 0; i < text.Length; i++)
{
    if (text[i] == search[keyI])
    {
        if (keyI == search.Length - 1)
        {
            Console.WriteLine(true);
            break;
        }
        keyI++;
    }
    else
    {
        if (keyI != 0)
        {
            if (i > 0) i -= keyI;
        }
        keyI = 0;
    }
}
Console.WriteLine(keyI);*/
#endregion

#region Task 5: Stringi siralayin
/*string word = "salam";
char[] arr = new char[word.Length];

for (int i = 0; i < word.Length; i++)
{
    arr[i] = word[i];
}

for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr.Length - 1; j++)
    {
        if (arr[j] > arr[j + 1])
        {
            char temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}

foreach (char c in arr)
{ 
    Console.WriteLine(c);
}*/
#endregion

#region Task 6: Verilmis ededi en boyuk sekilde cixisa verin
/*int num = 194;
int tempNum = num;
int count = 0;
int result = 0;

do
{ 
    tempNum /= 10;
    count++;
}
while (tempNum > 0);

int[] arr = new int[count];
tempNum = num;
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = tempNum % 10;
    tempNum /= 10;
}
Console.WriteLine(arr.Length);

for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr.Length - 1; j++)
    {
        if (arr[j] < arr[j + 1])
        {
            arr[j] = arr[j] + arr[j + 1];
            arr[j + 1] = arr[j] - arr[j + 1];
            arr[j] = arr[j] - arr[j + 1];
        }
    }
}

foreach (int i in arr)
{
    result = result * 10;
    result += i;
}
Console.WriteLine(result);*/
#endregion

#region Task 7: Verilmiş 2 integer array-dən birincisində yer alıb digərində yer almayan elementləri ekrana çıxarın
/*int[] arrFirst = { 2, 4, 5, 6, 9, 1 };
int[] arrSecond = { 3, 4, 7, 8, 9, 10, 12 };

foreach (int i in arrFirst)
{
    int count = 0;
    foreach (int j in arrSecond)
    {
        if (i == j)
        {
            break;
        }
        else
        {
            count++;
        }
    }
    if (count == arrSecond.Length)
    {
        Console.WriteLine("Number " + i + " does not exist in second array");
    }
}*/
#endregion

#region Task 8: Verilmiş integer array-in tək indexdə duran elementləri ilə cüt indexdə duran elementləri müqayisə edin
/*int[] arr = { 3, 1, 2, 5, 5, 6, 4, 8, 9 };
int lengthOdd, lengthEven;
if (arr.Length % 2 == 1)
{
    lengthOdd = arr.Length / 2;
    lengthEven = arr.Length / 2 + 1;
}
else
{
    lengthOdd = arr.Length / 2;
    lengthEven = arr.Length / 2;
}

int[] arrOdd = new int[lengthOdd];
int[] arrEven = new int[lengthEven];
int indexOdd = 0;
int indexEven = 0;

for (int i = 0; i < arr.Length; i++)
{
    if (i % 2 == 0)
    {
        arrEven[indexEven] = arr[i];
        indexEven++;
    }
    else
    {
        arrOdd[indexOdd] = arr[i];
        indexOdd++;
    }
}

Console.Write("Odd index numbers: ");
foreach (int i in arrOdd)
{
    Console.Write(i + " ");
}

Console.Write("\nEven index numbers: ");
foreach (int i in arrEven)
{
    Console.Write(i + " ");
}


Console.WriteLine("\n---------------");

foreach (int odd in arrOdd)
{
    foreach (int even in arrEven)
    {
        if (odd > even)
        {
            Console.WriteLine($"Odd number {odd} is greater than even number {even}");
        }
        else if (even > odd)
        {
            Console.WriteLine($"Odd number {odd} is less than even number {even}");
        }
        else
        {
            Console.WriteLine($"Odd number {odd} is equal to even number {even}");
        }
    }
}*/
#endregion