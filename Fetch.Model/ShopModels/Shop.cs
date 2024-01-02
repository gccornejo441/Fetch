using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fetch.Model.ShopModels;

public partial class Shop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Shop1 { get; set; }

    public string? Specialty { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}

