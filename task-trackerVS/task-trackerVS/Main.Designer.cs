namespace task_trackerVS
{
    using System.ComponentModel.Design;
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            contextMenuStrip1 = new ContextMenuStrip(components);
            cardsToolStripMenuItem = new ToolStripMenuItem();
            labelMain = new Label();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
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
            labelMain.Font = new Font("Bahnschrift SemiBold", 21F);
            labelMain.ForeColor = SystemColors.ButtonFace;
            labelMain.Location = new Point(145, 42);
            labelMain.Name = "labelMain";
            labelMain.Size = new Size(308, 34);
            labelMain.TabIndex = 1;
            labelMain.Text = "Основная доска задач";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Underline);
            label1.ForeColor = SystemColors.ScrollBar;
            label1.Location = new Point(490, 46);
            label1.Name = "label1";
            label1.Size = new Size(132, 29);
            label1.TabIndex = 2;
            label1.Text = "Участники";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Underline);
            label2.ForeColor = SystemColors.ScrollBar;
            label2.Location = new Point(646, 46);
            label2.Name = "label2";
            label2.Size = new Size(141, 29);
            label2.TabIndex = 3;
            label2.Text = "Пригласить";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(14, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 52, 63);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(labelMain);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1598, 119);
            panel1.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(1600, 836);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная доска";
            Load += Main_Load;
            Resize += Main_Resize;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cardsToolStripMenuItem;
        private Label labelMain;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}
