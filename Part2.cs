using System;

class Shell
{
    private static void ShellSort(int[] elements)
    {
        int length = elements.Length;

        for (int distance = length / 2; distance > 0; distance /= 2)
        {
            for (int i = distance; i < length; i++)
            {
                int keyelement = elements[i];
                int j;

                for (j = i; j >= distance && elements[j - distance] > keyelement; j -= distance)
                {
                    elements[j] = elements[j - distance];
                }
                elements[j] = keyelement;
            }
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 1, 4, 54, 25, 8,697 };

        Console.WriteLine("give");
        PrintArray(numbers);

        ShellSort(numbers);

        Console.WriteLine("sorted");
        PrintArray(numbers);
    }

    public static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write( element+ " ");
        }
        Console.WriteLine();
    }
}
