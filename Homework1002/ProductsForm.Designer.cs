namespace Homework1002
{
    partial class ProductsForm
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
            buttonToWord = new Button();
            buttonPrint = new Button();
            dataGridView = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Amout = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Sum = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonToWord
            // 
            buttonToWord.Location = new Point(28, 35);
            buttonToWord.Name = "buttonToWord";
            buttonToWord.Size = new Size(94, 50);
            buttonToWord.TabIndex = 1;
            buttonToWord.Text = "Выгрузка в Word";
            buttonToWord.UseVisualStyleBackColor = true;
            buttonToWord.Click += buttonToWord_Click;
            // 
            // buttonPrint
            // 
            buttonPrint.Enabled = false;
            buttonPrint.Location = new Point(215, 35);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(94, 50);
            buttonPrint.TabIndex = 2;
            buttonPrint.Text = "Печать в Pdf";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Title, Amout, Price, Sum });
            dataGridView.GridColor = Color.White;
            dataGridView.Location = new Point(28, 111);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(790, 324);
            dataGridView.TabIndex = 3;
            // 
            // Title
            // 
            Title.HeaderText = "Название товара";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Amout
            // 
            Amout.HeaderText = "Количество";
            Amout.MinimumWidth = 6;
            Amout.Name = "Amout";
            Amout.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Цена";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Sum
            // 
            Sum.HeaderText = "Итоговая сумма";
            Sum.MinimumWidth = 6;
            Sum.Name = "Sum";
            Sum.ReadOnly = true;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 447);
            Controls.Add(dataGridView);
            Controls.Add(buttonPrint);
            Controls.Add(buttonToWord);
            Name = "ProductsForm";
            Text = "Продукты";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonToWord;
        private Button buttonPrint;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Amout;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Sum;
    }
}