using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WinFormsApp
{
    /// <summary>
    /// Programiin ehleliin undsen klass.
    /// Entry point buyu main() funktsees Windows Forms app eheldeg.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Programiin gol ehlel.LOGin gorm g anh uzuulne
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}