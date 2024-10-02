using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_trackerVS.Models;

namespace task_trackerVS
{
    public partial class UserControlCard : UserControl
    {
        public UserControlCard()
        {
            InitializeComponent();
        }

        private void UserControlCard_Load(object sender, EventArgs e)
        {
        }

        //private bool isDragging = false;
        //private Point dragCursorPoint;
        //private Point dragCardPoint;
        private void UserControlCard_MouseMove(object sender, MouseEventArgs e)
        {

            //if (isDragging)
            //{
            //    Point delta = new Point(Cursor.Position.X - dragCursorPoint.X, Cursor.Position.Y - dragCursorPoint.Y);
            //    this.Location = new Point(dragCardPoint.X + delta.X, dragCardPoint.Y + delta.Y);
            //}

        }

        private void UserControlCard_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    isDragging = true;
            //    dragCursorPoint = Cursor.Position;
            //    dragCardPoint = this.Location;
            //}
        }

        private void UserControlCard_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    isDragging = false;
            //}
        }

        private void UserControlCard_Click(object sender, EventArgs e)
        {
        }

        private void labelHeading_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (TaskTrackerDbContext db = new TaskTrackerDbContext())
                {
                    // var cardContext = db.Cards.FirstOrDefault(s => s.i);
                    //cardContext.
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }
    }
}
