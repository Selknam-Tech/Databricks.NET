using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models
{
    public class GroupMember
    {
        [JsonPropertyName("$ref")]
        public string Ref { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }
        
        [JsonPropertyName("display")]
        public string Display { get; set; }
    }
}