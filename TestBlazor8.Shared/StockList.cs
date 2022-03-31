using System;
using System.Collections.Generic;
using System.Text;

namespace TestBlazor8.Shared
{
    public class StockList
    {
        public string Id { get; set; }

        public string Location { get; set; }

        public string Jan { get; set; }

        public string ProductNumber { get; set; }

        public string ProductName { get; set; }

        public string StatusId { get; set; }

        public int StockCount { get; set; }

        public int StockSchedule { get; set; }

        public int ReserveCount { get; set; }

        public string InsertUserId { get; set; }

        public DateTime InsertDt { get; set; }

        public string UpdateUserId { get; set; }

        public DateTime UpdatetDt { get; set; }

    }
}
