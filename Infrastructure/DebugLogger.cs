using Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Infastructure
{
    public class DebugLogger : IMyLogger
    {
        public DebugLogger(IMyTime time)
        {
            var Time = time;
        }
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
