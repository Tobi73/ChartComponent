using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace MainComponent.controller
{
    class Converter
    {




            string filename;
            Excel.Application xlApp;
            object misValue = System.Reflection.Missing.Value;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlSalesGroupsSheet, xlSalesSheet;
            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
            string pathToProject = AppDomain.CurrentDomain.BaseDirectory;


            public Converter() { }

            public Converter(string filename)
            {
                xlApp = new Excel.Application();
                this.filename = filename;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlSalesGroupsSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                xlSalesGroupsSheet.Name = "Sales by medicine groups";
                xlSalesSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                xlSalesSheet.Name = "Sales";
            }

            public void closeFile()
            {
                xlWorkBook.SaveAs(filename);
                xlWorkBook.Close();
            }


            public void buildTableSales()
            {
                int i = 1, j = 1;
                for (int month = 1; month <= 12; month++)
                {
                    xlSalesGroupsSheet.Cells[month + 1, j] = mfi.GetAbbreviatedMonthName(month);
                }
                j += 1;
                foreach (var medGroup in DbFinder.getAllMedGroups())
                {
                    xlSalesGroupsSheet.Cells[1, j] = medGroup.name;
                    var medNames = DatabaseWorker.med.MedicineName.Where(x => x.idMedicineGroup == medGroup.id);
                    var meds = DatabaseWorker.med.Medicine.Where(x => medNames.Select(y => y.id).Contains(x.idMedicineName));
                    var sales = DatabaseWorker.med.Sale.Where(x => meds.Select(y => y.idSale).Contains(x.id));
                    var count = 0;
                    while (i <= 12)
                    {
                        double sum = 0;

                        foreach (var sale in sales.AsEnumerable().Where(x => Convert.ToDateTime(x.date).Month == i) ?? Enumerable.Empty<Sale>())
                        {
                            sum += sale.costLast;
                        }
                        count += (sales.AsEnumerable().Where(x => Convert.ToDateTime(x.date).Month == i) ?? Enumerable.Empty<Sale>()).Count();
                        xlSalesGroupsSheet.Cells[i + 1, j] = count;
                        count = 0;
                        i++;
                    }
                    j++;
                    i = 1;
                }
                Excel.Range chartRange;

                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlSalesGroupsSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = xlCharts.Add(10, 80, 300, 250);
                Excel.Chart chartPage = myChart.Chart;

                chartRange = xlSalesGroupsSheet.get_Range("A1", "E13");
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
                var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                var xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.HasTitle = true;
                xAxis.AxisTitle.Text = "Month";
                yAxis.HasTitle = true;
                yAxis.AxisTitle.Text = "Count";
                chartPage.Export(pathToProject + "chartSales.bmp", "BMP", misValue);
            }

            public void buildChartProfit()
            {
                int i = 1, j = 1;
                for (int month = 1; month <= 12; month++)
                {
                    xlSalesSheet.Cells[month + 1, j] = mfi.GetAbbreviatedMonthName(month);
                }
                j += 1;
                xlSalesSheet.Cells[i, j] = "Profit";

                while (i <= 12)
                {
                    double profit = 0;
                    double lost = 0;
                    var sales = DatabaseWorker.med.Sale.AsEnumerable().Where(x => Convert.ToDateTime(x.date).Month == i) ?? Enumerable.Empty<Sale>();

                    foreach (var sale in sales)
                    {
                        profit += sale.costLast;
                    }

                    var orders = DatabaseWorker.med.Order.AsEnumerable().Where(x => Convert.ToDateTime(x.date).Month == i) ?? Enumerable.Empty<Order>();
                    foreach (var order in orders)
                    {
                        lost += order.cost;
                    }
                    xlSalesSheet.Cells[i + 1, j] = profit - lost;
                    i++;
                }

                Excel.Range chartRange;

                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlSalesSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = xlCharts.Add(10, 80, 300, 250);
                Excel.Chart chartPage = myChart.Chart;

                chartRange = xlSalesSheet.get_Range("A1", "B13");
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xl3DLine;
                var yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                var xAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                xAxis.HasTitle = true;
                xAxis.AxisTitle.Text = "month";
                yAxis.HasTitle = true;
                yAxis.AxisTitle.Text = "Profit";
                chartPage.Export(pathToProject + "chartProfit.bmp", "BMP", misValue);
            }

            public string ChartProfit
            {
                get
                {
                    return pathToProject + "chartProfit.bmp";
                }
            }

            public string CharSales
            {
                get
                {
                    return pathToProject + "chartSales.bmp";
                }
            }
        }
    


}
