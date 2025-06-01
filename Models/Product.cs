using System;
using System.Collections.Generic;

namespace khaithocode_deploy_webapi.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Image { get; set; }
}
