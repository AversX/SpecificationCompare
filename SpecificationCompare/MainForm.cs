using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Text;

namespace SpecificationCompare
{
    struct Unit
    {
        string group;
        string article;
        string name;
        string number;
        string measure;
        string manufacture;


        List<Error> errors;

        bool finded;

        public string Manufacture { get => manufacture; set => manufacture = value; }
        public string Measure { get => measure; set => measure = value; }
        public string Name { get => name; set => name = value; }
        public string Article { get => article; set => article = value; }
        public string Group { get => group; set => group = value; }
        public string Number { get => number; set => number = value; }
        public bool Finded { get => finded; set => finded = value; }
        internal List<Error> Errors { get => errors; set => errors = value; }
    }

    struct Error
    {
        int errorCode;
        string oldValue;

        public int ErrorCode { get => errorCode; set => errorCode = value; }
        public string OldValue { get => oldValue; set => oldValue = value; }
    }

    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private Excel.Application excel;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OldVerTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void OldVerTxt_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string objects = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                oldVerTxt.Text = objects;
            }
        }

        private void NewVerTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void NewVerTxt_DragDrop(object sender, DragEventArgs e)
        {
            string objects = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            newVerTxt.Text = objects;
        }

        private void SrchSpecOldBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                oldVerTxt.Text = ofd.FileName;
        }

        private void SrchSpecNewBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                newVerTxt.Text = ofd.FileName;
        }

        private void CompareBtn_Click(object sender, EventArgs e)
        {
            List<Unit> Units  = new List<Unit>();

            List<Unit> OldUnits = new List<Unit>();
            OldUnits.AddRange(LoadDataSpec(oldVerTxt.Text));

            List<Unit> NewUnits = new List<Unit>();
            NewUnits.AddRange(LoadDataSpec(newVerTxt.Text));

            Units = Consolidate(OldUnits, NewUnits);
            UploadData(Units);
        }

        private List<Unit> LoadDataSpec(string path)
        {
            List<Unit> units = new List<Unit>();
            DataSet dataSet = new DataSet("EXCEL");
            string connectionString;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;IMEX=0;'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];

            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, connection);
            adapter.Fill(dataSet);
            connection.Close();

            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
                if (dataSet.Tables[0].Rows[row][3].ToString().Length > 0)
                {
                    Unit unit = new Unit()
                    {
                        Group = dataSet.Tables[0].Rows[row][0].ToString().Trim(),
                        Article = dataSet.Tables[0].Rows[row][1].ToString().Trim(),
                        Name = dataSet.Tables[0].Rows[row][2].ToString().Trim(),
                        Number = dataSet.Tables[0].Rows[row][3].ToString().Trim(),
                        Measure = dataSet.Tables[0].Rows[row][4].ToString().Trim(),
                        Manufacture = dataSet.Tables[0].Rows[row][5].ToString().Trim(),
                        Finded = false
                    };
                    units.Add(unit);
                }
            return units;
        }

        private List<Unit> Consolidate(List<Unit> oldUnits, List<Unit> newUnits)
        {
            for (int i = 0; i < oldUnits.Count; i++)
                for (int j = 0; j < newUnits.Count; j++)
                {
                    if (oldUnits[i].Article != "")
                    {
                        if (oldUnits[i].Article == newUnits[j].Article)
                        {
                            if (oldUnits[i].Finded)
                            {
                                oldUnits.Insert(i, newUnits[j]);
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                errors.Add(new Error() { ErrorCode = 6 });
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                oldUnits[i] = unit;
                                i++;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                if (oldUnits[i].Group != newUnits[j].Group)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 0,
                                        OldValue = oldUnits[i].Group
                                    });
                                    unit.Group = newUnits[j].Group;
                                }
                                if (oldUnits[i].Name != newUnits[j].Name)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 2,
                                        OldValue = oldUnits[i].Name
                                    });
                                    unit.Name = newUnits[j].Name;
                                }
                                if (oldUnits[i].Number != newUnits[j].Number)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 3,
                                        OldValue = oldUnits[i].Number
                                    });
                                    unit.Number = newUnits[j].Number;
                                }
                                if (oldUnits[i].Measure.Replace(".", "") != newUnits[j].Measure.Replace(".", ""))
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 4,
                                        OldValue = oldUnits[i].Measure
                                    });
                                    unit.Measure = newUnits[j].Measure;
                                }
                                if (oldUnits[i].Manufacture != newUnits[j].Manufacture)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 5,
                                        OldValue = oldUnits[i].Manufacture
                                    });
                                    unit.Manufacture = newUnits[j].Manufacture;
                                }
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                unit.Finded = true;
                                oldUnits[i] = unit;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                        }
                        else if (oldUnits[i].Name == newUnits[j].Name)
                        {
                            if (oldUnits[i].Finded)
                            {
                                oldUnits.Insert(i, newUnits[j]);
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                errors.Add(new Error() { ErrorCode = 6 });
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                oldUnits[i] = unit;
                                i++;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                if (oldUnits[i].Group != newUnits[j].Group)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 0,
                                        OldValue = oldUnits[i].Group
                                    });
                                    unit.Group = newUnits[j].Group;
                                }
                                if (oldUnits[i].Article != newUnits[j].Article)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 1,
                                        OldValue = oldUnits[i].Article
                                    });
                                    unit.Article = newUnits[j].Article;
                                }
                                if (oldUnits[i].Number != newUnits[j].Number)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 3,
                                        OldValue = oldUnits[i].Number
                                    });
                                    unit.Number = newUnits[j].Number;
                                }
                                if (oldUnits[i].Measure.Replace(".", "") != newUnits[j].Measure.Replace(".", ""))
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 4,
                                        OldValue = oldUnits[i].Measure
                                    });
                                    unit.Measure = newUnits[j].Measure;
                                }
                                if (oldUnits[i].Manufacture != newUnits[j].Manufacture)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 5,
                                        OldValue = oldUnits[i].Manufacture
                                    });
                                    unit.Manufacture = newUnits[j].Manufacture;
                                }
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                unit.Finded = true;
                                oldUnits[i] = unit;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                    else
                    {
                        if (oldUnits[i].Name == newUnits[j].Name)
                        {
                            if (oldUnits[i].Finded)
                            {
                                oldUnits.Insert(i, newUnits[j]);
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                errors.Add(new Error() { ErrorCode = 6 });
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                oldUnits[i] = unit;
                                i++;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                Unit unit = oldUnits[i];
                                List<Error> errors = new List<Error>();
                                if (oldUnits[i].Group != newUnits[j].Group)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 0,
                                        OldValue = oldUnits[i].Group
                                    });
                                    unit.Group = newUnits[j].Group;
                                }
                                if (oldUnits[i].Article != newUnits[j].Article)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 1,
                                        OldValue = oldUnits[i].Article
                                    });
                                    unit.Name = newUnits[j].Name;
                                }
                                if (oldUnits[i].Number != newUnits[j].Number)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 3,
                                        OldValue = oldUnits[i].Number
                                    });
                                    unit.Number = newUnits[j].Number;
                                }
                                if (oldUnits[i].Measure.Replace(".", "") != newUnits[j].Measure.Replace(".", ""))
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 4,
                                        OldValue = oldUnits[i].Measure
                                    });
                                    unit.Measure = newUnits[j].Measure;
                                }
                                if (oldUnits[i].Manufacture != newUnits[j].Manufacture)
                                {
                                    errors.Add(new Error
                                    {
                                        ErrorCode = 5,
                                        OldValue = oldUnits[i].Manufacture
                                    });
                                    unit.Manufacture = newUnits[j].Manufacture;
                                }
                                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                                else unit.Errors.AddRange(errors);
                                unit.Finded = true;
                                oldUnits[i] = unit;
                                newUnits.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            for (int j = 0; j < newUnits.Count; j++)
            {
                Unit unit = newUnits[j];
                List<Error> errors = new List<Error>();
                errors.Add(new Error() { ErrorCode = 7 });
                if (unit.Errors == null) unit.Errors = new List<Error>(errors);
                else unit.Errors.AddRange(errors);
                oldUnits.Add(unit);
            }
            return oldUnits;
        }

        private void UploadData(List<Unit> units)
        {
            excel = new Excel.Application();
            excel.SheetsInNewWorkbook = 1;
            excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)excel.Sheets.get_Item(1);
            Excel.Range autoFit;

            int curColumn = 1;
            //sheet.Cells[1, curColumn] = "Группа";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            //sheet.Cells[1, curColumn] = "Код";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            //sheet.Cells[1, curColumn] = "Наименование";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            //sheet.Cells[1, curColumn] = "Кол-во";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            //sheet.Cells[1, curColumn] = "Ед. изм.";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            //sheet.Cells[1, curColumn] = "Завод изготовитель";
            sheet.Columns[curColumn].NumberFormat = "@";
            curColumn++;

            for (int i = 0; i < units.Count; i++)
            {
                sheet.Cells[i + 1, curColumn - 6] = units[i].Group;
                sheet.Cells[i + 1, curColumn - 5] = units[i].Article;
                sheet.Cells[i + 1, curColumn - 4] = units[i].Name;
                sheet.Cells[i + 1, curColumn - 3] = units[i].Number;
                sheet.Cells[i + 1, curColumn - 2] = units[i].Measure;
                sheet.Cells[i + 1, curColumn - 1] = units[i].Manufacture;
                autoFit = (Excel.Range)sheet.Rows[i + 1];
                autoFit.EntireRow.AutoFit();
                for (int j = 1; j <= curColumn - 1; j++) 
                {
                    autoFit = (Excel.Range)sheet.Columns[j];
                    autoFit.AutoFit();
                }
                if (units[i].Errors != null)
                {
                    for (int j = 0; j < units[i].Errors.Count; j++)
                    {
                        switch (units[i].Errors[j].ErrorCode)
                        {
                            case 6: { ((Excel.Range)sheet.Rows[i + 1]).EntireRow.Interior.Color = Color.Blue; break; }
                            case 7: { ((Excel.Range)sheet.Rows[i + 1]).EntireRow.Interior.Color = Color.Green; break; }
                            default:
                                {
                                    sheet.Cells[i + 1, units[i].Errors[j].ErrorCode + 1].Interior.Color = Color.Red;
                                    ((Excel.Range)sheet.Cells[i + 1, units[i].Errors[j].ErrorCode + 1]).AddComment(units[i].Errors[j].OldValue);
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    ((Excel.Range)sheet.Rows[i + 1]).EntireRow.Interior.Color = Color.Yellow;
                }
                
            }
            excel.Visible = true;
        }
    }
}
