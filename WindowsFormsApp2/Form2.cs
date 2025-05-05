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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Serialization;
using WindowsFormsApp2;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;
            var confirm = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Baga si numele si parola");
                return;
            }

            if(!string.Equals(password, confirm))
            {
                MessageBox.Show("Parola si confirmarea parolei nu e matched");
                return;
            }

            var newUser = new User
            {
                Name = username,
                Pass = password,
                IsAdmin = false
            };

            SaveUserToDatabase(newUser);

            textBox1.Text = "";
            textBox2.Text = "";
            this.Hide();
            new Form1().Show();
        }




        private static void SaveUserToDatabase(User user)
        {
            var path = Environment.CurrentDirectory + "\\db.xml";
            var users = new List<User>();

            var serializer = new XmlSerializer(typeof(List<User>));
            if (File.Exists(path) && new FileInfo(path).Length > 0)
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    users = (List<User>)serializer.Deserialize(fs);
                }
            }
            else { 
                Debug.WriteLine("Fisierul nu exista");
            }

            users.Add(user);

            var writer = new XmlSerializer(typeof(List<User>));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                writer.Serialize(fs, users);
            }

            MessageBox.Show("User saved successfully.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
