using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetfundaAngularJS.Models
{
    public  class Post
    {
        public Post()
        {
            this.postTags = new HashSet<PostTags>();
        }
        [Key]
        public Int64 PostId { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastmodifiedDate { get; set; }

        public virtual ICollection<PostTags> postTags { get; set; }

        public string Status { get; set; }

    }
}