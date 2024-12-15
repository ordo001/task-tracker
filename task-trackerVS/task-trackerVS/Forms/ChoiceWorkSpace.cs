using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task_trackerVS.Forms.UserControls;
using task_trackerVS.Models;

namespace task_trackerVS.Forms
{
    public partial class ChoiceWorkSpace : Form
    {

        private task_trackerVS.Models.User _CurrentUser { get; }
        public ChoiceWorkSpace(task_trackerVS.Models.User user)
        {
            this._CurrentUser = user;
            InitializeComponent();
            AddWorkSpacesInForm();

        }


        private void AddWorkSpacesInForm()
        {
            panel1.Controls.Clear();

            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            var user = db.Users.Include(u => u.WorkSpaces).FirstOrDefault(u => u.IdUser == _CurrentUser.IdUser);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден.");
            }
            else
            {
                if (user.Role == "Administrator")
                {
                    var workSpaces = db.WorkSpaces.ToList();
                    if (this._CurrentUser.Role == "Administrator")
                    {
                        labelAdd.Visible = true;
                        labelRemove.Visible = true;
                    }
                    LoadWorkSpaceFormDb(workSpaces, db);

                }
                else
                {
                    var workSpaces = user.WorkSpaces; // Получаем рабочие пространства пользователя
                    LoadWorkSpaceFormDb(workSpaces, db);
                }
            }
        }

        private void LoadWorkSpaceFormDb(List<WorkSpace> workSpaces, TaskTrackerDbContext db)
        {
            for (int i = 0; i < workSpaces.Count; i++)
            {
                //Выгрузка списка досок, подсчет кол-ва пользователей в каждой доске
                var WC = db.WorkSpaces.Include(u => u.Users).FirstOrDefault(u => u.IdWorkSpace == workSpaces[i].IdWorkSpace);
                int? countCommunityWorkSpace = WC.Users.Count;
                // Создание экземляров выбора досок
                var workSpace = CreateOptionWorkSpace(i, workSpaces[i], countCommunityWorkSpace);
                EnabledAdminControls(workSpace);
                workSpace.pictureBox1.Image = ConvertByteArrayToImage(WC.Image);
                this.panel1.Controls.Add(workSpace);

            }
        }

        private Image? ConvertByteArrayToImage(byte[]? byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                //throw new ArgumentException("Массив байтов пуст или null.");
                return null;
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

        private OptionWorkSpace CreateOptionWorkSpace(int num, WorkSpace workSpaces, int? workSpaceCummunityCount)
        {
            var workSpace = new OptionWorkSpace()
            {
                Location = new Point(10 + (num * 410), 0),
                TabIndex = workSpaces.IdWorkSpace,
                Name = $"WorkSpace{num}",
            };
            workSpace.labelNameWC.Text = workSpaces.WorkSpaceName;
            workSpace.labelCommunityCount.Text = workSpaceCummunityCount != null ? workSpaceCummunityCount.ToString() : "0";


            workSpace.buttonGoTo.Click += (s, e) =>
            {
                OpenWorkSpace(workSpaces);
            };

            return workSpace;

        }

        private void EnabledAdminControls(OptionWorkSpace workSpace)
        {
            if (this._CurrentUser.Role == "Administrator")
            {
                labelAdd.Visible = true;
                labelRemove.Visible = true;
                workSpace.checkBox1.Visible = true;
            }


        }

        private void OpenWorkSpace(WorkSpace workSpaces)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            WorkSpaceForm workSpaceForm = new WorkSpaceForm(workSpaces, _CurrentUser)
            {
                Text = workSpaces.WorkSpaceName,
            };
            workSpaceForm.labelMain.Text = workSpaces.WorkSpaceName;
            this.Hide();
            workSpaceForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            AddWorkSpacesInForm();
            panel2.Size = new Size(this.Size.Width, panel2.Size.Height);
        }

        private void ChoiceWorkSpace_Resize(object sender, EventArgs e)
        {
            panel2.Size = new Size(this.Size.Width, panel2.Size.Height);
            panel1.Size = new Size(this.Size.Width, panel1.Size.Height);
        }

        private void labelRemove_Click(object sender, EventArgs e)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();

            foreach (var item in this.panel1.Controls)
            {
                if (item is OptionWorkSpace)
                {
                    var workSpace = item as OptionWorkSpace;
                    //var WC = db.WorkSpaces.FirstOrDefault(s => s.IdWorkSpace == workSpace.TabIndex);
                    var aboba = db.WorkSpaces.FirstOrDefault(s => s.IdWorkSpace == workSpace.TabIndex);
                    if (workSpace.checkBox1.Checked)
                    {
                        RemoveWorkSpace(aboba, workSpace);
                    }
                }
            }
        }

        private void RemoveWorkSpace(WorkSpace workSpace, OptionWorkSpace optionWorkSpace)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            //var WC = db.WorkSpaces.FirstOrDefault(u => u.IdWorkSpace == workSpace.IdWorkSpace);
            if (workSpace != null)
            {
                DeleteSectionDb(workSpace);
                db.Remove(workSpace);
                db.SaveChanges();
                AddWorkSpacesInForm();
            }

        }

        private void DeleteSectionDb(WorkSpace workSpace)
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            var aboba = db.Sections.Where(s => s.IdWorkSpace == workSpace.IdWorkSpace).ToList();
            foreach (var section in aboba)
            {
                db.Remove(section);
            }
            db.SaveChanges();
        }

        private void labelAdd_Click(object sender, EventArgs e)
        {
            CreateWorkSpaceForm createWorkSpaceForm = new CreateWorkSpaceForm(_CurrentUser);
            createWorkSpaceForm.Show();
            this.Hide();
        }
    }
}
