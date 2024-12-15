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

namespace task_trackerVS.Forms
{
    public partial class InviteInWorkSpaceForm : Form
    {
        private int _CurrentWorkSpace;
        public InviteInWorkSpaceForm(int workSpace)
        {
            this._CurrentWorkSpace = workSpace;
            InitializeComponent();
            FillingListMembers("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            FillingListMembers(text);
        }

        private void FillingListMembers(string text)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            var UsersList = db.Users.Where(s => EF.Functions.Like(s.Name!, $"{text}%")).ToList();
            ListClear();
            CreateListMembers(UsersList);
        }

        private void ListClear()
        {
            var controlsToRemove = panelCommunityList.Controls
        .OfType<Control>()
        .Where(c => c != textBox1)
        .ToList();

            foreach (var control in controlsToRemove)
            {
                panelCommunityList.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void CreateListMembers(List<User> UsersList)
        {
            ListClear();
            for (int i = 0; i < UsersList.Count; i++)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Name = UsersList[i].Login,
                    Location = new Point(3, 1 + (i * 30)),
                    Text = UsersList[i].Name,
                    Font = new Font("Bahnschrift SemiBold", 14),
                    AutoSize = true,
                };
                panelCommunityList.Controls.Add(checkBox);
            }
        }

        private void buttonInvite_Click(object sender, EventArgs e)
        {

            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            var checkBoxList = panelCommunityList.Controls.OfType<CheckBox>().ToList();
            List<string> selectedUsersList = FillingSelectedUsersList(checkBoxList);

            AddCommunityInWorkSpace(db, selectedUsersList, _CurrentWorkSpace);
            //db.Add(_CurrentWorkSpace);
            db.SaveChanges();


        }

        private void AddCommunityInWorkSpace(TaskTrackerDbContext db, List<string> selectedUsersList, int IdworkSpace)
        {
            var users = db.Users.ToList();
            List<User> usersListToAdd = new List<User>();

            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < selectedUsersList.Count; j++)
                {
                    if (users[i].Login == selectedUsersList[j])
                        usersListToAdd.Add(users[i]);

                }
            }
            var workSpace = db.WorkSpaces.FirstOrDefault(s => s.IdWorkSpace == IdworkSpace);
            foreach (var user in usersListToAdd)
            {
                workSpace.Users.Add(user);
            }
            db.SaveChanges();
            MessageBox.Show("Пользователи успешно добавлены в рабочее пространство!", "Успешно");

        }

        private List<string> FillingSelectedUsersList(List<CheckBox> checkBoxList)
        {
            List<string> selectedUsersList = new List<string>();
            foreach (var checkBox in checkBoxList)
            {
                if (checkBox.Checked)
                    selectedUsersList.Add(checkBox.Name);
            }
            return selectedUsersList;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
