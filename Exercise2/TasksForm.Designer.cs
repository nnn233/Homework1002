using System.Windows.Forms;

namespace Homework1002
{
    partial class TasksForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewTasks = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Deadline = new DataGridViewTextBoxColumn();
            IsCompleted = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxDescription = new TextBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            checkBoxTaskCompleted = new CheckBox();
            dateTimePickerDeadline = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTasks
            // 
            dataGridViewTasks.AllowUserToAddRows = false;
            dataGridViewTasks.AllowUserToDeleteRows = false;
            dataGridViewTasks.AllowUserToResizeColumns = false;
            dataGridViewTasks.AllowUserToResizeRows = false;
            dataGridViewTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTasks.BackgroundColor = Color.White;
            dataGridViewTasks.BorderStyle = BorderStyle.None;
            dataGridViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTasks.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewTasks.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTasks.GridColor = SystemColors.Control;
            dataGridViewTasks.Location = new Point(51, 108);
            dataGridViewTasks.Name = "dataGridViewTasks";
            dataGridViewTasks.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewTasks.RowHeadersVisible = false;
            dataGridViewTasks.RowHeadersWidth = 51;
            dataGridViewTasks.RowTemplate.Height = 29;
            dataGridViewTasks.ScrollBars = ScrollBars.Vertical;
            dataGridViewTasks.Size = new Size(702, 331);
            dataGridViewTasks.TabIndex = 3;
            dataGridViewTasks.CellValueChanged += DataGridViewTasks_CellValueChanged;
            dataGridViewTasks.Columns.AddRange(new DataGridViewColumn[] { Id, Description, Deadline, IsCompleted });
            // 
            // Id
            // 
            Id.HeaderText = "";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.SortMode = DataGridViewColumnSortMode.NotSortable;
            Id.Visible = false;
            // 
            // Description
            // 
            Description.HeaderText = "";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Deadline
            // 
            Deadline.HeaderText = "";
            Deadline.MinimumWidth = 6;
            Deadline.Name = "Deadline";
            Deadline.ReadOnly = true;
            Deadline.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // IsCompleted
            // 
            Deadline.HeaderText = "";
            Deadline.MinimumWidth = 6;
            Deadline.Name = "IsCompleted";
            Deadline.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(874, 62);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 4;
            label1.Text = "Задача";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(826, 108);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 5;
            label2.Text = "Описание";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(826, 184);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 6;
            label3.Text = "Срок выполнения";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(826, 131);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(175, 27);
            textBoxDescription.TabIndex = 7;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.LightSeaGreen;
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(826, 312);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(175, 29);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackColor = Color.LightSeaGreen;
            buttonUpdate.Enabled = false;
            buttonUpdate.Location = new Point(826, 360);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(175, 29);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = false;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.LightSeaGreen;
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(826, 410);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(175, 29);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // checkBoxTaskCompleted
            // 
            checkBoxTaskCompleted.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxTaskCompleted.Location = new Point(826, 264);
            checkBoxTaskCompleted.Name = "checkBoxTaskCompleted";
            checkBoxTaskCompleted.Size = new Size(175, 30);
            checkBoxTaskCompleted.TabIndex = 14;
            checkBoxTaskCompleted.Text = "Задача выполнена";
            checkBoxTaskCompleted.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDeadline
            // 
            dateTimePickerDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePickerDeadline.Format = DateTimePickerFormat.Custom;
            dateTimePickerDeadline.Location = new Point(826, 216);
            dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            dateTimePickerDeadline.Size = new Size(175, 27);
            dateTimePickerDeadline.TabIndex = 15;
            // 
            // TasksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1057, 487);
            Controls.Add(dateTimePickerDeadline);
            Controls.Add(checkBoxTaskCompleted);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewTasks);
            Name = "TasksForm";
            Text = "Задачи";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewTasks;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxDescription;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private CheckBox checkBoxTaskCompleted;
        private DateTimePicker dateTimePickerDeadline;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Deadline;
        private DataGridViewCheckBoxColumn IsCompleted;
    }
}