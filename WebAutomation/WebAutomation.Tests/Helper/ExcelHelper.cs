using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.Tests.Helper
{
    public class ExcelHelper
    {
        public static void GetExcelData(out string loginId,out string password,out string technology,out string devices)
        {
            using (var stream = File.Open(Directory.GetCurrentDirectory() + "\\TestData.xlsx", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    var result = reader.AsDataSet();
                    var dataTable = result.Tables[0];
                    loginId = dataTable.Rows[1][0].ToString();
                    password = dataTable.Rows[1][1].ToString();
                    technology = dataTable.Rows[1][2].ToString();
                    devices = dataTable.Rows[1][3].ToString();
                }
            }
        }
    }
}
