using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using task_trackerVS.Models;

namespace task_trackerVS
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskTrackerDbContext db = new TaskTrackerDbContext())
                {
                    var users = db.Users.AsNoTracking().ToList();
                    User g = users.FirstOrDefault(p => p.Login == textBoxLogin.Text && p.Password == textBoxPassword.Text);
                    if (g != null)
                    {
                        
                        MainForm main = new MainForm();
                        this.Hide();
                        
                        main.Show();
                    }
                    else
                        MessageBox.Show("Неверный логин или пароль.Попробуйте ещё раз", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Не подключена БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxLoginPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Length < 3 || textBoxPassword.Text.Length < 3)
            {
                buttonEnter.Enabled = false;
            }
            else
                buttonEnter.Enabled = true;
        }
    }
}
