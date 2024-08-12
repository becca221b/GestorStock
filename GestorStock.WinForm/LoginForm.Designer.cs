namespace GestorStock.WinForm
{
    partial class LoginForm
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
        private void InitializeComponent()
        {
            userLabel = new Label();
            passLabel = new Label();
            userNameTextBox = new TextBox();
            passTextBox = new TextBox();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(59, 86);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(60, 15);
            userLabel.TabIndex = 0;
            userLabel.Text = "Username";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(59, 145);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(57, 15);
            passLabel.TabIndex = 1;
            passLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(146, 83);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(100, 23);
            userNameTextBox.TabIndex = 2;
            // 
            // passTextBox
            // 
            passTextBox.Location = new Point(146, 142);
            passTextBox.Name = "passTextBox";
            passTextBox.Size = new Size(100, 23);
            passTextBox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(112, 208);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 299);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 5;
            label1.Text = "Dont have an account?";
            // 
            // button2
            // 
            button2.Location = new Point(193, 295);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 450);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(passTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(passLabel);
            Controls.Add(userLabel);
            Name = "LoginForm";
            Text = "Login Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userLabel;
        private Label passLabel;
        private TextBox userNameTextBox;
        private TextBox passTextBox;
        private Button button1;
        private Label label1;
        private Button button2;
    }
}
