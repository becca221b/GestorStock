namespace GestorStock.WinForm
{
    partial class ProductForm
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            nameFilter = new TextBox();
            categoryCombo = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            SearchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(503, 190);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 28);
            button1.Name = "button1";
            button1.Size = new Size(95, 23);
            button1.TabIndex = 1;
            button1.Text = "New Product";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nameFilter
            // 
            nameFilter.Location = new Point(57, 103);
            nameFilter.Name = "nameFilter";
            nameFilter.Size = new Size(100, 23);
            nameFilter.TabIndex = 3;
            // 
            // categoryCombo
            // 
            categoryCombo.FormattingEnabled = true;
            categoryCombo.Items.AddRange(new object[] { "Select category" });
            categoryCombo.Location = new Point(235, 103);
            categoryCombo.Name = "categoryCombo";
            categoryCombo.Size = new Size(121, 23);
            categoryCombo.TabIndex = 4;
            categoryCombo.Text = "Select Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(174, 106);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "Category";
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(383, 102);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(75, 23);
            SearchBtn.TabIndex = 7;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 343);
            Controls.Add(SearchBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(categoryCombo);
            Controls.Add(nameFilter);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "ProductForm";
            Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox nameFilter;
        private ComboBox categoryCombo;
        private Label label3;
        private Label label2;
        private Button SearchBtn;
    }
}