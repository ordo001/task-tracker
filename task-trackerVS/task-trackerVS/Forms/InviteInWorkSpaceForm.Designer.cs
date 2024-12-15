namespace task_trackerVS.Forms
{
    partial class InviteInWorkSpaceForm
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
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            labelMain = new Label();
            textBox1 = new TextBox();
            labelName = new Label();
            panelCommunityList = new Panel();
            buttonInvite = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(45, 52, 63);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(labelMain);
            panel2.Location = new Point(0, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 0, 40, 0);
            panel2.Size = new Size(803, 94);
            panel2.TabIndex = 9;
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
            // labelMain
            // 
            labelMain.AutoSize = true;
            labelMain.Font = new Font("Bahnschrift SemiBold", 21F, FontStyle.Regular, GraphicsUnit.Point);
            labelMain.ForeColor = SystemColors.ButtonFace;
            labelMain.Location = new Point(131, 29);
            labelMain.Name = "labelMain";
            labelMain.Size = new Size(315, 34);
            labelMain.TabIndex = 2;
            labelMain.Text = "Добавление участника";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Bahnschrift SemiBold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(191, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 27);
            textBox1.TabIndex = 14;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Bahnschrift SemiBold", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelName.ForeColor = SystemColors.ButtonFace;
            labelName.Location = new Point(14, 169);
            labelName.Name = "labelName";
            labelName.Size = new Size(166, 24);
            labelName.TabIndex = 13;
            labelName.Text = "Имя сотрудника:";
            // 
            // panelCommunityList
            // 
            panelCommunityList.AutoScroll = true;
            panelCommunityList.Location = new Point(191, 218);
            panelCommunityList.Name = "panelCommunityList";
            panelCommunityList.Size = new Size(255, 229);
            panelCommunityList.TabIndex = 15;
            // 
            // buttonInvite
            // 
            buttonInvite.Font = new Font("Bahnschrift SemiBold", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonInvite.Location = new Point(163, 480);
            buttonInvite.Name = "buttonInvite";
            buttonInvite.Size = new Size(160, 40);
            buttonInvite.TabIndex = 1;
            buttonInvite.Text = "Добавить";
            buttonInvite.UseVisualStyleBackColor = true;
            buttonInvite.Click += buttonInvite_Click;
            // 
            // InviteInWorkSpaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 47, 57);
            ClientSize = new Size(509, 553);
            Controls.Add(buttonInvite);
            Controls.Add(panelCommunityList);
            Controls.Add(textBox1);
            Controls.Add(labelName);
            Controls.Add(panel2);
            Name = "InviteInWorkSpaceForm";
            Text = "InviteInWorkSpaceForm";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox3;
        private Label labelMain;
        private TextBox textBox1;
        private Label labelName;
        private Panel panelCommunityList;
        private Button buttonInvite;
    }
}