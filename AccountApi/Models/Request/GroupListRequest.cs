using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models.Request
{
    public class GroupListRequest
    {
        public string Filter { get; set; }
        public string Attributes { get; set; }
        public string ExcludedAttributes { get; set; }
        public int? StartIndex { get; set; }
        public int? Count { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}