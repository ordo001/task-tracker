namespace task_trackerVS
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            labelHello = new Label();
            labelHello2 = new Label();
            labelLogin = new Label();
            labelPassword = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonEnter = new Button();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // labelHello
            // 
            labelHello.AutoSize = true;
            labelHello.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelHello.Location = new Point(40, 51);
            labelHello.Name = "labelHello";
            labelHello.Size = new Size(514, 30);
            labelHello.TabIndex = 0;
            labelHello.Text = "Добро пожаловать в приложение Sigma Trello";
            // 
            // labelHello2
            // 
            labelHello2.AutoSize = true;
            labelHello2.Font = new Font("Segoe UI", 14F);
            labelHello2.Location = new Point(136, 119);
            labelHello2.Name = "labelHello2";
            labelHello2.Size = new Size(312, 25);
            labelHello2.TabIndex = 1;
            labelHello2.Text = "Для начала работы авторизуйтесь";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 14F);
            labelLogin.Location = new Point(55, 190);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(69, 25);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 14F);
            labelPassword.Location = new Point(42, 251);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(82, 25);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Пароль:";
            labelPassword.Click += label2_Click;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI", 13F);
            textBoxLogin.Location = new Point(145, 189);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(318, 31);
            textBoxLogin.TabIndex = 4;
            textBoxLogin.TextChanged += textBoxLoginPassword_TextChanged;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI", 13F);
            textBoxPassword.Location = new Point(145, 250);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(318, 31);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.TextChanged += textBoxLoginPassword_TextChanged;
            // 
            // buttonEnter
            // 
            buttonEnter.Enabled = false;
            buttonEnter.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            buttonEnter.Location = new Point(201, 316);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(186, 38);
            buttonEnter.TabIndex = 6;
            buttonEnter.Text = "Войти";
            buttonEnter.UseVisualStyleBackColor = true;
            buttonEnter.Click += buttonEnter_Click;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = SystemColors.Window;
            buttonClose.Font = new Font("Segoe UI", 10F);
            buttonClose.ForeColor = Color.Red;
            buttonClose.Location = new Point(229, 373);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(133, 26);
            buttonClose.TabIndex = 7;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += button2_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(603, 434);
            Controls.Add(buttonClose);
            Controls.Add(buttonEnter);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(labelHello2);
            Controls.Add(labelHello);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogIn";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHello;
        private Label labelHello2;
        private Label labelLogin;
        private Label labelPassword;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonEnter;
        private Button buttonClose;
    }
}