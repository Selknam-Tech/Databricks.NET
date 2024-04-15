using System.Text.Json.Serialization;

namespace Databricks.NET.AccountApi.Models.Response
{
    public class GroupResponse
    {
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("startIndex")]
        public int StartIndex { get; set; }

        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("Resources")]
        public List<Group> Groups { get; set; }
    }
}