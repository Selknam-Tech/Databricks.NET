using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models
{
    public class Group
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; }

        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; }

        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }
    }

}