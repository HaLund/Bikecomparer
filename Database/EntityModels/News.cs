using System;
using System.Collections.Generic;

namespace Database.EntityModels;

public partial class News
{
    public int NewsId { get; set; }

    public string Header { get; set; } = null!;

    public string TextTeaser { get; set; } = null!;

    public string? TextDetail { get; set; }

    public string? Img { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? ImgText { get; set; }

    public int? NewsTypeId { get; set; }

    public virtual NewsType? NewsType { get; set; }
}
