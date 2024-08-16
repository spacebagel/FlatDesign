using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class Address
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public string StreetName { get; set; } = null!;

    public string? BuildingNumber { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; } = new List<DeliveryNote>();
}
