using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class UserListRequest
    {
        public string Filter { get; set; }
        public string Attributes { get; set; }
        public string ExcludedAttributes { get; set; }
        public int? StartIndex { get; set; } = 1;
        public int? Count { get; set; } = 10000; // Valor predeterminado según la descripción
        public string SortBy { get; set; }
        public string SortOrder { get; set; } = "ascending";
    }
}