
int[,] CreateRandom2dArray()  // Создание произвольного думерного массива
{
     Console.Write("Input a number of rows: ");
     int rows = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a number of columns: ");
     int columns = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a min possible value: ");
     int minValue = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a max possible value: ");
     int maxValue = Convert.ToInt32(Console.ReadLine());
     
     int[,] array = new int[rows, columns];

     for(int i = 0; i < rows; i++)
          for(int j = 0; j < columns; j++)
               array[i,j] = new Random().Next(minValue, maxValue + 1);
     return array;
}

void Show2dArray(int[,] array) // Вывод на экран заданного двумерного массива
{
     for(int i = 0; i < array.GetLength(0); i++)
     {
          for(int j = 0; j < array.GetLength(1); j++)
               Console.Write(array[i, j].ToString("D2") + " ");
          Console.WriteLine();
     }
}

/*
// Задача 54:
// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
// элементы каждой строки двумерного массива.

void MaxToMinInRowsArray(int[,] array) //  Упорядочивание всех строк массива от Мах к Мин
{
     for(int i = 0; i < array.GetLength(0); i++)
     {
          for(int count = 0; count < array.GetLength(1); count++)
          {
               int max = array[i, count];
                    int maxIndex = count;
                    for (int j = count; j < array.GetLength(1); j++)
                    {
                        if (max < array[i, j])
                        {
                            maxIndex = j;
                            max = array[i, j];
                        }
                    }
                    int temp = array[i, count];
                    array[i, count] = array[i, maxIndex];
                    array[i, maxIndex] = temp;
          }
     }
}

int[,] myArray = CreateRandom2dArray();
Show2dArray(myArray);
Console.WriteLine();
MaxToMinInRowsArray(myArray);
Show2dArray(myArray);
*/

//////////////////////////////////////////////////////////////////////////////////////////////

/*
// Задача 56: 
// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int FindRowWihtMinSumElements(int[,] array) // Находит строку с минимальной суммой элементов
{
     int sumFirst = 0;
     int row = 0;
     for(int i = 0, j = 0; j < array.GetLength(1); j++)
          sumFirst += array[i,j];
     for (int i = 1; i < array.GetLength(0); i++)
     {
          int sum = 0;
          for (int j = 0; j < array.GetLength(1); j++)
               sum += array[i,j];
          if(sum < sumFirst) row = i;         
     }
     return row+1;
}

int[,] myArray = CreateRandom2dArray();
Show2dArray(myArray);
Console.WriteLine();
int row = FindRowWihtMinSumElements(myArray);
Console.WriteLine($"Answer: {row} row with minimum sum of elements");
*/

//////////////////////////////////////////////////////////////////////////////////////////////

/*
// Задача 58: 
// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

// Перемножение матриц должно быть: A(i m) * B(m j) = C(i j)

int[,] MultiplicationArrays(int[,] arrayA, int[,] arrayB)
{
     int[,] newArray = new int[arrayA.GetLength(0),arrayB.GetLength(1)];
     for(int i = 0; i < arrayA.GetLength(0); i++)
     {
          for (int j = 0; j < arrayB.GetLength(1); j++)
          {
               int sum = 0;
               for(int m = 0; m < arrayA.GetLength(1); m++)
                    sum += arrayA[i,m] * arrayB[m,j];
               newArray[i,j] = sum;
          }
     }
     return newArray;
}

Console.WriteLine("Enter first Martix: ");
int[,] arrayA = CreateRandom2dArray();
Console.WriteLine("Enter second Martix: ");
int[,] arrayB = CreateRandom2dArray();
if(arrayA.GetLength(1) != arrayB.GetLength(0)) 
     Console.WriteLine("Fail! This array can't be a a multiplicated!!!");
else
{
     Show2dArray(arrayA);
     Console.WriteLine();
     Show2dArray(arrayB);
     int[,] multiArrayAB = MultiplicationArrays(arrayA, arrayB);
     Console.WriteLine("Result of multiplication is: ");
     Show2dArray(multiArrayAB);
}
*/

//////////////////////////////////////////////////////////////////////////////////////////////

/*
// Задача 60.
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] CreateRandom3dArray()
{
     Console.Write("Input a number of rows: ");
     int rows = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a number of columns: ");
     int columns = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a number of columns: ");
     int numbers = Convert.ToInt32(Console.ReadLine());
     
     int[,,] array = new int[rows, columns, numbers];
     int max = 0;
     for(int n = 0; n < numbers; n++)
          for(int i = 0; i < rows; i++)
               for(int j = 0; j < columns; j++)
               {
                    array[i,j,n] = new Random().Next(1,50);
                    if(array[i,j,n] > max) max = array[i,j,n];
               }
     for(int n = 0; n < numbers; n++)
          for(int i = 0; i < rows; i++)
               for(int j = 0; j < columns; j++)
               {
                    int temp = array[i,j,n];
                    for(n = 0; n < numbers; n++)
                         for(i = 0; i < rows; i++)
                         for(j = 0; j < columns; j++)
                         {
                              if(array[i,j,n] == temp) array[i,j,n] = max++;
                         }
               }
     return array;
}

void Show3dArray(int[,,] array) // Вывод на экран заданного трехмерного массива
{
     for(int n = 0; n < array.GetLength(2); n++)
     {
          for(int i = 0; i < array.GetLength(0); i++)
          {
               for (int j = 0; j < array.GetLength(1); j++)
               {
               Console.Write($"{array[i,j,n].ToString("D2")}({i},{j},{n})\t");
               }
               Console.WriteLine("");
          }
     }
}
int[,,] f = CreateRandom3dArray();
Show3dArray(f);
*/

//////////////////////////////////////////////////////////////////////////////////////////////

 /*

// Задача 62.
// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// Два дня над ней сидела!!! =) зато она заполняет спирально любой массив =)

int[,] ArrayFillSnail()
{
     Console.Write("Input a number of rows: ");
     int rows = Convert.ToInt32(Console.ReadLine());
     Console.Write("Input a number of columns: ");
     int columns = Convert.ToInt32(Console.ReadLine());
     int[,] array = new int[rows, columns];
     int start = 0;
     int count = 1;
     int countMax = array.GetLength(0)*array.GetLength(1); 
     while(true)
     {
          for(int i = start, j = start; j < columns; j++)
               array[i,j] = count++;
          columns--;
          if(count > countMax) break;
          for(int j = columns, i = start+1; i < rows; i++)
               array[i,j] = count++;
          rows--;
          if(count > countMax) break;
          for(int i = rows, j = columns-1; j >= start; j--)
               array[i,j] = count++;
          if(count > countMax) break;
          for(int j = start, i = rows-1; i > start; i--)
               array[i,j] = count++;
          if(count > countMax) break;
          start++;
     }
     return array;
}

Show2dArray(ArrayFillSnail());
*/


// // Если не затруднит, подскажите почему так происходит: почему такие ответы выдает программа
// // когда, казалось бы, с точки зрения математики, тут все очень даже однозначно должно быть
// // (при чем не важно INT или Double умножаю на вещественное число, результат одинаковый)
// double a = 0.3 * (double)3.0; // не ровно 0.9
// double b = 0.2 * (double)3.0; // не ровно 0.6
// double c = 0.4 * (double)3.0; // не ровно 1.2
// Console.WriteLine(a);
// Console.WriteLine(b);
// Console.WriteLine(c);
// // Спасибо =)
