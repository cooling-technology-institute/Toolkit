using System;
using System.Data;

namespace CTIToolkit
{
    public class NameValueUnitsDataTable
    {
        public DataTable DataTable { get; set; }

        public NameValueUnitsDataTable()
        {
            DataTable = new DataTable();
            // Declare DataColumn and DataRow variables.
            DataColumn column;

            // Create Name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            DataTable.Columns.Add(column);

            // Create Value column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Value";
            DataTable.Columns.Add(column);

            // Create Units column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Units";
            DataTable.Columns.Add(column);
        }

        public void AddRow(string name, string value, string units)
        {
            DataRow row = DataTable.NewRow();
            row["Name"] = name;
            row["Value"] = value;
            row["Units"] = units;
            DataTable.Rows.Add(row);
        }
    }
}
