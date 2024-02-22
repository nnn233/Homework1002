using Microsoft.Office.Interop.Word;
using Npgsql;

namespace Homework1002
{
    public partial class ProductsForm : Form
    {
        const string CONNECTION_STRING = "host = localhost; port=5432; username = postgres; password = 25481; database = ProductDatabase";
        object? filename = null;
        public ProductsForm()
        {
            InitializeComponent();
            using NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM product_amount_table", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView.Rows.Add(
                    (string)reader.GetValue(1),
                    (int)reader.GetValue(2) + "",
                    (double)reader.GetValue(3) + "",
                    (double)reader.GetValue(4) + "");
            }
        }

        private void buttonToWord_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            winword.Visible = false;

            winword.Documents.Application.Caption = "Список товаров";

            object missing = System.Reflection.Missing.Value;

            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
            {
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[
                WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }
            document.RemoveNumbers();

            foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
            {
                Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            }

            Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "Компания ООО";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "\"СтройМодерн\"";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "Чек";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph.Range.InsertParagraphAfter();

            paragraph = document.Content.Paragraphs.Add(ref missing);
            paragraph.Range.Text = "";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
            paragraph.Range.InsertParagraphAfter();

            Table firstTable = document.Tables.Add(paragraph.Range, dataGridView.Rows.Count + 1, 4, ref missing, ref missing);

            firstTable.Borders.Enable = 1;
            for (var k = 0; k < firstTable.Columns.Count; k++)
            {
                firstTable.Cell(1, k + 1).Range.Text = (string)dataGridView.Columns[k].HeaderText;
            }

            for (var j = 0; j < dataGridView.Rows.Count; j++)
            {
                for (var k = 0; k < firstTable.Columns.Count; k++)
                {
                    firstTable.Cell(j + 2, k + 1).Range.Text = (string)dataGridView.Rows[j].Cells[k].Value;
                }
            }

            int start = document.Content.Start;
            int end = document.Content.End;
            Microsoft.Office.Interop.Word.Range docRange = document.Range(start, end);
            docRange.Font.Size = 14;
            docRange.Font.Name = "Times New Roman";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "(*.docx)|*.docx";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            filename = dialog.FileName;
            document.SaveAs(ref filename);
            document.Close();
            MessageBox.Show("Документ успешно сохранен");
            buttonPrint.Enabled = true;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            _Application _app = new Microsoft.Office.Interop.Word.Application();
            Document doc = _app.Documents.Open(ref filename);
            doc.Application.ActivePrinter = "Microsoft Print to PDF";
            doc.PrintOut();
            MessageBox.Show("Документ успешно сохранен в Pdf формате");
        }
    }
}