using System;
using System.Collections.Generic;

namespace Fetch.Model.RestaurantModels;

public partial class RestaurantType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Restaurant> RestaurantFoodTypes { get; set; } = new List<Restaurant>();

    public virtual ICollection<Restaurant> RestaurantRestaurantTypes { get; set; } = new List<Restaurant>();
}
