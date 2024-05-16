using System.Text.Json.Serialization;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class Operation
    {
        [JsonPropertyName("op")]
        public string Op { get; set; } // "add", "remove", o "replace"
        [JsonPropertyName("path")]
        public string Path { get; set; } // La propiedad del grupo a modificar, por ejemplo "members"
        [JsonPropertyName("value")]
        public object Value { get; set; } // Valor nuevo para la propiedad especificada
    }
}