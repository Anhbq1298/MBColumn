using System;
using MBColumn.Infrastructure.Persistence;

class Program
{
    static void Main()
    {
        try
        {
            using var svc = new ProjectService();
            svc.NewProject(""Test"");
            svc.AddGroup(""My Group"");
            Console.WriteLine(""Success!"");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
