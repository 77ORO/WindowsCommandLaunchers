using System;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace PowerShellRunner
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length < 2)
            {
                Console.WriteLine("Usage: <this-exe-name> <filename-with-commands>");
            } else
            { 
                string fileName = arguments[1];
                string cmd = File.ReadAllText(fileName);
                Runspace rs = RunspaceFactory.CreateRunspace();
                rs.Open();
                PowerShell ps = PowerShell.Create();
                ps.Runspace = rs;
                ps.AddScript(cmd);
                ps.Invoke();
                rs.Close();
            }
        }
    }
}
