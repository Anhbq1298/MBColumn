using System;
using System.IO;
using MBColumn.Infrastructure.Persistence;

class Program {
    static void Main() {
        if (File.Exists("test_flow.mbc")) File.Delete("test_flow.mbc");
        if (File.Exists("test_flow.mbcr")) File.Delete("test_flow.mbcr");

        using var ps = new ProjectService();
        ps.NewProject("My Flow Project");
        ps.AddColumn("Col 1"); // triggers in-memory DB creation

        Console.WriteLine($"Before SaveAs: CurrentFilePath is null? {ps.CurrentFilePath == null}");
        
        try {
            ps.SaveProjectAs("test_flow.mbc");
            Console.WriteLine($"After SaveAs: CurrentFilePath: {ps.CurrentFilePath}");
            
            // Now hit save again
            ps.SaveProject();
            Console.WriteLine("SaveProject() succeeded!");
        } catch (Exception ex) {
            Console.WriteLine($"ERROR: {ex}");
        }
    }
}
