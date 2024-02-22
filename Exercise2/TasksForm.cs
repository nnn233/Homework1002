using Npgsql;
using System.Globalization;

namespace Homework1002
{
    public partial class TasksForm : Form
    {
        private readonly NpgsqlConnection con;
        private int id;
        private bool isProgramEvent = false;
        const string dateTimeFormat = "dd.MM.yyyy HH:mm";
        private readonly TimeSpan time = TimeSpan.FromMinutes(10);

        public TasksForm()
        {
            con = new("Host=localhost; port=5432; username=postgres; password=25481; database=TaskDatabase");
            con.Open();
            InitializeComponent();
            GetTasks();
            textBoxDescription.TextChanged += FieldsDataChanged;
            dateTimePickerDeadline.ValueChanged += FieldsDataChanged;
            checkBoxTaskCompleted.CheckedChanged += FieldsDataChanged;
            dataGridViewTasks.SelectionChanged += DataGridViewTasks_SelectionChanged;

            var startTimeSpan = TimeSpan.FromSeconds(60);
            var periodTimeSpan = TimeSpan.FromSeconds(5);

            /*var timer = new System.Threading.Timer((e) =>
             {
                 CheckDeadlines();
             }, null, startTimeSpan, periodTimeSpan);*/
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            Shown += TasksForm_Shown;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTasks.Rows)
            {
                var desc = (string)row.Cells[1].Value;
                var deadline = DateTime.ParseExact((string)row.Cells[2].Value, dateTimeFormat, CultureInfo.InvariantCulture);
                var isCompleted = (bool)row.Cells[3].Value;
                if (!isCompleted && deadline > DateTime.Now && (deadline - DateTime.Now) < time && (deadline - DateTime.Now) >= TimeSpan.FromMinutes(9))
                    MessageBox.Show("До истечения срока выполнения задачи " + desc + " осталось менее 10 минут",
                    "Истечение срока выполнения задачи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TasksForm_Shown(object? sender, EventArgs e)
        {
            CheckOverdueTasks();
            CheckDeadlines();
        }

        private void CheckOverdueTasks()
        {
            foreach (DataGridViewRow row in dataGridViewTasks.Rows)
            {
                var desc = (string)row.Cells[1].Value;
                var deadline = DateTime.ParseExact((string)row.Cells[2].Value, dateTimeFormat, CultureInfo.InvariantCulture);
                var isCompleted = (bool)row.Cells[3].Value;
                if (!isCompleted && deadline < DateTime.Now)
                    MessageBox.Show("Истек срок выполнения задачи " + desc, "Задача просрочена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CheckDeadlines()
        {
            foreach (DataGridViewRow row in dataGridViewTasks.Rows)
            {
                var desc = (string)row.Cells[1].Value;
                var deadline = DateTime.ParseExact((string)row.Cells[2].Value, dateTimeFormat, CultureInfo.InvariantCulture);
                var isCompleted = (bool)row.Cells[3].Value;
                if (!isCompleted && (deadline - DateTime.Now) < time && deadline > DateTime.Now)
                    MessageBox.Show("До истечения срока выполнения задачи " + desc + " осталось менее 10 минут",
                    "Истечение срока выполнения задачи", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetTasks()
        {
            dataGridViewTasks.Rows.Clear();
            NpgsqlCommand cmd = new("SELECT * FROM task", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridViewTasks.Rows.Add((int)reader.GetValue(0),
                    (string)reader.GetValue(1),
                    ((DateTime)reader.GetValue(2)).ToString(dateTimeFormat),
                    (bool)reader.GetValue(3));
            }
            reader.Close();
        }

        private void DataGridViewTasks_SelectionChanged(object? sender, EventArgs e)
        {
            if (isProgramEvent)
                return;
            DataGridViewCell cell = dataGridViewTasks.SelectedCells[0];
            var row = dataGridViewTasks.Rows[cell.RowIndex];
            if (row != null)
            {
                row.Selected = true;
                buttonUpdate.Enabled = true;
                buttonDelete.Enabled = true;
                id = (int)row.Cells["Id"].Value;
                textBoxDescription.Text = (string)row.Cells[1].Value;
                dateTimePickerDeadline.Value = DateTime.ParseExact((string)row.Cells[2].Value, dateTimeFormat, CultureInfo.InvariantCulture);
                checkBoxTaskCompleted.Checked = (bool)row.Cells[3].Value;
                buttonAdd.Enabled = false;
            }
        }

        private void DataGridViewTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var row = dataGridViewTasks.Rows[e.RowIndex];
                Update((int)row.Cells[0].Value, (bool)row.Cells[3].Value);
            }
        }

        private void FieldsDataChanged(object? sender, EventArgs e)
        {
            if (textBoxDescription.Text != "" &&
                !GetTaskByDescription(textBoxDescription.Text.Trim()))
                buttonAdd.Enabled = true;
        }

        private bool GetTaskByDescription(string description)
        {
            NpgsqlCommand cmd = new($"SELECT id FROM task WHERE description = '{description}'", con);
            var data = cmd.ExecuteScalar();
            return data != null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (GetTaskByData(textBoxDescription.Text.Trim(), dateTimePickerDeadline.Value, checkBoxTaskCompleted.Checked))
                MessageBox.Show("Задача с такими параметрами уже существует! Укажите другие данные или обновите существующую");
            else
            {
                Add(textBoxDescription.Text.Trim(), dateTimePickerDeadline.Value, checkBoxTaskCompleted.Checked);
                ClearFields();
            }
        }

        private void Add(string description, DateTime deadline, bool isCompleted)
        {
            NpgsqlCommand cmd = new($"INSERT INTO task(description, deadline, is_completed) VALUES" +
                $"('{description}', '{deadline}', {isCompleted})", con);
            cmd.ExecuteNonQuery();
        }

        private bool GetTaskByData(string description, DateTime deadline, bool isCompleted)
        {
            NpgsqlCommand cmd = new($"SELECT id FROM task WHERE description = '{description}' AND deadline ='{deadline}' AND is_completed = {isCompleted}", con);
            var data = cmd.ExecuteScalar();
            return data != null;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (textBoxDescription.Text != "")
                {
                    Update(id, textBoxDescription.Text.Trim(), dateTimePickerDeadline.Value, checkBoxTaskCompleted.Checked);
                    ClearFields();
                }
                else MessageBox.Show("Поле Описание не может быть пустым!");
            }
        }

        private void Update(int id, string description, DateTime deadline, bool isCompleted)
        {
            NpgsqlCommand cmd = new($"UPDATE task SET " +
                $"description = '{description}', deadline ='{deadline}', is_completed = {isCompleted} WHERE id = {id}", con);
            cmd.ExecuteNonQuery();
        }

        private void Update(int id, bool isCompleted)
        {
            NpgsqlCommand cmd = new($"UPDATE task SET " +
                $"is_completed = {isCompleted} WHERE id = {id}", con);
            cmd.ExecuteNonQuery();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                Delete(id);
                ClearFields();
            }
        }

        private void Delete(int id)
        {
            NpgsqlCommand cmd = new($"DELETE FROM task WHERE id = {id}", con);
            cmd.ExecuteNonQuery();
        }

        private void ClearFields()
        {
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            id = 0;
            textBoxDescription.Clear();

            isProgramEvent = true;
            checkBoxTaskCompleted.Checked = false;
            dateTimePickerDeadline.Value = DateTime.Now;
            GetTasks();
            isProgramEvent = false;
        }
    }
}