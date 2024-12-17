using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace maratonAPI.Models;

public partial class Eredmenyek
{
    public int Futo { get; set; }

    public int Kor { get; set; }

    public int Ido { get; set; }
    [JsonIgnore]
    public virtual Futok? FutoNavigation { get; set; } = null!;
}
