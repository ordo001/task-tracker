using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
using static System.Net.Mime.MediaTypeNames;


namespace task_trackerVS.Forms
{

    public partial class CreateWorkSpaceForm : Form
    {
        private User _CurrentUser { get; }
        public CreateWorkSpaceForm(User _CurrentUser)
        {
            this._CurrentUser = _CurrentUser;
            InitializeComponent();
            FillingListMembers("");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;
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
        .Where(c => c != textBox2)
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

        private void button2_Click(object sender, EventArgs e)
        {
            BackWindow();
        }

        private void BackWindow()
        {
            this.Hide();
            ChoiceWorkSpace choiceWorkSpace = new ChoiceWorkSpace(_CurrentUser);
            choiceWorkSpace.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            var checkBoxList = panelCommunityList.Controls.OfType<CheckBox>().ToList();
            List<string> selectedUsersList = FillingSelectedUsersList(checkBoxList);
            var workSpace = CreateWorkSpace(db);
            AddCommunityInWorkSpace(db, selectedUsersList, workSpace);
            SaveImageToDatabase(db,workSpace);
            db.Add(workSpace);
            db.SaveChanges();

            BackWindow();
        }

        private WorkSpace CreateWorkSpace(TaskTrackerDbContext db)
        {
            var workSpace = new WorkSpace()
            {
                WorkSpaceName = textBox1.Text
            };
            return workSpace;
        }

        private void AddCommunityInWorkSpace(TaskTrackerDbContext db, List<string> selectedUsersList, WorkSpace workSpace)
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

            foreach (var user in usersListToAdd)
            {
                workSpace.Users.Add(user);
            }


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

        private byte[]? SelectImage()
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllBytes(openFileDialog.FileName);
            }
            return null;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var imageData = SelectImage();
            if (imageData != null && imageData.Length < 60000)
            {
                pictureBox1.Image = ConvertByteArrayToImage(imageData);
            }
        }

        private void SaveImageToDatabase(TaskTrackerDbContext db, WorkSpace workSpace)
        {
            var image = pictureBox1.Image;
            workSpace.Image = ImageToByteArray(image);

        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                if (image != null)
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();    
                }
                else return null;
            }
        }

        private System.Drawing.Image? ConvertByteArrayToImage(byte[]? byteArray)
        { 
            if (byteArray == null || byteArray.Length == 0)
            {
                throw new ArgumentException("Массив байтов пуст или null.");
            }

            try
            {
                using var ms = new MemoryStream(byteArray);
                return System.Drawing.Image.FromStream(ms);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Ошибка: массив байтов не содержит корректное изображение." + ex.ToString());
                return null;
            }
        }
    }
}
