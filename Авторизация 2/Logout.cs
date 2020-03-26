using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Авторизация_2
{
    public partial class Logout : Form
    {
        public Logout()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int login = 0;
            string role = "";
            using (SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP - 4DMKEP1; Integrated Security = True"))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Count(*) FROM [User] WHERE Email='" + textBox1.Text + "'AND Password = '" + textBox2.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    login = Convert.ToInt32(reader[0]);
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "SELECT RoleId FROM [User] WHERE Email='" + textBox1.Text + "'AND Password = '" + textBox2.Text + "'";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    role = reader1[0].ToString();
                }
                conn.Close();
            }
            if (login == 1)
            {
                File.WriteAllText("Resources/login.txt", textBox1.Text);
                if (role == "R")
                {
                    Runner Run = new Runner();
                    Run.Show();
                    this.Hide();
                }
                else
                {
                    if (role == "A")
                    {
                        Admin Ad = new Admin();
                        Ad.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (role == "C")
                        {
                            Coordinator Coor = new Coordinator();
                            Coor.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильный логин/пароль.");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2017 6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            Timer.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            More Main = new More();
            Main.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            More Main = new More();
            Main.Show();
            this.Hide();

        }
    }
}
