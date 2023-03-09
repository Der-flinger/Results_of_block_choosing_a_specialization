// Написать программу, которая из имеющегося массива строк формирует массив строк, 
// длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с 
// клавиатуры либо создать в начале выполнения алгоритма. При решении обойтись только статическими массивами

using System.Text;
Console.Clear();

System.Console.Write("Введите длину базового массива: ");
int arrayLength = Convert.ToInt32(Console.ReadLine()!);
// System.Console.WriteLine("Выберите метод заполнения базового массива");
System.Console.Write("Введите 1 для ввода строк с клавиатуры или 2 для случайного заполнения: ");

string[] baseArray = new string[arrayLength];
int fillingMethod = int.Parse(Console.ReadLine()!);

switch(fillingMethod)                                               // переключатель для выбора метода ввода элементов массива
{
    case 1:                                                         // кейс, в котором вводим строки вручную
        System.Console.WriteLine($"Введите строки, кол-во которых равно {arrayLength}, каждую на отдельной строке");
        FillArray1(baseArray, arrayLength);                         // метод для заполнения базового массива вручную
        System.Console.WriteLine();
        break;
    case 2:                                                         // кейс, в котором строки генерируются случайно
        System.Console.Write("Введите максимальную длину одного элемента массива: ");
        int strMaxLength = Convert.ToInt32(Console.ReadLine());     // strMaxLength нужен для фиксации максимальной длины строки массива
        FillArray2(baseArray, arrayLength, strMaxLength);           // метод для заполнения массива рандомными строками,    
        System.Console.WriteLine();                                 
        break;
    default:
        System.Console.WriteLine($"Вы ввели неверный символ, введите 1 или 2");
        return;
}

System.Console.WriteLine("Элементы базового массива ниже");
PrintArray(baseArray, arrayLength);                                 // выводим базовый массив в консоли для наглядности
System.Console.WriteLine("\n");

System.Console.WriteLine("Итоговый массив ниже");                   
string[] resultArray = GetResultArray(baseArray, arrayLength);
PrintArray(resultArray, resultArray.Length);                        // выводим конечный массив в консоли для наглядности

void FillArray1 (string[] array, int length)                        // метод для заполнения базового массива вручную
{
    for (int i = 0; i < length; i++)
    {
        array[i] = Console.ReadLine()!;
    }
}

void FillArray2(string[] array, int length, int strMaxLength)       // метод, заполняющий базовый массив случайными элементами
{
    string[] symbols = {"a", "b" ,"c", "d", "e", "f" ,"g", "h", "i", "g" ,"k", "1", "2", "3" ,"4", "5", "6", "7" ,"8", "9"};
    string randomString = string.Empty;                                 // строка, которая нужна для рандомизации
    int randomStringLength = new Random().Next(1, strMaxLength + 1);    // длина рандомизированной строки
    for (int i = 0; i < length; i++)                                    // цикл для перебирания элементов базового массива
    {
        for (int j = 0; j < randomStringLength; j++)                    // цикл для записи случайного символа в рандомизированную строку
        {
            randomString += symbols[new Random().Next(0, symbols.Length)];  // генерируем случайную строку из элементов массива symbol
        }
        array[i] = randomString;                                            // записываем ее в итоговый массив
        randomString = string.Empty;                                        // обнуляем случайную строку
        randomStringLength = new Random().Next(1, strMaxLength);            // рандомизируем длину случайной строки
    }
}

void PrintArray(string[] array, int length)                         // метод для выведения массива на экран
{
    for (int i = 0; i < length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}

string[] GetResultArray(string[] array, int length)                 // метод для получения отфильтрованного массива
{
    int count = 0;                                                  // переменная для подсчета элементов длиной 3 или меньше
    int index = 0;                                                  // переменная для перебирания элементов итогового массива
    for (int i = 0; i < length; i++)                                
    {
        if (array[i].Length <= 3) count++;                          // определяем сколько элементов длиной 3 или меньше
    }
    string[] newArray = new string[count];                          // создаем массив размером в count 
    for (int i = 0; i < length; i++)
    {
        if (array[i].Length <= 3)                                   // если елемент базового массива имеет длину 3 или меньше, то
        {
            newArray[index] = array[i];                             // записываем его в итоговый массив
            index++;                                                // увеличивем индекс, чтобы перейти на следующий элемент итогового массива
        }
    }
    System.Console.WriteLine($"Кол-во элементов длиной в три символа или меньше равно {count}");
    return newArray;
}