using System.Text.Json.Serialization;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class PatchRequest
    {
        [JsonPropertyName("schemas")]
        public string[] Schemas { get; set; } = ["urn:ietf:params:scim:api:messages:2.0:PatchOp"];
        [JsonPropertyName("Operations")]
        public List<Operation> Operations { get; set; } = new List<Operation>();
    }
}