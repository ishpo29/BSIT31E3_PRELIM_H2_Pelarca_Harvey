using ConsoleApp1;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        XDocument doc = XDocument.Load(filePath);

        if (doc.Root == null)
        {
            Console.WriteLine(" -> XML has no root element.");
            return;
        }

        string rootName = doc.Root.Name.ToString();
        int count = doc.Descendants().Count();

        Console.WriteLine($" -> Root element: <{rootName}> with {count} descendant nodes.");

        string content = doc.ToString();

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(content.Substring(0, Math.Min(100, content.Length)));
        Console.WriteLine("----------------------------");
    }
}
