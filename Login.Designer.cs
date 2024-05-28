namespace NEfotobudka_githubik
{
    partial class Login
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(298, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 40);
            this.label3.TabIndex = 13;
            this.label3.Text = "АВТОРИЗАЦИЯ";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(322, 228);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(230, 26);
            this.textBoxPass.TabIndex = 12;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(322, 178);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(230, 26);
            this.textBoxLogin.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "Закрыть приложение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Войти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}