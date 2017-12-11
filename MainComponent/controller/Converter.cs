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
    class Converter
    {

        string filename;
        Excel.Application xlApp;
        object misValue = System.Reflection.Missing.Value;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlDataSheet;
        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
        string pathToProject = AppDomain.CurrentDomain.BaseDirectory;
        ChartModel chart;


        public Converter() { }

        public Converter(string filename, ChartModel chart)
        {
            xlApp = new Excel.Application();
            this.filename = filename;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlDataSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            this.chart = chart;
            xlDataSheet.Name = chart.Name;

        }

        public void closeFile()
        {
            xlWorkBook.SaveAs(filename);
            xlWorkBook.Close();
        }


        public void buildTableExcel()
        {
            int j = 2;

            xlDataSheet.Cells[1, 1] = 'X';
            xlDataSheet.Cells[2, 1] = 'Y';

            foreach (var x in chart.X)
            {
                xlDataSheet.Cells[1, j] = x.ToString();
                j++;
            }
            j = 2;

            foreach (var y in chart.Y)
            {
                xlDataSheet.Cells[2, j] = y.ToString();
                j++;
            }



            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlDataSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlDataSheet.get_Range("A1", "B" + (j - 1));
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
            var xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
            xAxis.HasTitle = true;
            xAxis.AxisTitle.Text = chart.NameX;
            yAxis.HasTitle = true;
            yAxis.AxisTitle.Text = chart.NameY;
            chartPage.Export(pathToProject + "chartSales.bmp", "BMP", misValue);
        }
    }



}
