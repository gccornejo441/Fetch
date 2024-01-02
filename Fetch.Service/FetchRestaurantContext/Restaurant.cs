using System;
using System.Collections.Generic;

namespace Fetch.Service.FetchResturantContext;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public string? Address { get; set; }

    public double? Rating { get; set; }

    public string? PhoneNumber { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Description { get; set; }

    public string? OpeningHours { get; set; }

    public virtual RestaurantType Type { get; set; } = null!;
}
