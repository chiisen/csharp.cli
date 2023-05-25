using System.Diagnostics;
using System.Management.Automation;

public partial class Program
{
    public class PowerShellHelper
    {
        public void Execute(string command)
        {
            using (var ps = PowerShell.Create())
            {
                var results = ps.AddScript(command).Invoke();
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}
