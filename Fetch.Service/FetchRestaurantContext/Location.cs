using System;
using System.Collections.Generic;

namespace Fetch.Service.FetchResturantContext;

public partial class Location
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
