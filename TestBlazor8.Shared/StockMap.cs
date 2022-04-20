using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace TestBlazor8.Shared
{
    public class StockMap : ClassMap<StockList>
    {
        public StockMap()
        {
            Map(m => m.Id).Index(0).Name("id");
            Map(m => m.Location).Index(1).Name("location");
            Map(m => m.Jan).Index(2).Name("jan");
            Map(m => m.ProductNumber).Index(3).Name("productNumber");
            Map(m => m.ProductName).Index(4).Name("productName");
            Map(m => m.StatusId).Index(5).Name("statusId");
            Map(m => m.StockCount).Index(6).Name("stockCount");
            Map(m => m.StockSchedule).Index(7).Name("stockSchedule");
            Map(m => m.ReserveCount).Index(8).Name("reserveCount");
        }
    }
}
