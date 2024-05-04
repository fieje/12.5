using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestReadWordsFromFile_FileExists_StackNotEmpty()
    {
        string filePath = "text.txt"; 
        Stack<string> wordsStack = new Stack<string>();

        ReadWordsFromFile(filePath, wordsStack);

        Assert.IsTrue(wordsStack.Count > 0);
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
}
