using System.Windows.Forms;

namespace task_trackerVS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int count = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }



        int sectionCount = 0;
        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupBox section = new GroupBox()
            {
                Location = new Point(10 + (sectionCount * 440), 140),
                Name = "section" + sectionCount + 1,
                Size = new Size(420, 100),
                TabIndex = sectionCount,
                TabStop = false,
                AutoSize = true,
            ForeColor = SystemColors.ButtonFace
        };

            Label head = new Label()
            {
                Text = "Новая карточка",
                Font = new Font("Bahnschrift SemiBold", 14F),
                AutoSize = true,
                Location = new Point(50,20)
            };

            TreeView treeView = new TreeView()
            {
                BackColor = Color.FromArgb(41, 47, 57),
                ForeColor = SystemColors.ButtonFace,
                ImeMode = ImeMode.Disable,
                Location = new Point(290, 20),
                Name = "treeView1",
                ShowPlusMinus = false,
                Size = new Size(120, 25),
                TabIndex = 4
            };

            TreeNode rootNode = treeView.Nodes.Add("...");

            TreeNode childNode1 = rootNode.Nodes.Add("Удалить");
            TreeNode childNode2 = rootNode.Nodes.Add("Добавить");
            TreeNode childNode3 = rootNode.Nodes.Add("Изменить");

            treeView.AfterExpand += (s,args) =>
            {
                treeView.Size = new Size(120, 77);
            };

            treeView.AfterCollapse += (s, args) =>
            {
                treeView.Size = new Size(120, 25);
            };

            treeView.NodeMouseClick += (s, e) =>
            {
                if (e.Node == childNode1)
                {
                    this.Controls.Remove(section);
                    count--;
                }
                if(e.Node == childNode2)
                {
                    UserControlCard card = new UserControlCard()
                    {
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    card.Location = new Point(10,55);
                    section.Controls.Add(card);
                }
                if(e.Node == childNode3)
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
                        }
                    };
                    section.Controls.Add(textBox);

                }
            };
            sectionCount++;
            section.Controls.Add(treeView);
            section.Controls.Add(head);
            Controls.Add(section);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
