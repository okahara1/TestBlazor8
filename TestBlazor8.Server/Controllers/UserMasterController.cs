using TestBlazor8.Server.Data;
using TestBlazor8.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestBlazor8.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<UserMasterList>>> GetUserMaster(string id, string username)
        {
            string sql =
                "select d.user_id AS Id" +
                "      ,d.user_name AS UserName" +
                "      ,d.dept_id AS DeptId" +
                "      ,d.email AS Email" +
                "      ,d.phone_number AS PhoneNumber" +
                "      ,d.role_id AS RoleId" +
                "      ,d.insert_user_id AS InsertUserId" +
                "      ,d.insert_dt AS InsertDt" +
                "      ,d.update_user_id AS UpdateUserId" +
                "      ,d.update_dt AS UpdatetDt" +
                "  from dbo.m_user_detail d" +
                " where 1=1";

            if (id != null && id != "\"\"") {
                sql += " and d.user_id = {0}";
            }
            if (username != null && username != "\"\"")
            {
                sql += " and d.user_name = {1}";
            }

            var searchResult = _context.UserMaster.FromSqlRaw(sql, id, username).ToList();

            if (searchResult == null)
            {
                return NotFound();
            }

            return searchResult;
        }

    }
}
