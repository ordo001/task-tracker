namespace task_trackerVS
{
    using System.ComponentModel.Design;
    using task_trackerVS.Models;

    partial class WorkSpaceForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSpaceForm));
            contextMenuStrip1 = new ContextMenuStrip(components);
            cardsToolStripMenuItem = new ToolStripMenuItem();
            labelMain = new Label();
            label1 = new Label();
            labelInvite = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cardsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(167, 26);
            // 
            // cardsToolStripMenuItem
            // 
            cardsToolStripMenuItem.Name = "cardsToolStripMenuItem";
            cardsToolStripMenuItem.Size = new Size(166, 22);
            cardsToolStripMenuItem.Text = "Добавить раздел";
            cardsToolStripMenuItem.Click += cardsToolStripMenuItem_Click;
            // 
            // labelMain
            // 
            labelMain.AutoSize = true;
            labelMain.Font = new Font("Bahnschrift SemiBold", 21F, FontStyle.Regular, GraphicsUnit.Point);
            labelMain.ForeColor = SystemColors.ButtonFace;
            labelMain.Location = new Point(145, 42);
            labelMain.Name = "labelMain";
            labelMain.Size = new Size(139, 34);
            labelMain.TabIndex = 1;
            labelMain.Text = "Название";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ScrollBar;
            label1.Location = new Point(645, 47);
            label1.Name = "label1";
            label1.Size = new Size(132, 29);
            label1.TabIndex = 2;
            label1.Text = "Участники";
            label1.Click += label1_Click;
            // 
            // labelInvite
            // 
            labelInvite.AutoSize = true;
            labelInvite.Cursor = Cursors.Hand;
            labelInvite.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Underline, GraphicsUnit.Point);
            labelInvite.ForeColor = SystemColors.ScrollBar;
            labelInvite.Location = new Point(824, 47);
            labelInvite.Name = "labelInvite";
            labelInvite.Size = new Size(120, 29);
            labelInvite.TabIndex = 3;
            labelInvite.Text = "Добавить";
            labelInvite.Visible = false;
            labelInvite.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(14, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 52, 63);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelMain);
            panel1.Controls.Add(labelInvite);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1603, 119);
            panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(1514, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(84, 119);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // WorkSpaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(1603, 772);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new Size(1136, 0);
            Name = "WorkSpaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Доска Отдела Информационных систем";
            Load += Main_Load;
            Resize += Main_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cardsToolStripMenuItem;
        private Label label1;
        private Label labelInvite;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox2;
        public Label labelMain;
    }
}
