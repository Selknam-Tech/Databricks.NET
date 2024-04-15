using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databricks.NET.AccountApi.Models
{
    public class Email
    {
        public string Value { get; set; }
        public string Display { get; set; }
        public bool Primary { get; set; }
        public string Type { get; set; }
    }
}