namespace GestorStock.WinForm
{
    partial class RegisterForm
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
            nameTextBox = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            passTextBox = new TextBox();
            label2 = new Label();
            confirmTextBox = new TextBox();
            saveRegisterBtn = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.AutoSize = true;
            nameTextBox.Location = new Point(115, 94);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(39, 15);
            nameTextBox.TabIndex = 0;
            nameTextBox.Text = "Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(175, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 133);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 2;
            label1.Text = "Password";
            // 
            // passTextBox
            // 
            passTextBox.Location = new Point(175, 133);
            passTextBox.Name = "passTextBox";
            passTextBox.Size = new Size(100, 23);
            passTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 180);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 4;
            label2.Text = "Confirm password";
            // 
            // confirmTextBox
            // 
            confirmTextBox.Location = new Point(175, 177);
            confirmTextBox.Name = "confirmTextBox";
            confirmTextBox.Size = new Size(100, 23);
            confirmTextBox.TabIndex = 5;
            // 
            // saveRegisterBtn
            // 
            saveRegisterBtn.Location = new Point(131, 236);
            saveRegisterBtn.Name = "saveRegisterBtn";
            saveRegisterBtn.Size = new Size(75, 23);
            saveRegisterBtn.TabIndex = 6;
            saveRegisterBtn.Text = "Save";
            saveRegisterBtn.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 450);
            Controls.Add(saveRegisterBtn);
            Controls.Add(confirmTextBox);
            Controls.Add(label2);
            Controls.Add(passTextBox);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(nameTextBox);
            Name = "RegisterForm";
            Text = "Register Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameTextBox;
        private TextBox textBox1;
        private Label label1;
        private TextBox passTextBox;
        private Label label2;
        private TextBox confirmTextBox;
        private Button saveRegisterBtn;
    }
}