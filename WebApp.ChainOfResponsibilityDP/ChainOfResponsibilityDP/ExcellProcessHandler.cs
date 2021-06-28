using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ChainOfResponsibilityDP.ChainOfResponsibilityDP
{
    public class ExcellProcessHandler<T> :ProcessHandler
    {
        private DataTable GetTable(object o)
        {

            var table = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(x => table.Columns.Add(x.Name, x.PropertyType));

            var list = o as List<T>;

            list.ForEach(x =>
            {
                var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToArray();
                table.Rows.Add(values);
            });

            return table;




        }

        public override object handle(object o)
        {

            var wb = new XLWorkbook();
            var ds = new DataSet();
            ds.Tables.Add(GetTable(o));
            wb.Worksheets.Add(ds);
            var excellMemoryStream = new MemoryStream();
            wb.SaveAs(excellMemoryStream);

            return base.handle(excellMemoryStream);
        }
        

    }
}
