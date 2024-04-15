using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Response
{
    public class UserCreationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<Email> Emails { get; set; }
        public Name Name { get; set; }
        public string DisplayName { get; set; }
        public List<Role> Roles { get; set; }
        public string ExternalId { get; set; }
        public bool Active { get; set; }
    }
}