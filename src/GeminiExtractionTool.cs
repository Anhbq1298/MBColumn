using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MBColumn.Application.Services;
using MBColumn.Domain.Entities;
using MBColumn.Infrastructure.Services;
using MBColumn.Tests.Verification;

namespace MBColumn.Tests;

/// <summary>
/// Wrapper to run Gemini extraction as a standalone executable
/// This can be invoked directly without needing the full test runner
/// </summary>
public class GeminiExtractionTool
{
    static void Main(string[] args)
    {
        Console.WriteLine("=" * 100);
        Console.WriteLine("GEMINI DOCX EXTRACTION TOOL");
        Console.WriteLine("=" * 100);
        
        var repoRoot = LocateRepositoryRoot();
        var geminiFile = Path.Combine(repoRoot, "Gemini_NvsM_Test_Package_v2.docx");
        
        Console.WriteLine($"\nLooking for: {geminiFile}");
        
        if (!File.Exists(geminiFile))
        {
            Console.WriteLine($"✗ File not found: {geminiFile}");
            return;
        }
        
        Console.WriteLine($"✓ File found, size: {new FileInfo(geminiFile).Length} bytes");
        
        // Try to read with Python script
        Console.WriteLine("\nAttempting to extract with python-docx...");
        try
        {
            ExtractWithPython(repoRoot, geminiFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Python extraction failed: {ex.Message}");
            Console.WriteLine("\nPlease run one of these Python scripts directly:");
            Console.WriteLine("  1. python simple_gemini_read.py");
            Console.WriteLine("  2. python minimal_gemini_extract.py");
            Console.WriteLine("  3. python analyze_gemini.py");
        }
    }
    
    static void ExtractWithPython(string repoRoot, string geminiFile)
    {
        var scriptPath = Path.Combine(repoRoot, "minimal_gemini_extract.py");
        
        if (!File.Exists(scriptPath))
        {
            Console.WriteLine($"✗ Script not found: {scriptPath}");
            return;
        }
        
        Console.WriteLine($"Running: {scriptPath}");
        
        try
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"\"{scriptPath}\"",
                WorkingDirectory = repoRoot,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            
            using (var process = System.Diagnostics.Process.Start(psi))
            {
                var output = process.StandardOutput.ReadToEnd();
                var errors = process.StandardError.ReadToEnd();
                
                process.WaitForExit();
                
                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine(output);
                }
                
                if (!string.IsNullOrEmpty(errors))
                {
                    Console.WriteLine("STDERR:");
                    Console.WriteLine(errors);
                }
                
                if (process.ExitCode == 0)
                {
                    Console.WriteLine("\n✓ Extraction successful");
                    
                    // Try to read the JSON output
                    var jsonFile = Path.Combine(repoRoot, "gemini_extracted.json");
                    if (File.Exists(jsonFile))
                    {
                        Console.WriteLine($"✓ Output saved to: {jsonFile}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to run Python: {ex.Message}");
        }
    }
    
    static string LocateRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory != null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "MBColumn.sln")))
            {
                return directory.FullName;
            }
            directory = directory.Parent;
        }
        throw new InvalidOperationException("Could not find MBColumn.sln");
    }
}
