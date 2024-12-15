using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;
using System.Windows.Forms;
using task_trackerVS.Forms;
using task_trackerVS.Models;
using static System.Collections.Specialized.BitVector32;

namespace task_trackerVS
{
    public partial class WorkSpaceForm : Form
    {
        private User? _CurrentUser { get; }
        private WorkSpace _WorkSpace { get; }

        //public MainForm(User EntranceUser)
        public WorkSpaceForm(WorkSpace WorkSpace, User _CurrentUser)
        {
            this._CurrentUser = _CurrentUser;
            this._WorkSpace = WorkSpace;
            InitializeComponent();
            SetNameWorkSpace();
            LoadSectionFromDb();
            EnabletButtonIvite();
        }

        private void EnabletButtonIvite()
        {
            if (_CurrentUser.Role == "Administrator" || _CurrentUser.Role == "Moderator")
                labelInvite.Visible = true;
            else
                labelInvite.Visible = false;
        }

        private void SetNameWorkSpace()
        {
            using TaskTrackerDbContext db = new TaskTrackerDbContext();
            this.Name = "Доска " + db.WorkSpaces.FirstOrDefault(s => s.IdWorkSpace == _WorkSpace.IdWorkSpace).WorkSpaceName.ToString();
            this.labelMain.Text = db.WorkSpaces.FirstOrDefault(s => s.IdWorkSpace == _WorkSpace.IdWorkSpace).WorkSpaceName.ToString();
        }

        private void RemoveCard(GroupBox sectionCard, UserControlCard cardToRemove)
        {
            using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var cardlist = db.Cards.ToList();
                var cardData = cardlist.FirstOrDefault(p => p.NameCard == cardToRemove.Name);
                if (cardData != null)
                {
                    sectionCard.Controls.Remove(cardToRemove);
                    db.Remove(cardData);
                    db.SaveChanges();
                }

                var remainingCards = sectionCard.Controls.OfType<UserControlCard>().ToList();

                for (int i = 0; i < remainingCards.Count; i++)
                {
                    var card = remainingCards[i];
                    card.Location = new Point(card.Location.X, 55 + (i * 220));
                    var cardInDb = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                    if (cardInDb != null)
                    {
                        cardInDb.CardLocationY = card.Location.Y;
                    }
                }
                db.SaveChanges();

            }
        }

        private void RemoveSection(GroupBox sectionToRemove)
        {
            TaskTrackerDbContext db = new TaskTrackerDbContext();
            RemoveSectionFromDb(sectionToRemove, db);
            RemoveSectionInFormAndUpdateDb(sectionToRemove, db);
            db.SaveChanges();
        }

        private void RemoveSectionInFormAndUpdateDb(GroupBox sectionToRemove, TaskTrackerDbContext db)
        {
            Controls.Remove(sectionToRemove);
            var remainingSections = Controls.OfType<GroupBox>().Where(s => s.Name.StartsWith("section")).ToList();
            for (int i = 0; i < remainingSections.Count; i++)
            {
                var section = remainingSections[i];
                section.Location = new Point(10 + (i * 460), section.Location.Y);

                var sectionInDb = db.Sections.FirstOrDefault(s => s.NameSection == section.Name && s.IdWorkSpace == _WorkSpace.IdWorkSpace);
                if (sectionInDb != null)
                {
                    sectionInDb.SectionLocationX = section.Location.X;
                    sectionInDb.SectionLocationY = section.Location.Y;
                }
            }
        }

        private void RemoveSectionFromDb(GroupBox sectionToRemove, TaskTrackerDbContext db)
        {
            var cardsList = db.Cards.ToList();
            var sectionData = db.Sections.FirstOrDefault(s => s.NameSection == sectionToRemove.Name && s.IdWorkSpace == _WorkSpace.IdWorkSpace);
            if (sectionData != null)
            {
                var cardsForSection = cardsList.Where(c => c.IdSection == sectionData.IdSection).ToList();

                for (int i = 0; i < cardsForSection.Count; i++)
                    db.Cards.Remove(cardsForSection[i]);
                db.Sections.Remove(sectionData);
                db.SaveChanges();
            }
        }

        private void RenameCard(UserControlCard card)
        {
            TextBox textBox = new TextBox
            {
                Size = card.labelHeading.Size,
                Location = card.labelHeading.Location,
                Visible = false
            };

            textBox.Text = card.labelHeading.Text;
            textBox.Size = card.labelHeading.Size;
            textBox.Visible = true;
            card.labelHeading.Visible = false;
            textBox.Focus();

            textBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    card.labelHeading.Text = textBox.Text;
                    card.labelHeading.Visible = true;
                    textBox.Visible = false;
                    using (TaskTrackerDbContext db = new TaskTrackerDbContext())
                    {
                        var renameCard = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                        if (renameCard != null)
                            renameCard.Heading = card.labelHeading.Text;
                        db.SaveChanges();
                    }
                }
            };

            card.Controls.Add(textBox);
        }
        private void ShowInfoCard(UserControlCard card)
        {
            using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var cardSection = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                var creator = db.Users.FirstOrDefault(p => p.IdUser == cardSection.IdUser);
                if (creator != null)
                    MessageBox.Show($"Создатель: {creator.Name}", "Информация о создателе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Создатель не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateCrads()
        {
            using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var cardsList = db.Cards.ToList();


                foreach (GroupBox section in Controls.OfType<GroupBox>())
                {
                    var sectionData = db.Sections.FirstOrDefault(s => s.NameSection == section.Name && s.IdWorkSpace == _WorkSpace.IdWorkSpace);
                    if (sectionData != null)
                    {
                        var cardsForSection = cardsList.Where(c => c.IdSection == sectionData.IdSection).ToList();

                        foreach (var cardData in cardsForSection)
                        {

                            UserControlCard card = new UserControlCard()
                            {

                                //Location = new Point(10, 55 + (cardCount * 220)),
                                Location = new Point(10, cardData.CardLocationY),
                                Name = cardData.NameCard,

                            };
                            card.labelHeading.Text = cardData.Heading;
                            TreeView treeViewCard = new TreeView()
                            {
                                BackColor = Color.FromArgb(63, 68, 78),
                                ForeColor = SystemColors.ButtonFace,
                                ImeMode = ImeMode.Disable,
                                Location = new Point(180, 10),
                                Name = "treeView1",
                                ShowPlusMinus = false,
                                Size = new Size(100, 25),
                                TabIndex = 1
                            };
                            TreeNode rootNode = treeViewCard.Nodes.Add("...");
                            TreeNode childNode1 = rootNode.Nodes.Add("Удалить карточку");
                            TreeNode childNode2 = rootNode.Nodes.Add("Изменить название карточки");
                            TreeNode childNode3 = rootNode.Nodes.Add("Создатель");

                            treeViewCard.NodeMouseClick += (s, e) =>
                            {
                                if (e.Node == childNode1)
                                {
                                    RemoveCard(section, card);
                                }
                                if (e.Node == childNode2)
                                {
                                    RenameCard(card);
                                }
                                if (e.Node == childNode3)
                                {
                                    ShowInfoCard(card);
                                }
                            };
                            treeViewCard.AfterExpand += (s, args) =>
                            {
                                treeViewCard.Size = new Size(200, 93);
                                treeViewCard.BringToFront();

                            };

                            treeViewCard.AfterCollapse += (s, args) =>
                            {
                                treeViewCard.Size = new Size(100, 25);
                            };
                            card.Controls.Add(treeViewCard);

                            card.textBox1.Text = cardData.Content;

                            section.Controls.Add(card);
                            card.textBox1.LostFocus += (s, e) =>
                            {
                                using (TaskTrackerDbContext dbContext = new TaskTrackerDbContext())
                                {
                                    var aboba = dbContext.Cards.FirstOrDefault(c => c.NameCard == card.Name && c.IdSection == sectionData.IdSection);
                                    if (aboba != null)
                                    {
                                        aboba.Content = card.textBox1.Text;
                                        dbContext.SaveChanges();
                                    }

                                }
                            };
                        }
                    }
                }
            }

        }

        private void AddCard(GroupBox section, int cardCount)
        {
            using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var sectionCard = db.Sections.FirstOrDefault(s => s.NameSection == section.Name && s.IdWorkSpace == _WorkSpace.IdWorkSpace);
                var cardCountForSection = db.Cards.Where(p => p.IdSection == sectionCard.IdSection).ToList();

                UserControlCard card = new UserControlCard();
                card.Name = cardCountForSection.Count > 0 ? "card" + cardCountForSection[cardCountForSection.Count - 1].IdCard.ToString() : "card0";
                card.Location = new Point(10, 55 + (cardCountForSection.Count * 220));
                cardCount++;
                section.Controls.Add(card);


                using (TaskTrackerDbContext db1 = new TaskTrackerDbContext())
                {
                    var sectionDb = db.Sections.FirstOrDefault(s => s.NameSection == section.Name && s.IdWorkSpace == _WorkSpace.IdWorkSpace);
                    Card newCard = new Card
                    {
                        NameCard = card.Name,
                        Heading = card.labelHeading.Text,
                        Content = card.textBox1.Text,
                        CardLocationY = card.Location.Y,
                        //IdUser = _CurrentUser.IdUser,
                        IdUser = 5,
                        IdSection = sectionDb.IdSection
                    };
                    db1.Add(newCard);
                    db1.SaveChanges();
                }

                TreeView treeViewCard = new TreeView()
                {
                    BackColor = Color.FromArgb(63, 68, 78),
                    ForeColor = SystemColors.ButtonFace,
                    ImeMode = ImeMode.Disable,
                    Location = new Point(180, 10),
                    Name = "treeView1",
                    ShowPlusMinus = false,
                    Size = new Size(100, 25),
                    TabIndex = 1
                };
                TreeNode rootNode = treeViewCard.Nodes.Add("...");
                TreeNode childNode1 = rootNode.Nodes.Add("Удалить карточку");
                TreeNode childNode2 = rootNode.Nodes.Add("Изменить название карточки");
                TreeNode childNode3 = rootNode.Nodes.Add("Создатель");

                treeViewCard.NodeMouseClick += (s, e) =>
                {
                    using (TaskTrackerDbContext db = new TaskTrackerDbContext())

                        if (e.Node == childNode1)
                        {
                            RemoveCard(section, card);
                        }
                    if (e.Node == childNode2)
                    {
                        RenameCard(card);
                    }
                    if (e.Node == childNode3)
                    {
                        ShowInfoCard(card);
                    }
                };
                treeViewCard.AfterExpand += (s, args) =>
                {
                    treeViewCard.Size = new Size(200, 93);
                    treeViewCard.BringToFront();

                };

                treeViewCard.AfterCollapse += (s, args) =>
                {
                    treeViewCard.Size = new Size(100, 25);
                };
                card.Controls.Add(treeViewCard);
                card.textBox1.LostFocus += (s, e) =>
                {
                    var aboba = db.Cards.FirstOrDefault(c => c.NameCard == card.Name && c.IdSection == sectionCard.IdSection);
                    if (aboba != null)
                    {
                        aboba.Content = card.textBox1.Text;
                    }
                    db.SaveChanges();
                };
            }
        }

        private void RenameSection(GroupBox section)
        {
            Label head = null!;
            foreach (var item in section.Controls)
            {
                if (item is Label label)
                {
                    head = label;
                    break;
                }
            }

            TextBox textBox = new TextBox
            {
                Size = head.Size,
                Location = head.Location,
                Visible = false
            };

            textBox.Text = head.Text;
            textBox.Size = head.Size;
            textBox.Visible = true;
            head.Visible = false;
            textBox.Focus();

            textBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    head.Text = textBox.Text;
                    head.Visible = true;
                    textBox.Visible = false;
                    using (TaskTrackerDbContext db = new TaskTrackerDbContext())
                    {
                        var renameSection = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                        if (renameSection != null)
                            renameSection.HeadingSection = head.Text;
                        db.SaveChanges();
                    }
                }
            };

            section.Controls.Add(textBox);
        }

        private void LoadSectionFromDb()
        {
            TaskTrackerDbContext db = new TaskTrackerDbContext();
            var sectionsInWorkSpaceList = db.Sections.Where(x => x.IdWorkSpace == _WorkSpace.IdWorkSpace).AsNoTracking().ToList();

            foreach (var item in sectionsInWorkSpaceList)
            {
                GroupBox section = new GroupBox()
                {
                    //TabIndex = ite
                    Location = new Point(item.SectionLocationX, item.SectionLocationY),
                    Name = item.NameSection,
                    Size = new Size(420, 100),
                    TabStop = false,
                    AutoSize = true,
                    ForeColor = SystemColors.ButtonFace
                };

                CreateHeadLabelInSection(section);
                AddTreeViewInSection(section);
                Controls.Add(section);
            }
            UpdateCrads();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //LoadSectionFromDb();
        }

        private void AddNewSectionInForm()
        {
            using (var db = new TaskTrackerDbContext())
            {
                var sectionsInWorkSpaceList = db.Sections.Where(x => x.IdWorkSpace == _WorkSpace.IdWorkSpace).AsNoTracking().ToList();
                List<task_trackerVS.Models.Section> sections = new List<task_trackerVS.Models.Section>();
                GroupBox section = new GroupBox()
                {
                    Location = new Point(10 + (sectionsInWorkSpaceList.Count * 460), 140),
                    Name = sectionsInWorkSpaceList.Count > 0 ? "section" + sectionsInWorkSpaceList[sectionsInWorkSpaceList.Count - 1].IdSection.ToString() : "section0",
                    Size = new Size(420, 100),
                    TabStop = false,
                    AutoSize = true,
                    ForeColor = SystemColors.ButtonFace
                };

                CreateHeadLabelInSection(section);
                AddSectionInDb(section);
                AddTreeViewInSection(section);

                this.Controls.Add(section);

            }
        }

        private void CreateHeadLabelInSection(GroupBox section)
        {
            Label head = new Label()
            {
                Text = "Новая секция",
                Font = new Font("Bahnschrift SemiBold", 14F),
                AutoSize = true,
                Location = new Point(50, 20)
            };
            section.Controls.Add(head);
        }

        private void AddSectionInDb(GroupBox section)
        {
            Label head = null!;
            foreach (var item in section.Controls)
            {
                if (item is Label label)
                {
                    head = label;
                    break;
                }
            }

            using (TaskTrackerDbContext db1 = new TaskTrackerDbContext())
            {
                Models.Section newSection = new Models.Section
                {
                    NameSection = section.Name,
                    IdWorkSpace = _WorkSpace.IdWorkSpace,
                    HeadingSection = head.Text,
                    SectionLocationX = section.Location.X,
                    SectionLocationY = section.Location.Y,
                };
                db1.Add(newSection);
                db1.SaveChanges();
            }
        }

        private void AddTreeViewInSection(GroupBox section)
        {
            TreeView treeView = new TreeView()
            {
                BackColor = Color.FromArgb(41, 47, 57),
                ForeColor = SystemColors.ButtonFace,
                ImeMode = ImeMode.Disable,
                Location = new Point(200, 20),
                Name = "treeView1",
                ShowPlusMinus = false,
                Size = new Size(200, 25),
                TabIndex = 4
            };

            TreeNode rootNode = treeView.Nodes.Add("...");
            TreeNode childNode1 = rootNode.Nodes.Add("Удалить секцию");
            TreeNode childNode2 = rootNode.Nodes.Add("Добавить карточку");
            TreeNode childNode3 = rootNode.Nodes.Add("Изменить название секции");

            treeView.AfterExpand += (s, args) =>
            {
                treeView.Size = new Size(200, 93);
            };

            treeView.AfterCollapse += (s, args) =>
            {
                treeView.Size = new Size(190, 25);
            };
            int cardCount = 0;

            treeView.NodeMouseClick += (s, e) =>
            {
                if (e.Node == childNode1)
                {
                    RemoveSection(section);
                }
                if (e.Node == childNode2)
                {
                    AddCard(section, cardCount);
                }
                if (e.Node == childNode3)
                {

                    RenameSection(section);
                }

            };
            section.Controls.Add(treeView);
        }

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSectionInForm();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            pictureBox2.Dock = DockStyle.Right;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            SetNameWorkSpace();
            LoadSectionFromDb();


        }



        private void label1_Click(object sender, EventArgs e)
        {
            TaskTrackerDbContext db = new TaskTrackerDbContext();
            var workSpace = db.WorkSpaces.Include(u => u.Users).FirstOrDefault(u => u.IdWorkSpace == _WorkSpace.IdWorkSpace);
            var CommunityWorkSpace = workSpace.Users.ToList();
            OpenFormListCommunity(CommunityWorkSpace);
        }

        private void OpenFormListCommunity(List<User> CommunityWorkSpace)
        {
            Form form = new Form()
            {
                Text = "Список участников доски",
            };

            ListBox listBoxCommunity = new ListBox()
            {
                Dock = DockStyle.Fill,
                Size = new Size(400, 100),
                Font = new Font(label1.Font.FontFamily, 13)
            };

            FillListBoxCommunity(listBoxCommunity, CommunityWorkSpace);

            form.Controls.Add(listBoxCommunity);
            form.ShowDialog();
        }
        private void FillListBoxCommunity(ListBox listBox, List<User> CommunityWorkSpace)
        {
            listBox.Items.Add($"Всего участников: {CommunityWorkSpace.Count}");
            listBox.Items.Add($"Список участников:");
            foreach (var user in CommunityWorkSpace)
            {
                listBox.Items.Add(user.Name);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InviteInWorkSpaceForm inviteInWorkSpaceForm = new InviteInWorkSpaceForm(_WorkSpace.IdWorkSpace);
            inviteInWorkSpaceForm.ShowDialog();
        }

        private void OpenFormListInvite()
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChoiceWorkSpace choiceWorkSpace = new ChoiceWorkSpace(_CurrentUser);
            choiceWorkSpace.Show();
        }
    }
}
