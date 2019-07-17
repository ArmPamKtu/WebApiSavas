using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure
{
    public class FileLogger : IMyLogger
    {
        
        public FileLogger(IMyTime time)
        {
            var Time = time;
        }
        public void Log(string message)
        {
            File.AppendAllText(@"C:\Dev\Day2\WebApiSavas\WebApitwo\text.txt", message + Environment.NewLine);
        }
    }
}
