using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    public static List<Scripture> LoadScriptures(string filePath)
    {
        var scriptures = new List<Scripture>();
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length - 1; i += 2)
        {
            string referenceLine = lines[i].Trim();
            string textLine = lines[i + 1].Trim();

            Reference reference = new Reference(referenceLine);
            Scripture scripture = new Scripture(reference, textLine);

            scriptures.Add(scripture);
        }

        return scriptures;
    }
}
