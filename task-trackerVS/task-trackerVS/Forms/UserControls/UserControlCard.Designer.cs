namespace task_trackerVS
{
    partial class UserControlCard
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
            labelHeading = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHeading.Location = new Point(8, 11);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(75, 21);
            labelHeading.TabIndex = 0;
            labelHeading.Text = "Heading";
            labelHeading.Click += labelHeading_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(63, 68, 78);
            textBox1.Location = new Point(8, 46);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 133);
            textBox1.TabIndex = 2;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.Leave += textBox1_Leave;
            // 
            // UserControlCard
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 68, 78);
            Controls.Add(textBox1);
            Controls.Add(labelHeading);
            Name = "UserControlCard";
            Size = new Size(400, 200);
            Load += UserControlCard_Click;
            Click += UserControlCard_Click;
            MouseDown += UserControlCard_MouseDown;
            MouseMove += UserControlCard_MouseMove;
            MouseUp += UserControlCard_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Label labelHeading;
        public TextBox textBox1;
    }
}
