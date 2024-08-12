namespace GestorStock.WinForm
{
    partial class AddProductForm
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
            productNameBox = new Label();
            newProdBox = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // productNameBox
            // 
            productNameBox.AutoSize = true;
            productNameBox.Location = new Point(41, 100);
            productNameBox.Name = "productNameBox";
            productNameBox.Size = new Size(84, 15);
            productNameBox.TabIndex = 0;
            productNameBox.Text = "Product Name";
            // 
            // newProdBox
            // 
            newProdBox.Location = new Point(148, 97);
            newProdBox.Name = "newProdBox";
            newProdBox.Size = new Size(121, 23);
            newProdBox.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(148, 152);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 160);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Black", 12F);
            label3.ForeColor = SystemColors.MenuHighlight;
            label3.Location = new Point(102, 43);
            label3.Name = "label3";
            label3.Size = new Size(124, 23);
            label3.TabIndex = 4;
            label3.Text = "New Product";
            // 
            // button1
            // 
            button1.Location = new Point(114, 214);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 359);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(newProdBox);
            Controls.Add(productNameBox);
            Name = "AddProductForm";
            Text = "New Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label productNameBox;
        private TextBox newProdBox;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}