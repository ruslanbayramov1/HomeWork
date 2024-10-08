#region Task 1: Iki eded verilir (k, g), k^g tapilsin
int num = 2;
int pow = -3;
double multi = 1;
bool isOdd;

if (pow == 0) multi = 1;
else if (pow > 0)
{
    isOdd = pow % 2 == 1;
    for (int i = 0; i < pow; i++)
    {
        if (num >= 0) multi *= num;  // 2^3 // 2^4
        if (num <= 0 && isOdd) multi *= num; // -2^3
        else if (num <= 0 && !isOdd) multi *= -num; // -2^4
    }
}
else if (pow < 0)
{
    isOdd = pow % 2 == -1;
    for (int i = pow; i < 0; i++)
    {
        if (num >= 0) multi /= num; // 2^-3 // 2^-4
        if (num <= 0 && isOdd) multi /= num; // -2^-3 
        else if (num <= 0 && !isOdd) multi /= -num; // -2^-4
    }
}

Console.WriteLine(multi);
#endregion

#region Task 2: Ededin nece reqemli oldugu tapilsin
//int num = 12345;
//int digit;
//int count = 0;

//do
//{
//    digit = num % 10;
//    num = (num - digit) / 10;
//    count++;
//}
//while (num > 0);
//Console.WriteLine(count);
#endregion

#region Task 3: Arrayde reqemleri sayi tapilsin
//int[] arr = { 1, 77, 6, 14, 9 };
//int count = 0;

//foreach (int i in arr)
//{
//    if (i >= 0 && i < 10) count++;
//}
//Console.WriteLine(count);
#endregion