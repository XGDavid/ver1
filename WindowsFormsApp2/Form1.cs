using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Person>));

            if (File.Exists(Environment.CurrentDirectory+"\\db.xml"))
            {
                MessageBox.Show("Fisierul deja exista");
            }else{

                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\db.xml", FileMode.Create, FileAccess.Write))
                {
                    /*p1.Add(new Person() { Id = 1, Name = "cumva", Pass = "parola"});
                    p1.Add(new Person() { Id = 2, Name = "cumva"});*/

                    serial.Serialize(fs, p1);
                    MessageBox.Show("creat");
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
