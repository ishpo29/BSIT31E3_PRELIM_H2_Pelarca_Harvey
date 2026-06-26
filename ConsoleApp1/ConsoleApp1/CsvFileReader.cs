using ConsoleApp1;
using System;
using System.IO;

public class CsvFileReader : BaseFileReader
{
    public override string SupportedFormat => "CSV";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV stream...");

        var lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
        {
            Console.WriteLine(" -> CSV file is empty.");
            return;
        }

        int rows = lines.Length;
        int columns = lines[0].Split(',').Length;

        Console.WriteLine($" -> Detected {rows} rows and {columns} columns.");

        string content = string.Join("\n", lines);

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(content.Substring(0, Math.Min(100, content.Length)));
        Console.WriteLine("----------------------------");
    }
}