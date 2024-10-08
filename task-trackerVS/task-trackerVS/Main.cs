using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Windows.Forms;
using task_trackerVS.Models;
using static System.Collections.Specialized.BitVector32;

namespace task_trackerVS
{
    public partial class MainForm : Form
    {
        public User EntranceUser { get; }

        //public MainForm(User EntranceUser)
        public MainForm(User EntranceUser)
        {
            InitializeComponent();
            this.EntranceUser = EntranceUser;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void RemoveCard(GroupBox sectionCard, UserControlCard cardToRemove)
        {
            using(TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var cardlist = db.Cards.ToList();
                var cardData = cardlist.FirstOrDefault(p => p.NameCard == cardToRemove.Name);
                if(cardData != null)
                {
                    sectionCard.Controls.Remove(cardToRemove);
                    db.Remove(cardData);
                    db.SaveChanges();
                }
                
                var remainingCards = sectionCard.Controls.OfType<UserControlCard>().ToList();

                for(int i = 0; i< remainingCards.Count; i++)
                {
                    var card = remainingCards[i];
                    card.Location = new Point(card.Location.X, 55 + (i* 220));
                    var cardInDb = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                    if(cardInDb != null)
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

            Controls.Remove(sectionToRemove);
            var cardsList = db.Cards.ToList();
            var sectionData = db.Sections.FirstOrDefault(s => s.NameSection == sectionToRemove.Name);
            if (sectionData != null)
            {

                var cardsForSection = cardsList.Where(c => c.IdSection == sectionData.IdSection).ToList();


                for (int i = 0; i < cardsForSection.Count; i++)
                    db.Cards.Remove(cardsForSection[i]);
                db.Sections.Remove(sectionData);
                db.SaveChanges();
            }

            var remainingSections = Controls.OfType<GroupBox>().Where(s => s.Name.StartsWith("section")).ToList();

            for (int i = 0; i < remainingSections.Count; i++)
            {
                var section = remainingSections[i];
                section.Location = new Point(10 + (i * 460), section.Location.Y);

                var sectionInDb = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                if (sectionInDb != null)
                {
                    sectionInDb.SectionLocationX = section.Location.X;
                    sectionInDb.SectionLocationY = section.Location.Y;
                }
            }

            db.SaveChanges();
        }


        private void UpdateCrads()
        {
            //using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            //{
            using (TaskTrackerDbContext db = new TaskTrackerDbContext())
            {
                var cardsList = db.Cards.ToList();


                foreach (GroupBox section in Controls.OfType<GroupBox>())
                {
                    var sectionData = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                    if (sectionData != null)
                    {
                        var cardsForSection = cardsList.Where(c => c.IdSection == sectionData.IdSection).ToList();

                        foreach (var cardData in cardsForSection)
                        {
                            int aboba2;
                            var cardList = db.Cards.ToList();

                            if (cardList.Count > 0)
                            {
                                var lastCard = cardList.OrderByDescending(c => c.IdCard).FirstOrDefault();
                                aboba2 = lastCard.IdCard;
                            }
                            else
                                aboba2 = 0;
                            UserControlCard card = new UserControlCard()
                            {

                                //Location = new Point(10, 55 + (cardCount * 220)),
                                Location = new Point (10,cardData.CardLocationY),
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
                            //treeViewCard.BringToFront();
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
                                if (e.Node == childNode3)
                                {
                                    TaskTrackerDbContext db2 = new TaskTrackerDbContext();
                                    var cardSection = db2.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                                    var creator = db2.Users.FirstOrDefault(p => p.IdUser == cardSection.IdUser);
                                    if (creator != null)
                                        MessageBox.Show($"Создатель: {creator.Name}", "Информация о создателе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        MessageBox.Show("Создатель не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                    var aboba = dbContext.Cards.FirstOrDefault(c => c.NameCard == card.Name);
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


        private void Main_Load(object sender, EventArgs e)
        {
            TaskTrackerDbContext db = new TaskTrackerDbContext();
            var sectionsList = db.Sections.AsNoTracking().ToList();
            for (int i = 0; i < sectionsList.Count(); i++)
            {
                var sectionData = sectionsList[i];
                GroupBox section = new GroupBox()
                {

                    Location = new Point(sectionData.SectionLocationX, sectionData.SectionLocationY),
                    Name = sectionData.NameSection,
                    Size = new Size(420, 100),
                    TabIndex = i,
                    TabStop = false,
                    AutoSize = true,
                    ForeColor = SystemColors.ButtonFace
                };

                Label head = new Label()
                {
                    Text = sectionData.HeadingSection,
                    Font = new Font("Bahnschrift SemiBold", 14F),
                    AutoSize = true,
                    Location = new Point(50, 20)
                };

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
                        int aboba2;
                        var cardList = db.Cards.ToList();
                        var sectionCard = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                        var cardCountForSection = cardList.Where(p => p.IdSection == sectionCard.IdSection).ToList();

                        if (cardList.Count > 0)
                        {
                            var lastCard = cardList.OrderByDescending(c => c.IdCard).FirstOrDefault();
                            aboba2 = lastCard.IdCard;
                        }
                        else
                            aboba2 = 0;

                        UserControlCard card = new UserControlCard();
                        card.Name = "card" + (aboba2 + 1).ToString();
                        card.Location = new Point(10, 55 + (cardCountForSection.Count * 220));
                        cardCount++;
                        section.Controls.Add(card);


                        using (TaskTrackerDbContext db1 = new TaskTrackerDbContext())
                        {
                            var sectionDb = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                            Models.Card newCard = new Models.Card
                            {
                                NameCard = card.Name,
                                Heading = card.labelHeading.Text,
                                Content = card.textBox1.Text,
                                CardLocationY = card.Location.Y,
                                IdUser = EntranceUser.IdUser,
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
                        //treeViewCard.BringToFront();
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
                            if (e.Node == childNode3)
                            {
                                var cardSection = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                                var creator = db.Users.FirstOrDefault(p => p.IdUser == cardSection.IdUser);
                                if (creator != null)
                                    MessageBox.Show($"Создатель: {creator.Name}", "Информация о создателе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("Создатель не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var aboba = db.Cards.FirstOrDefault(c => c.NameCard == card.Name);
                            if (aboba != null)
                            {
                                aboba.Content = card.textBox1.Text;
                            }
                            db.SaveChanges();
                        };
                    }
                    if (e.Node == childNode3)
                    {
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
                };

                section.Controls.Add(treeView);
                section.Controls.Add(head);
                Controls.Add(section);
            }
            UpdateCrads();
        }


        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTrackerDbContext db = new TaskTrackerDbContext();
            var sectionsList = db.Sections.ToList();
            
            int aboba;
            task_trackerVS.Models.Section sectionNum;
            if (sectionsList.Count > 0)
            {
                sectionNum = sectionsList[sectionsList.Count - 1];
                aboba = sectionNum.IdSection;
            }
            else
            {
                aboba = 0;
            }




            GroupBox section = new GroupBox()
            {
                Location = new Point(10 + (sectionsList.Count * 460), 140),
                Name = "section" + (aboba + 1).ToString(),
                Size = new Size(420, 100),
                TabStop = false,
                AutoSize = true,
                ForeColor = SystemColors.ButtonFace
            };

            Label head = new Label()
            {
                Text = "Новая секция",
                Font = new Font("Bahnschrift SemiBold", 14F),
                AutoSize = true,
                Location = new Point(50, 20)
            };

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

            using (TaskTrackerDbContext db1 = new TaskTrackerDbContext())
            {
                Models.Section newSection = new Models.Section
                {
                    NameSection = section.Name,
                    HeadingSection = head.Text,
                    SectionLocationX = section.Location.X,
                    SectionLocationY = section.Location.Y,
                };
                db1.Add(newSection);
                db1.SaveChanges();
            }

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
                    int aboba2;
                    var cardList = db.Cards.ToList();
                    var sectionCard = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                    var cardCountForSection = cardList.Where(p => p.IdSection == sectionCard.IdSection).ToList();

                    if (cardList.Count > 0)
                    {
                        var lastCard = cardList.OrderByDescending(c => c.IdCard).FirstOrDefault();
                        aboba2 = lastCard.IdCard;
                    }
                    else
                        aboba2 = 0;

                    UserControlCard card = new UserControlCard();
                    card.Location = new Point(10, 55 + (cardCountForSection.Count * 220));
                    card.Name = "card" + (aboba2 + 1).ToString();
                    cardCount++;
                    section.Controls.Add(card);
                    using (TaskTrackerDbContext db1 = new TaskTrackerDbContext())
                    {
                        var sectionDb = db.Sections.FirstOrDefault(s => s.NameSection == section.Name);
                        Models.Card newCard = new Models.Card
                        {
                            NameCard = card.Name,
                            Heading = card.labelHeading.Text,
                            Content = card.textBox1.Text,
                            CardLocationY = card.Location.Y,
                            IdUser = EntranceUser.IdUser,
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
                    //treeViewCard.BringToFront();
                    TreeNode rootNode = treeViewCard.Nodes.Add("...");
                    TreeNode childNode1 = rootNode.Nodes.Add("Удалить карточку");
                    TreeNode childNode2 = rootNode.Nodes.Add("Изменить название карточки");
                    TreeNode childNode3 = rootNode.Nodes.Add("Создатель");

                    treeViewCard.NodeMouseClick += (s, e) =>
                    {
                        if (e.Node == childNode1)
                        {
                            RemoveCard(section,card);
                        }
                        if(e.Node == childNode2)
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
                        if(e.Node == childNode3)
                        {
                            var cardSection = db.Cards.FirstOrDefault(s => s.NameCard == card.Name);
                            var creator = db.Users.FirstOrDefault(p => p.IdUser == cardSection.IdUser);
                            if(creator != null)
                                MessageBox.Show($"Создатель: {creator.Name}", "Информация о создателе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Создатель не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    };

                    
                    

                    treeViewCard.AfterExpand += (s, args) =>
                    {
                        treeViewCard.Size = new Size(210, 93);
                        treeViewCard.BringToFront();

                    };

                    treeViewCard.AfterCollapse += (s, args) =>
                    {
                        treeViewCard.Size = new Size(100, 25);
                    };

                    
                    card.Controls.Add(treeViewCard);
                    card.textBox1.LostFocus += (s, e) =>
                    {
                        var aboba = db.Cards.FirstOrDefault(c => c.NameCard == card.Name);
                        if (aboba != null)
                        {
                            aboba.Content = card.textBox1.Text;
                        }
                        db.SaveChanges();
                    };
                }
                if (e.Node == childNode3)
                {
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
            };
            section.Controls.Add(treeView);
            section.Controls.Add(head);
            Controls.Add(section);
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Top;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            //this.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
            Main_Load(sender, e);
            

        }
    }
}
