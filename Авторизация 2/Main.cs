﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Авторизация_2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckRunner CheckRunner = new CheckRunner();
            CheckRunner.Show();
            this.Hide();

        }

        private void Timer_Click(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2017 6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            Timer.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString() + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";

        }

        private void button3_Click(object sender, EventArgs e)
        {
           More  More = new More();
            More.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logout Login = new Logout();
            Login.Show();
            this.Hide();

        }
    }
}
