using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace FileRunnerService
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(doWork);
            timer.Interval = 1000 * 60 * 5; // All 5 minutes
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        private void doWork(object source, ElapsedEventArgs e)
        {
            string fileName = "C:\\ProgramData\\input-file.txt";
            string inputstring = File.ReadAllText(fileName);
            if (inputstring.Length > 2)
            {
                foreach (string line in inputstring.Split('\n'))
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C " + line;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                }

                File.WriteAllText(fileName, string.Empty);
            }
        }
    }
}
