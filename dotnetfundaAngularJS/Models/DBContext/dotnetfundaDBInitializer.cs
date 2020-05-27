using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dotnetfundaAngularJS.Models
{
    public class dotnetfundaDBInitializer : DropCreateDatabaseAlways<dotnetfundaDbContext>
    {
        protected override void Seed(dotnetfundaDbContext context)
        {
            IList<Tags> defaultTags = new List<Tags>();

            defaultTags.Add(new Tags() { Tag = "ASP.NET"});
            defaultTags.Add(new Tags() { Tag = "ASP.NET MVC" });
            defaultTags.Add(new Tags() { Tag = "AngularJS" });
            defaultTags.Add(new Tags() { Tag = "SQL Server" });
            defaultTags.Add(new Tags() { Tag = "WCF" });


            foreach (Tags tag in defaultTags)
                context.tags.Add(tag);

            base.Seed(context);
        }
    }
}