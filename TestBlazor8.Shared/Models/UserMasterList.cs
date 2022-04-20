using System;
using System.Collections.Generic;
using System.Text;

namespace TestBlazor8.Shared.Models
{
    public class UserMasterList
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DeptId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string RoleId { get; set; }

        public string InsertUserId { get; set; }

        public DateTime InsertDt { get; set; }

        public string UpdateUserId { get; set; }

        public DateTime UpdatetDt { get; set; }

    }
}
