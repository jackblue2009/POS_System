using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CashierApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Process.Start(Path.Combine(Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName, "Sysnative", "cmd.exe"), "/c osk.exe");
            //Process.Start(@"c:\Windows\Sysnative\cmd.exe", "/c osk.exe");
        }
    }
}
