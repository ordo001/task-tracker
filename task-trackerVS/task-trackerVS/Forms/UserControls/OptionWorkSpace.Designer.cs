namespace task_trackerVS.Forms.UserControls
{
    partial class OptionWorkSpace
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            labelNameWC = new Label();
            labelCommunity = new Label();
            labelCommunityCount = new Label();
            buttonGoTo = new Button();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelNameWC
            // 
            labelNameWC.AutoSize = true;
            labelNameWC.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelNameWC.Location = new Point(3, 26);
            labelNameWC.Name = "labelNameWC";
            labelNameWC.Size = new Size(269, 30);
            labelNameWC.TabIndex = 1;
            labelNameWC.Text = "Название пространства";
            // 
            // labelCommunity
            // 
            labelCommunity.AutoSize = true;
            labelCommunity.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            labelCommunity.ForeColor = Color.Snow;
            labelCommunity.Location = new Point(3, 253);
            labelCommunity.Name = "labelCommunity";
            labelCommunity.Size = new Size(119, 25);
            labelCommunity.TabIndex = 2;
            labelCommunity.Text = "Участников:";
            // 
            // labelCommunityCount
            // 
            labelCommunityCount.AutoSize = true;
            labelCommunityCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelCommunityCount.ForeColor = Color.White;
            labelCommunityCount.Location = new Point(128, 257);
            labelCommunityCount.Name = "labelCommunityCount";
            labelCommunityCount.Size = new Size(19, 21);
            labelCommunityCount.TabIndex = 3;
            labelCommunityCount.Text = "0";
            // 
            // buttonGoTo
            // 
            buttonGoTo.BackColor = SystemColors.Control;
            buttonGoTo.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGoTo.Location = new Point(114, 308);
            buttonGoTo.Name = "buttonGoTo";
            buttonGoTo.Size = new Size(128, 33);
            buttonGoTo.TabIndex = 4;
            buttonGoTo.Text = "Перейти";
            buttonGoTo.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(343, 13);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 6;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // OptionWorkSpace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 68, 78);
            Controls.Add(checkBox1);
            Controls.Add(buttonGoTo);
            Controls.Add(labelCommunityCount);
            Controls.Add(labelCommunity);
            Controls.Add(labelNameWC);
            Controls.Add(pictureBox1);
            Name = "OptionWorkSpace";
            Size = new Size(377, 380);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelCommunity;
        public Button buttonGoTo;
        public Label labelNameWC;
        public Label labelCommunityCount;
        public CheckBox checkBox1;
        public PictureBox pictureBox1;
    }
}
