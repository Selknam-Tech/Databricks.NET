using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class GroupUpdateRequest
    {
        public string DisplayName { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Role> Roles { get; set; } = new List<Role>();
        public string ExternalId { get; set; }
    }
}