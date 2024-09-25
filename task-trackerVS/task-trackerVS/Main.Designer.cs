namespace task_trackerVS
{
    using System.ComponentModel.Design;
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            contextMenuStrip1 = new ContextMenuStrip(components);
            cardsToolStripMenuItem = new ToolStripMenuItem();
            labelMain = new Label();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            labelMain.Location = new Point(155, 38);
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
            label1.Location = new Point(504, 38);
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
            label2.Location = new Point(691, 38);
            label2.Name = "label2";
            label2.Size = new Size(141, 29);
            label2.TabIndex = 3;
            label2.Text = "Пригласить";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icon;
            pictureBox1.Location = new Point(24, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(108, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(1600, 836);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная доска";
            Load += Main_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cardsToolStripMenuItem;
        private Label labelMain;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
