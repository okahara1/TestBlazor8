using TestBlazor8.Server.Data;
using TestBlazor8.Server.Models;
using TestBlazor8.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace TestBlazor8.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<StockList>>> GetStockList(string id, string location, string jan, string productnumber, string productname, string statusid)
        {
            string sql =
                "select s.warehouse_id AS Id" +
                "      ,s.location AS Location" +
                "      ,s.jan AS Jan" +
                "      ,s.product_number AS ProductNumber" +
                "      ,s.product_name AS ProductName" +
                "      ,s.status_id AS StatusId" +
                "      ,s.stock_count AS StockCount" +
                "      ,s.stock_schedule AS StockSchedule" +
                "      ,s.reserve_count AS ReserveCount" +
                "      ,s.insert_user_id AS InsertUserId" +
                "      ,s.insert_dt AS InsertDt" +
                "      ,s.update_user_id AS UpdateUserId" +
                "      ,s.update_dt AS UpdatetDt" +
                "  from dbo.t_stock_info s" +
                " where 1=1";

            if (id != null) {
                sql += " and s.warehouse_id = {0}";
            }
            if (location != null)
            {
                sql += " and s.location = {1}";
            }
            if (jan != null)
            {
                sql += " and s.jan = {2}";
            }
            if (productnumber != null)
            {
                sql += " and s.product_number = {3}";
            }
            if (productname != null)
            {
                sql += " and s.product_name = {4}";
            }
            if (statusid != null)
            {
                sql += " and s.status_id = {5}";
            }

            var searchResult = _context.StockList.FromSqlRaw(sql, id, location, jan, productnumber, productname, statusid).ToList();

            if (searchResult == null)
            {
                return NotFound();
            }

            return searchResult;
        }
    }
}
