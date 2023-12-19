using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_95_KeyGen.resources;

namespace Windows_95_KeyGen
{
    public class MainFile
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Windows 95 Key Generator");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        }
    }
}
