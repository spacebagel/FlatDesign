using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; } = new List<DeliveryNote>();
}
