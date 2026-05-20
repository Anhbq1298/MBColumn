using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MBColumn.Presentation.Wpf.Services;

public sealed class RecentProjectsService
{
    private readonly string filePath;
    private const int MaxEntries = 8;

    public RecentProjectsService()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var dir = Path.Combine(appData, "MBColumn");
        Directory.CreateDirectory(dir);
        filePath = Path.Combine(dir, "recent.json");
    }

    public IReadOnlyList<string> GetRecent()
    {
        try
        {
            if (!File.Exists(filePath)) return Array.Empty<string>();
            var json = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            return list.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
        }
        catch
        {
            return Array.Empty<string>();
        }
    }

    public void AddRecent(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return;
        try
        {
            var list = GetRecent().ToList();
            list.RemoveAll(p => string.Equals(p, path, StringComparison.OrdinalIgnoreCase));
            list.Insert(0, path);
            if (list.Count > MaxEntries) list = list.Take(MaxEntries).ToList();
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(filePath, json);
        }
        catch
        {
            // ignore errors silently
        }
    }
}
