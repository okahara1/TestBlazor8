using TestBlazor8.Server.Data;
using TestBlazor8.Server.Models;
using TestBlazor8.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace TestBlazor8.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("[action]")]
        //public Task<RoleInfo> GetRoleInfoList(string id)
        //public IEnumerable<RoleInfo> GetRoleInfoList(string id)
        public async Task<ActionResult<IEnumerable<RoleInfo>>> GetRoleInfoList(string id)
        {
            string sql =
                "select r.role_id AS Id, r.role_name AS RoleName" +
                "  from dbo.AspNetUsers u" +
                "      ,dbo.m_user_detail d" +
                "      ,dbo.m_role r" +
                " where u.UserName = d.user_id" +
                "   and d.role_id = r.role_id" +
                "   and u.UserName = {0}";
            //var role = this._context.Roles.FromSqlRaw(sql, id).ToList();
            var role = this._context.RoleInfo.FromSqlRaw(sql, id).ToList();

            if (role == null)
            {
                return NotFound();
            }

            // デシリアライズ時の属性名の大文字/小文字の差異を無視する設定
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};
            //RoleInfo RoleInfoResult = JsonSerializer.Deserialize<RoleInfo>(role, options);

            return role;
        }

        //[HttpGet("{id}")]
        //public Task<RoleInfo> GetRoleInfoList(string id) =>
        //    (Task<RoleInfo>)_context.RoleInfo
        //        .FromSqlRaw(
        //            @"select r.role_name AS RoldId
        //                from dbo.AspNetUsers u
        //                    ,dbo.m_user_detail d
        //                    ,dbo.m_role r
        //               where u.UserName = d.user_id
        //                 and d.role_id = r.role_id
        //                 and u.UserName = {0}
        //            ", id
        //        )
        //    ;

    }
}
