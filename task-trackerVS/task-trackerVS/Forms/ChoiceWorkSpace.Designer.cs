namespace task_trackerVS.Forms
{
    partial class ChoiceWorkSpace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceWorkSpace));
            panel1 = new Panel();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            labelMain = new Label();
            labelRemove = new Label();
            labelAdd = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(2, 163);
            panel1.Name = "panel1";
            panel1.Size = new Size(1366, 400);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(45, 52, 63);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(labelMain);
            panel2.Location = new Point(2, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 40, 0);
            panel2.Size = new Size(1366, 117);
            panel2.TabIndex = 7;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(1247, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(79, 117);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icon;
            pictureBox3.Location = new Point(14, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(108, 108);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // labelMain
            // 
            labelMain.AutoSize = true;
            labelMain.Font = new Font("Bahnschrift SemiBold", 21F, FontStyle.Regular, GraphicsUnit.Point);
            labelMain.ForeColor = SystemColors.ButtonFace;
            labelMain.Location = new Point(145, 42);
            labelMain.Name = "labelMain";
            labelMain.Size = new Size(441, 34);
            labelMain.TabIndex = 1;
            labelMain.Text = "Выберите рабочее пространство";
            // 
            // labelRemove
            // 
            labelRemove.AutoSize = true;
            labelRemove.Cursor = Cursors.Hand;
            labelRemove.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelRemove.ForeColor = SystemColors.ButtonFace;
            labelRemove.Location = new Point(16, 582);
            labelRemove.Name = "labelRemove";
            labelRemove.Size = new Size(260, 24);
            labelRemove.TabIndex = 7;
            labelRemove.Text = "Удалить выбранные доски";
            labelRemove.Click += labelRemove_Click;
            // 
            // labelAdd
            // 
            labelAdd.AutoSize = true;
            labelAdd.Cursor = Cursors.Hand;
            labelAdd.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelAdd.ForeColor = SystemColors.ButtonFace;
            labelAdd.Location = new Point(325, 582);
            labelAdd.Name = "labelAdd";
            labelAdd.Size = new Size(224, 24);
            labelAdd.TabIndex = 8;
            labelAdd.Text = "Добавить новую доску";
            // 
            // ChoiceWorkSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(1368, 644);
            Controls.Add(labelAdd);
            Controls.Add(labelRemove);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximumSize = new Size(10000, 800);
            MinimumSize = new Size(786, 654);
            Name = "ChoiceWorkSpace";
            Text = "ChoiceWorkSpace";
            Resize += ChoiceWorkSpace_Resize;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label labelMain;
        private Label labelRemove;
        private Label labelAdd;
    }
}