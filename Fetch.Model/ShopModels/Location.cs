using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fetch.Model.ShopModels;

public partial class Location
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? ShopId { get; set; }

    public string? Address { get; set; }

    public virtual Shop? Shop { get; set; }
}
