using System;
using System.Collections.Generic;

namespace Fetch.Model.RestaurantModels;

public partial class FoodType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;
}
