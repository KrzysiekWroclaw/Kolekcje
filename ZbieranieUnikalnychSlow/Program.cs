using System;

class Program
{
    public static void Main(string[] args)
    {
        HashSet<string> uniqueWords = new HashSet<string>();
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
        int i = 1;
        foreach (string word in words)
        {
            while (!uniqueWords.Contains(word))
            {
                uniqueWords.Add(word);
                Console.WriteLine($"{i}. {word}");
                i++;
            }

        }
    }
}