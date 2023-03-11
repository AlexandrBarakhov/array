// Итоговая проверочная работа
/* 
Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых
меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры, либо задать на старте
выполнения алгоритма. При решении обойтись исключительно массивами.
Примеры:
["hello","2","world",":-)"] -> ["2",":-)"]
["1234","1567","-2","computer science"] -> ["-2"]
["Russia","Denmark","Kazan"] -> []
*/
static void FillArray(string?[] arr, int ch)
{
    int rnd;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        rnd = new Random().Next(1,ch+1);  // [1;ch]
        for (int j =0 ; j < rnd; j++)
        {
            arr[i] = arr[i] + (char) new Random().Next(33,91); // [33;91)
        //    !"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ
        }
    }
}

static void PrintArray(string?[] arr)
{
    System.Console.Write("[ ");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        System.Console.Write($"{arr[i]} ");  
    } 
    System.Console.WriteLine("]");
}

static string[] ProcessArray(string[] arr)
{
    for (int i = 0; i < arr.GetLength(0); )
    {
        if ( arr[i].Length > 3 )  // если текущий элемент массива имеет длину больше трех символов 
        arr = RemoveAt( arr, i ); // то делаем RemoveAt этому элементу (удаляем его и уменьшаем длину массива на 1)
        else i++;                 // иначе ничего не далаем и переходим к следующему элементу
    }
    return arr;
}

static Key[] RemoveAt<Key> (Key[] source, int index)
{
    Key[] dest = new Key[source.Length - 1];
    if ( index > 0 )
        Array.Copy(source, 0, dest, 0, index);
    if ( index < source.Length - 1 )
        Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
    return dest;
}

int elements=10;  // кол-во элементов первоначального массива  
int сharacters=8; // максимальное кол-во символов в элементе первоначального массива
string[] array = new string[elements];
FillArray(array,сharacters);
PrintArray(array);
array=ProcessArray(array);
PrintArray(array);