using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "text.txt";

        Stack<string> wordsStack = new Stack<string>();

        ReadWordsFromFile(filePath, wordsStack);

        Console.WriteLine("Stack contents:");
        PrintStackContents(wordsStack);

        int stackLength = CalculateStackLength(wordsStack);
        Console.WriteLine($"Stack length: {stackLength}");

        Dictionary<string, int> wordCounts = CountWordOccurrences(wordsStack);
        foreach (var pair in wordCounts)
        {
            Console.WriteLine($"Word '{pair.Key}' occurs {pair.Value} times");
        }

        FindLongestAndShortestWord(wordsStack);

        Console.ReadLine();
    }

    static void ReadWordsFromFile(string filePath, Stack<string> wordsStack)
    {
        try
        {
            string[] words = File.ReadAllText(filePath).Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                wordsStack.Push(word);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void PrintStackContents(Stack<string> wordsStack)
    {
        foreach (string word in wordsStack)
        {
            Console.WriteLine(word);
        }
    }

    static int CalculateStackLength(Stack<string> wordsStack)
    {
        return wordsStack.Count;
    }

    static Dictionary<string, int> CountWordOccurrences(Stack<string> wordsStack)
    {
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in wordsStack)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }
        return wordCounts;
    }

    static void FindLongestAndShortestWord(Stack<string> wordsStack)
    {
        if (wordsStack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        string longestWord = "";
        string shortestWord = wordsStack.Peek();
        int longestWordIndex = -1;
        int shortestWordIndex = -1;
        int currentIndex = 0;

        foreach (string word in wordsStack)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
                longestWordIndex = currentIndex;
            }

            if (word.Length < shortestWord.Length)
            {
                shortestWord = word;
                shortestWordIndex = currentIndex;
            }

            currentIndex++;
        }

        Console.WriteLine($"Longest word: '{longestWord}', index: {longestWordIndex}");
        Console.WriteLine($"Shortest word: '{shortestWord}', index: {shortestWordIndex}");
    }
}
