using System;
using System.Collections.Generic;

namespace Fetch.Model.RestaurantModels;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RestaurantTypeId { get; set; }

    public string? Address { get; set; }

    public double? Rating { get; set; }

    public string? PhoneNumber { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Description { get; set; }

    public string? OpeningHours { get; set; }

    public int? FoodTypeId { get; set; }

    public virtual RestaurantType? FoodType { get; set; }

    public virtual RestaurantType RestaurantType { get; set; } = null!;
}
