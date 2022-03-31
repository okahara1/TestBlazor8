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
        public async Task<ActionResult<IEnumerable<StockList>>> GetStockList(string id)
        {
            int argCnt = 0;
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

            sql += " and u.UserName = {" + argCnt + "}";
            argCnt++;

            sql += " and u.UserName = {" + argCnt + "}";

            var searchResult = _context.StockList.FromSqlRaw(sql, id, id, id, id).ToList();

            if (searchResult == null)
            {
                return NotFound();
            }

            return searchResult;
        }
    }
}
