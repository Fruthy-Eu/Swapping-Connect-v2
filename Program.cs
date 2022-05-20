using System;
using System.Windows.Forms;
using SwappingConnectV2.Main.GUI;

namespace SwappingConnectV2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
