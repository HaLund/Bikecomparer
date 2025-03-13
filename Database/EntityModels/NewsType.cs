using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class NewsType
{
    public int NewsTypeId { get; set; }

    public string NewsTypeName { get; set; } = null!;

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
