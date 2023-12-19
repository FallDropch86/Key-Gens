using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Windows_95_KeyGen.resources
{
    public partial class Window : Form
    {
        bool onekeygrntdalrdy = false;
        bool Mousedownformoving;
        string finalResult;
        private Point offset;

        Startcmd startcmd = new Startcmd();
        
        public Window()
        {
            InitializeComponent();
            ActTypeDropDown.SelectedIndex = 0;
        }

        private void falldrpch_Click(object sender, EventArgs e)
        {

        }

        private void titletxt_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            Mousedownformoving = true;
        }

        private void falldrpch_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            Mousedownformoving = true;
        }

        private void win95trnsprnt_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            Mousedownformoving = true;
        }

        private void falldrpch_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedownformoving == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void win95trnsprnt_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedownformoving == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void titletxt_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedownformoving == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            Mousedownformoving = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedownformoving == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void Closebtn_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            Mousedownformoving = true;
        }

        private void Closebtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mousedownformoving == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void titletxt_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedownformoving = false;
        }

        private void Closebtn_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedownformoving = false;
        }

        private void win95trnsprnt_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedownformoving = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedownformoving = false;
        }

        private void falldrpch_MouseUp(object sender, MouseEventArgs e)
        {
            Mousedownformoving = false;
        }

        private void github_link_btn_Click(object sender, EventArgs e)
        {
            startcmd.launch_cmd("start https://github.com/FallDropch86");
        }

        private void generatekey_btn_Click(object sender, EventArgs e)
        {
            if (ActTypeDropDown.SelectedIndex == 0)
            {
                /* Windows 95 key format for OEM Activation:
                XXXYY-OEM-00SSSSS-ZZZZZ
                X segment means: Ordinal of the day (001-366).
                Y segment means: the year (95-03).
                OEM AND 00 remain the same (pre-defined constants).
                S segment means sum of numbers that make up
                a number divisble by 7. Some numbers like 00000
                and 7000 are restricted.
                The last segment - z will have random numbers.*/

                // Now we can implement this algorithm...:

                Random rand = new Random();

                int xsegrand = rand.Next(1, 367);
                int[] ysegrandlist = { 95, 96, 97, 98, 99, 0, 1, 2, 3 };
                int ysegrand = rand.Next(ysegrandlist.Length);
                int ysegslctd = ysegrandlist[ysegrand];
                int sseggrntd;
                int sumofdigits;
                int zsegrand = rand.Next(0, 100000);

                do
                {
                    sseggrntd = rand.Next(100000);
                    sumofdigits = 0;

                    int tempnum = sseggrntd;

                    while (tempnum != 0)
                    {
                        sumofdigits += tempnum % 10;
                        tempnum /= 10;
                    }
                } while (sumofdigits % 7 != 0);

                const string dash = "-";
                string xseg = xsegrand.ToString("D3");
                string yseg = ysegslctd.ToString("D2");
                const string OEM = "OEM";
                const string zeroes = "00";
                string sseg = sseggrntd.ToString("D5");
                string zseg = zsegrand.ToString("D5");

                // Here is the final result
                string finalResult = xseg + yseg + dash + OEM + dash + zeroes + sseg + dash + zseg;

                // Let us just print the key for debugging
                Console.WriteLine(finalResult);

                // Let us finally set the value
                this.GeneratedKey_Label.Text = finalResult;
                this.GeneratedKey_Label.Location = new Point(190, 105);
            }
            else if (ActTypeDropDown.SelectedIndex == 1)
            {
                /*Windows 95 key format for Retail Activation: 
                XXX-YYYYYYY
                X segment means: any random number with the exception
                that it must not be equal to 333, 444, 555, 666, 777, 
                888, 999.
                Y segment means: sum of numbers that make up
                a number divisble by 7.*/

                // Now we can implement this algorithm...:

                Random rand = new Random();

                int xsegrand = rand.Next(0, 1000);
                int yseggrntd;
                int sumofdigits;

                do
                {
                    yseggrntd = rand.Next(10000000);
                    sumofdigits = 0;

                    int tempnum = yseggrntd;

                    while (tempnum != 0)
                    {
                        sumofdigits += tempnum % 10;
                        tempnum /= 10;
                    }
                } while (sumofdigits % 7 != 0);

                const string dash = "-";
                string xseg = xsegrand.ToString("D3");
                string yseg = yseggrntd.ToString("D7");

                // Here is the final result
                string finalResult = xseg + dash + yseg;

                // Let us just print the key for debugging
                Console.WriteLine(finalResult);

                // Let us finally set the value
                this.GeneratedKey_Label.Text = finalResult;
                this.GeneratedKey_Label.Location = new Point(260, 105);
            }
        }

        private void GeneratedKey_Label_Click(object sender, EventArgs e)
        {
            
        }

        [STAThread]
        private void CpyKeyClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GeneratedKey_Label.Text);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}   