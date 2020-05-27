using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetfundaAngularJS.Models
{
    public class PostTags
    {
        [Key]
        public Int64 PostTagId { get; set; }
        public Int64 TagId { get; set; }

        public Int64 PostId { get; set; }
        public virtual Post Post { get; set; }

        public virtual Tags Tag { get; set; }
    }
}