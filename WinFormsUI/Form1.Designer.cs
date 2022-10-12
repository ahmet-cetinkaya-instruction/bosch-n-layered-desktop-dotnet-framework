namespace WinFormsUI
{
    partial class Form1
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
            this.btnReadData = new System.Windows.Forms.Button();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionRichTb = new System.Windows.Forms.RichTextBox();
            this.categoriesListBox = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(470, 12);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(134, 29);
            this.btnReadData.TabIndex = 0;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(88, 180);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(113, 26);
            this.btnWriteData.TabIndex = 1;
            this.btnWriteData.Text = "Write Data";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descriptionRichTb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.categoryNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnWriteData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 212);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Category Area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name";
            // 
            // categoryNameTextBox
            // 
            this.categoryNameTextBox.Location = new System.Drawing.Point(148, 36);
            this.categoryNameTextBox.Name = "categoryNameTextBox";
            this.categoryNameTextBox.Size = new System.Drawing.Size(141, 22);
            this.categoryNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // descriptionRichTb
            // 
            this.descriptionRichTb.Location = new System.Drawing.Point(148, 79);
            this.descriptionRichTb.Name = "descriptionRichTb";
            this.descriptionRichTb.Size = new System.Drawing.Size(141, 95);
            this.descriptionRichTb.TabIndex = 5;
            this.descriptionRichTb.Text = "";
            // 
            // categoriesListBox
            // 
            this.categoriesListBox.FormattingEnabled = true;
            this.categoriesListBox.ItemHeight = 16;
            this.categoriesListBox.Location = new System.Drawing.Point(346, 51);
            this.categoriesListBox.Name = "categoriesListBox";
            this.categoriesListBox.Size = new System.Drawing.Size(258, 164);
            this.categoriesListBox.TabIndex = 3;
            this.categoriesListBox.SelectedValueChanged += new System.EventHandler(this.categoriesListBox_SelectedValueChanged);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(470, 221);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(134, 29);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Delete Data";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 527);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.categoriesListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReadData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox descriptionRichTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox categoriesListBox;
        private System.Windows.Forms.Button deleteBtn;
    }
}

