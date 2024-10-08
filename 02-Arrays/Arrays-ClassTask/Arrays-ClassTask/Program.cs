int[,] arr =
{
    {2, 4, 6, 8 },
    {1, 3, 5, 7 },
    {4, 6, 9, 2 },
    {7, 5, 6, 1 },
};

#region Task 1: Array elementlerin cemi
int sum = 0;
foreach (int i in arr)
{
    sum += i;
}
Console.WriteLine(sum);
#endregion;

#region Task 2: Array bas diagonal elementler cemi
//int sum = 0;
//for (int i = 0; i < arr.GetLength(0); i++)
//{
//    for (int j = 0; j < arr.GetLength(1); j++)
//    {
//        if (i == j) sum += arr[i, j];
//    }
//}
//Console.WriteLine(sum);
#endregion

#region Task 3: Array Bas diagonal ve ondan yuxaridaki elementler cemi
//int sum = 0;
//for (int i = 0; i < arr.GetLength(0); i++)
//{
//    for (int j = 0; j < arr.GetLength(1); j++)
//    {
//        if (i <= j) sum += arr[i, j];
//    }
//}
//Console.WriteLine(sum);
#endregion

#region Task 4: Array bas diagonaldan yuxari olan ededlerin ceminden asagida olan ededlerin ceminin ferqi
//int sumBelow = 0;
//int sumAbove = 0;
//int result;
//for (int i = 0; i < arr.GetLength(0); i++)
//{
//    for (int j = 0; j < arr.GetLength(1); j++)
//    {
//        if (i > j)
//        {
//            sumBelow += arr[i, j];
//        }
//        else if (i < j)
//        {
//            sumAbove += arr[i, j];
//        }
//    }
//}
//result = sumAbove - sumBelow;
//Console.WriteLine(result);
#endregion