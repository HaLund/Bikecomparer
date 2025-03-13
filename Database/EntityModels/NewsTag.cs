using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class NewsTag
{
    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public int NewsId { get; set; }

    public int RelevanceToTag { get; set; }
}
