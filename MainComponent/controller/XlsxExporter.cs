using OfficeOpenXml;
using ChartComponent;
using System.IO;
using OfficeOpenXml.Drawing.Chart;

namespace MainComponent.controller
{
    /// <summary>
    /// Используется выгрузки диаграммы и данных для неё в xlsx файл
    /// </summary>
    public class XlsxExporter
    {
        /// <summary>
        /// Создание xlsx-файла с диаграммой и данными из объекта ChartModel
        /// </summary>
        /// <param name="fName">Путь к записываемому файлу</param>
        /// <param name="chart">Модель с данными для диаграммы</param>
        public void export(string fName, ChartModel chart)
        {
            using (ExcelPackage eP = new ExcelPackage())
            {
                eP.Workbook.Properties.Author = "qwe";
                eP.Workbook.Properties.Title = chart.Text;
                eP.Workbook.Properties.Company = "NewSystems";


                var sheet = eP.Workbook.Worksheets.Add(chart.Text);
                var graph = sheet.Drawings.AddChart("chart1", eChartType.Line);
                // Устанавливаем положение и размер
                graph.SetPosition(0, 300);
                graph.SetSize(400, 300);

                sheet.Cells[1, 1].Value = 'X'.ToString();
                sheet.Cells[2, 1].Value = 'Y'.ToString();
                sheet.Cells[1, 2].Value = chart?.NameX;
                sheet.Cells[2, 2].Value = chart?.NameY;


                int k = 1;
                int i = 4;

                ///записть данных в таблицу
                foreach (Serie s in chart.SeriesList)
                {
                    sheet.Cells[i, 1].Value = s.SerieName;
                    foreach (var point in s.PointsList)
                    {
                        for (int j = 2; ; j++)
                        {
                            if (sheet.Cells[3, j].Value == null)
                            {
                                sheet.Cells[3, j].Value = point.Key;
                                k++;
                            }
                            
                            if (sheet.Cells[3, j].Value.ToString().Equals(point.Key))
                            {
                                sheet.Cells[i, j].Value = point.Value;
                                sheet.Cells[i, j].Style.Numberformat.Format = @"#,##0.00_ ;\-#,##0.00_ ;0.00_ ;";
                                break;
                            }
                        }
                    }
                    i++;
                }

                i = 4;
                foreach(var s in chart.SeriesList)
                {
                    var serie = graph.Series.Add(sheet.Cells[i, 2, i, k], sheet.Cells[3, 2, 3, k]);
                    serie.HeaderAddress = sheet.Cells[i, 1];
                    i++;
                }

                var bin = eP.GetAsByteArray();
                File.WriteAllBytes(fName, bin);
            }
        }
    }
}
