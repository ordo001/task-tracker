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
            labelCount = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // labelHeading
            // 
            labelHeading.AutoSize = true;
            labelHeading.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHeading.Location = new Point(10, 29);
            labelHeading.Name = "labelHeading";
            labelHeading.Size = new Size(75, 21);
            labelHeading.TabIndex = 0;
            labelHeading.Text = "Heading";
            labelHeading.Click += labelHeading_Click;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(9, 8);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(38, 15);
            labelCount.TabIndex = 1;
            labelCount.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(9, 64);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(378, 114);
            textBox1.TabIndex = 2;
            // 
            // UserControlCard
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(textBox1);
            Controls.Add(labelCount);
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

        private Label labelHeading;
        private Label labelCount;
        private TextBox textBox1;
    }
}
