namespace task_trackerVS.Forms
{
    partial class CreateWorkSpaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateWorkSpaceForm));
            labelMain = new Label();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            panelCommunityList = new Panel();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelMain
            // 
            labelMain.AutoSize = true;
            labelMain.Font = new Font("Bahnschrift SemiBold", 21F, FontStyle.Regular, GraphicsUnit.Point);
            labelMain.ForeColor = SystemColors.ButtonFace;
            labelMain.Location = new Point(131, 29);
            labelMain.Name = "labelMain";
            labelMain.Size = new Size(340, 34);
            labelMain.TabIndex = 2;
            labelMain.Text = "Создание рабочей доски";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(50, 174);
            label1.Name = "label1";
            label1.Size = new Size(106, 24);
            label1.TabIndex = 3;
            label1.Text = "Название:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(45, 52, 63);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(labelMain);
            panel2.Location = new Point(0, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 40, 0);
            panel2.Size = new Size(742, 94);
            panel2.TabIndex = 8;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icon;
            pictureBox3.Location = new Point(14, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(91, 87);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(44, 481);
            label2.Name = "label2";
            label2.Size = new Size(112, 24);
            label2.TabIndex = 9;
            label2.Text = "Участники:";
            // 
            // panelCommunityList
            // 
            panelCommunityList.AutoScroll = true;
            panelCommunityList.Location = new Point(166, 534);
            panelCommunityList.Name = "panelCommunityList";
            panelCommunityList.Size = new Size(520, 204);
            panelCommunityList.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(166, 478);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(503, 27);
            textBox2.TabIndex = 13;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift SemiBold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(220, 766);
            button1.Name = "button1";
            button1.Size = new Size(121, 40);
            button1.TabIndex = 0;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Bahnschrift SemiBold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(410, 766);
            button2.Name = "button2";
            button2.Size = new Size(121, 40);
            button2.TabIndex = 11;
            button2.Text = "Вернуться";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(166, 174);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 27);
            textBox1.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(14, 235);
            label3.Name = "label3";
            label3.Size = new Size(142, 24);
            label3.TabIndex = 14;
            label3.Text = "Изображение:";
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(175, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 223);
            panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 223);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(436, 355);
            button3.Name = "button3";
            button3.Size = new Size(95, 33);
            button3.TabIndex = 16;
            button3.Text = "Выбрать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // CreateWorkSpaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(741, 831);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panelCommunityList);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateWorkSpaceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание доски";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMain;
        private Label label1;
        private Panel panel2;
        private PictureBox pictureBox3;
        private Label label2;
        private Panel panelCommunityList;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button3;
    }
}