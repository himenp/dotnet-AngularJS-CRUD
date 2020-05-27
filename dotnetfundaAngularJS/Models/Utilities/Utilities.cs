using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnetfundaAngularJS.Models
{
    public class Utilities
    {
        public static string ConvertCollectionToString(ICollection<Tags> tags)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tag in tags)
            {
                builder.Append(tag.Tag);
                builder.Append(',');
            }
            return builder.ToString();
        }
        public static List<PostTags> ConvertToCollection(PostModel model)
        {
            IRepository<Tags> tagrepository = new Repository<Tags>();
            List<PostTags> tag = new List<PostTags>();
            string[] temptag = model.Tags.Split(';');
            //var TagId = String.Empty;
            foreach (string tg in temptag)
            {
                var tags =  tagrepository.SelectAll().Where(t => t.Tag == tg);
                foreach (var t in tags)
                {
                    var exist = tag.Where(p => p.TagId == Convert.ToInt64(t.TagId)).ToList();

                    if (exist.Count() == 0)
                    {
                        var taG = new PostTags
                        {
                            TagId = Convert.ToInt64(t.TagId)
                        };
                        tag.Add(taG);
                    }
                }
            }
            return tag;
        }
    }
}