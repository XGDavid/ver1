using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateDatabaseFile();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }



        private static void CreateDatabaseFile()
        {

            if (File.Exists(Environment.CurrentDirectory + "\\db.xml"))
            {
                Debug.WriteLine("Fisierul deja exista");
            }
            else
            {
                new FileStream(Environment.CurrentDirectory + "\\db.xml", FileMode.Create, FileAccess.Write);
                Debug.WriteLine("Fisierul a fost creat");
            }
        }
    }

}

