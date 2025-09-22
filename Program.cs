using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD

            Application.Run(new WelcomeForm());
=======
            Application.Run(new Form1());
>>>>>>> 224e5f4 (Addthe dashboard page)
        }
    }
}
