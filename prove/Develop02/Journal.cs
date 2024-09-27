using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    // Add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }

    // Display all entries in the journal
    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
            return;
        }

        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    // Save the journal to a file
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.Date.ToString("g"));
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
                writer.WriteLine("-------------------------------");
            }
        }
        Console.WriteLine($"Journal saved to {file}");
    }

    // Load the journal from a file
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} does not exist.");
            return;
        }

        entries.Clear();  // Replace current journal entries

        string[] lines = File.ReadAllLines(file);
        for (int i = 0; i < lines.Length; i += 4)
        {
            DateTime date = DateTime.Parse(lines[i]);
            string prompt = lines[i + 1];
            string response = lines[i + 2];

            Entry entry = new Entry(prompt, response);
            entry.GetType().GetProperty("Date").SetValue(entry, date);  // Manually setting the date property
            entries.Add(entry);
        }

        Console.WriteLine($"Journal loaded from {file}");
    }
}
