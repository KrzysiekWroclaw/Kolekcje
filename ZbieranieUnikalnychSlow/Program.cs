using System;

class Program
{
    public static void Main(string[] args)
    {       
        Console.WriteLine("Program: Zbieranie unikalnych słów. Wprowadź tekst(wpisz \"koniec\", aby zakończyć):");
        string? entireText = Console.ReadLine();

        string[] words;
        if (entireText != "koniec" && entireText.Length != 0)
        {
            words = entireText.Split(' ');
        }
        else
        {
            Console.WriteLine("Program zakończony.");
            return;
        }

        Console.WriteLine("\nUnikalne słowa w tekście: ");
        HashSet<string> uniqueWords = new HashSet<string>();
        int i = 1;
        uniqueWords = words.ToHashSet();
        foreach (string word in uniqueWords)
        {
            Console.WriteLine($"{i++}. {word}");            
        }
    }
}