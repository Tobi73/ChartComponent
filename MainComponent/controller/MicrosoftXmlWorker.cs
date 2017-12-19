using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using ChartComponent;

namespace MainComponent.controller
{
    /// <summary>
    /// класс использует Microsoft библиотеку. Больше не используется в проекте. Удалять жалко.
    /// паскуда гит не захотел комитить то, как я тебя переименовал
    /// </summary>
    class MicrosoftXmlWorker
    {

        string filename;
        Excel.Application xlApp;
        object misValue = System.Reflection.Missing.Value;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlDataSheet;
        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
        ChartModel chart;


        public MicrosoftXmlWorker() { }

        public MicrosoftXmlWorker(string filename, ChartModel chart)
        {
            xlApp = new Excel.Application();
            this.filename = filename;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlDataSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            this.chart = chart;
            xlDataSheet.Name = chart.ChartName;

        }

        public void closeFile()
        {
            xlWorkBook.SaveAs(filename);
            xlWorkBook.Close();
        }


        public void buildTableExcel()
        {


            xlDataSheet.Cells[1, 1] = 'X'.ToString();
            xlDataSheet.Cells[2, 1] = 'Y'.ToString();
            xlDataSheet.Cells[1, 2] = chart?.NameX;
            xlDataSheet.Cells[2, 2] = chart?.NameY;


            int k = 1;
            int i = 4;

            ///записть данных в таблицу
            foreach (Serie s in chart.SeriesList)
            {
                xlDataSheet.Cells[i, 1] = s.SerieName;
                foreach (var point in s.PointsList)
                {
                    for (int j = 2; ; j++)
                    {
                        if ((xlDataSheet.Cells[3, j] as Excel.Range)?.Value2 == null)
                        {
                            xlDataSheet.Cells[3, j] = point.Key;
                            k++;
                        }
                        ///.Value.ToString()
                        var a = xlDataSheet.Cells[3, j];
                        var b = a as Excel.Range;
                        var c = b.Value;
                        var c2 = b.Value2;
                        var d = c.ToString();
                        var e = d.Equals(point.Key);

                        if (((xlDataSheet.Cells[3, j] as Excel.Range).Value.ToString()).Equals(point.Key))
                        {
                            xlDataSheet.Cells[i, j] = point.Value;
                            break;
                        }
                    }
                }
                i++;
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlDataSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlDataSheet.get_Range(xlDataSheet.Cells[3, 1] as Excel.Range, xlDataSheet.Cells[i - 1, k] as Excel.Range);


            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            var xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = chart.NameX;
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = chart.NameY;
            //chartPage.Export(pathToProject + "chartSales.bmp", "BMP", misValue);
        }
    }



}
