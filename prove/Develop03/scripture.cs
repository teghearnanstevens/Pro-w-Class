using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        Random rand = new Random();
        List<Word> visibleWords = _words.Where(w => w.IsVisible()).ToList();

        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // prevent hiding the same word twice
        }
    }

    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetText()));
        return $"{_reference.GetDisplayText()}\n{wordsText}";
    }


    public void DisplayScripture()
    {
        Console.WriteLine(_reference.GetDisplayText());
        foreach (Word word in _words)
        {
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }

    public string GetReference()
    {
        return _reference.GetDisplayText();
    }

    public void RemoveWord()
    {

        List<Word> visibleWords = _words.Where(w => w.IsVisible()).ToList();

        if (visibleWords.Count > 0)
        {
            Random rand = new Random();
            Word wordToHide = visibleWords[rand.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }


    public static List<Scripture> LoadScriptures(string filePath)
{
    List<Scripture> scriptures = new List<Scripture>();
    string[] lines = File.ReadAllLines(filePath);

    for (int i = 0; i < lines.Length; i += 2)
    {
        string referenceLine = lines[i].Trim();       
        string textLine = lines[i + 1].Trim();        

       
        int lastSpaceIndex = referenceLine.LastIndexOf(' ');
        string book = referenceLine.Substring(0, lastSpaceIndex);
        string chapterVerse = referenceLine.Substring(lastSpaceIndex + 1);

        string[] chapterVerseParts = chapterVerse.Split(':');
        int chapter = int.Parse(chapterVerseParts[0]);

        
        string versePart = chapterVerseParts[1].Split('-')[0];
        int verse = int.Parse(versePart);

        Reference reference = new Reference(book, chapter, verse);
        Scripture scripture = new Scripture(reference, textLine);

        scriptures.Add(scripture);
    }

    return scriptures;
}



}
