using ConsoleApp1;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string json = File.ReadAllText(filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine(" -> JSON file is empty.");
            return;
        }

        using JsonDocument doc = JsonDocument.Parse(json);

        int count = 0;

        if (doc.RootElement.ValueKind == JsonValueKind.Object)
        {
            count = doc.RootElement.EnumerateObject().Count();
            Console.WriteLine($" -> Parsed {count} root properties.");
        }
        else if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            count = doc.RootElement.EnumerateArray().Count();
            Console.WriteLine($" -> Parsed {count} root elements.");
        }

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(json.Substring(0, Math.Min(100, json.Length)));
        Console.WriteLine("----------------------------");
    }
}