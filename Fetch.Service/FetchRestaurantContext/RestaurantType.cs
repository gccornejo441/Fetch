using System;
using System.Collections.Generic;

namespace Fetch.Service.FetchResturantContext;

public partial class RestaurantType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
