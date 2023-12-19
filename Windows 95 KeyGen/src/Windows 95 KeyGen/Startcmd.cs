using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_95_KeyGen
{
    public class Startcmd
    {
        public void launch_cmd(string cmdtoexecute)
        {
            Process cmdpros = new Process();
            ProcessStartInfo cmdstartinfo = new ProcessStartInfo();
            cmdstartinfo.FileName = "cmd.exe";
            cmdstartinfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmdstartinfo.Arguments = "/k " + cmdtoexecute;
            cmdpros.StartInfo = cmdstartinfo;
            cmdpros.Start();
        }
    }
}
