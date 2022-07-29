// Copyright Cooling Technology Institute 2019-2022

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class CalculatePrintUserControl : UserControl
    {
        public const float MARGIN = 40;
        public PrintControl PrintControl { get; set; }
        public string Filter { get; set; }
        public string DefaultExt { get; set; }
        public string Title { get; set; }
        public string DefaultFileName { get; set; }
        public string ErrorMessage { get; set; }
        public virtual void PrintPage(object sender, PrintPageEventArgs e) { }
        public virtual void Calculate() { }
        public virtual void ValidatedForm() { }
        public virtual bool OpenDataFile(string fileName) { return false; }
        public virtual bool OpenNewDataFile(string fileName) { return false; }
        public virtual bool SaveDataFile() { return false; }
        public virtual bool SaveAsDataFile(string fileName) { return false; }
        
        public CalculatePrintUserControl()
        {
            PrintControl = new PrintControl();
        }
        
        public string BuildDefaultFileName(string path)
        {
            string dataFileName;

            int i = 1;

            do
            {
                dataFileName = Path.Combine(path, string.Format("{0}{1}.{2}", DefaultFileName, i++, DefaultExt));
                if (File.Exists(dataFileName))
                {
                    dataFileName = string.Empty;
                }

            } while (string.IsNullOrEmpty(dataFileName));
            
            return dataFileName;
        }


        public float DrawText(PrintPageEventArgs e, int fontSize, FontStyle fontStyle, string text, float x, float y, bool center)
        {
            SizeF size;
            
            x += MARGIN;
            y += MARGIN;

            using (Font font = new Font("Times New Roman", fontSize, fontStyle, GraphicsUnit.Point))
            {
                size = e.Graphics.MeasureString(text, font);
                if(center)
                {
                    float centerPoint = x + ((e.PageBounds.Width - x) / 2);
                    x = centerPoint - size.Width / 2;
                }
                e.Graphics.DrawString(text,
                                      font,
                                      new SolidBrush(Color.Black),
                                      x, y);
            }
            return (float)Math.Round((double)size.Height + 0.5) + 2;
        }

        public void DrawLogo(PrintPageEventArgs e, float x, float y)
        {
            e.Graphics.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("colorlogo"), new PointF(x + MARGIN, y + MARGIN));
        }

        public float DrawRectangle(PrintPageEventArgs e, string text, float x, float y, float width, float height, int row, int column, List<float> widths)
        {
            float y1 = y + MARGIN + (row * height);
            float y2 = y1 + height;
            float x1 = x + MARGIN; // + (column * width);
            for(int i = 0; i < column; i++)
            {
                x1 += widths[i];
            }
            //float x2 = x1 + width;

            using (Font font = new Font("Times New Roman", 12, (row == 0) ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectangle = new RectangleF(x1, y1, width, height);
                e.Graphics.DrawString(text, font, Brushes.Black, rectangle);
                e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectangle));
            }
            return y2;
        }

        public string PaddedString(string text)
        {
            return "  " + text + "  ";
        }

        public float DrawDataTable(PrintPageEventArgs e, DataTable dataTable, float x, float y)
        {
            float height = 0;
            float totalHeight = 0;
            float width = 0;
            List<float> widths = new List<float>();

            if(dataTable != null)
            {
                using (Font font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point))
                using (Font fontBold = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point))
                {
                    SizeF size;

                    if (!string.IsNullOrWhiteSpace(dataTable.TableName))
                    {
                        totalHeight = DrawText(e, 12, FontStyle.Bold, dataTable.TableName, x, y, false);
                    }
                    y += totalHeight;

                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        size = e.Graphics.MeasureString(PaddedString(dataColumn.ColumnName), fontBold);
                        if (size.Height > height)
                        {
                            height = size.Height;
                        }
                        if (size.Width > width)
                        {
                            width = size.Width;
                        }
                        widths.Add(size.Width);
                    }

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            if(dataRow[i] is string)
                            {
                                size = e.Graphics.MeasureString(PaddedString((string)dataRow[i]), font);
                                if (size.Height > height)
                                {
                                    height = size.Height;
                                }
                                if (size.Width > widths[i])
                                {
                                    widths[i] = size.Width;
                                }
                            }
                        }
                    }

                    height = (float)Math.Round((double)height + 0.5);
                    
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        widths[i] = (float)Math.Round((double)widths[i] + 0.5);
                        DrawRectangle(e, PaddedString(dataTable.Columns[i].ColumnName), x, y, widths[i], height, 0, i, widths);
                    }
                    totalHeight += height;
                    int row = 1;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            if (dataRow[i] is string)
                            {
                                DrawRectangle(e, PaddedString((string)dataRow[i]), x, y, widths[i], height, row, i, widths);
                            }
                        }
                        totalHeight += height;
                        row++;
                    }
                }

            }
            return totalHeight + 20;
        }

        public float GetDataTableHeight(PrintPageEventArgs e, DataTable dataTable)
        {
            float totalHeight = 0;

            if (dataTable != null)
            {
                using (Font font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point))
                using (Font fontBold = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point))
                {
                    SizeF size;

                    if (!string.IsNullOrWhiteSpace(dataTable.TableName))
                    {
                        size = e.Graphics.MeasureString(dataTable.TableName, fontBold);
                        totalHeight += (float) Math.Round((double)size.Height + 0.5) + 2;
                    }
                    size = e.Graphics.MeasureString(PaddedString((string)dataTable.Rows[0][0]), fontBold);
                    totalHeight += (float) Math.Round((double)size.Height + 0.5);

                    size = e.Graphics.MeasureString(PaddedString((string)dataTable.Rows[0][0]), font);
                    totalHeight += (float) Math.Round((double)size.Height + 0.5) * (float) dataTable.Rows.Count;
                }
            }
            return totalHeight + 20;
        }
    }
}
