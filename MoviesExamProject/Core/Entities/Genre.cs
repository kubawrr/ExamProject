using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Genre
{
    public int GenreId { get; set; }

    public string? GenreName { get; set; }
}
