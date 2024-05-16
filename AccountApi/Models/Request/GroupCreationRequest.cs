using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class GroupCreationRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
        [JsonPropertyName("members")]
        public List<Member> Members { get; set; } = new List<Member>();
        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; } = new List<Role>();
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }
    }
}