using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class UserListRequest
    {
        [JsonPropertyName("filter")]
        public string Filter { get; set; }
        [JsonPropertyName("attributes")]
        public string Attributes { get; set; }
        [JsonPropertyName("excludedAttributes")]
        public string ExcludedAttributes { get; set; }
        [JsonPropertyName("startIndex")]
        public int? StartIndex { get; set; } = 1;
        [JsonPropertyName("count")]
        public int? Count { get; set; } = 10000; // Valor predeterminado según la descripción
        [JsonPropertyName("sortBy")]
        public string SortBy { get; set; }
        [JsonPropertyName("sortOrder")]
        public string SortOrder { get; set; } = "ascending";
    }
}