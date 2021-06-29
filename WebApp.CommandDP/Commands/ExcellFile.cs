using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.CommandDP.Commands
{
    public class ExcellFile<T>
    {


        public readonly List<T> _list;


        public string FileName => $"{typeof(T).Name}.xlsx";

        public string FileType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExcellFile(List<T> list)
        {
            _list = list;

        }


        public MemoryStream Create()
        {
            var wb = new XLWorkbook();
            var ds = new DataSet();

            ds.Tables.Add(GetTable());

            wb.Worksheets.Add(ds);

            var excellMemory = new MemoryStream();
            wb.SaveAs(excellMemory);
            return excellMemory;


        }
        private DataTable GetTable ()
        {
            var tablo = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(x => tablo.Columns.Add(x.Name, x.PropertyType));


            _list.ForEach(
                x =>
                {
                    var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToArray();

                    tablo.Rows.Add(values);
                });
            return tablo;
        }



    }
}
