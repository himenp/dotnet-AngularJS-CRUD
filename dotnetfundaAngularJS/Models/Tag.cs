using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetfundaAngularJS.Models
{
    public class Tags
    {
        [Key]
        public Int64 TagId { get; set; }
        public string Tag { get; set; }
    }
}