using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class DeliveryNote
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public double? Price { get; set; }

    public string? PhoneNumber { get; set; }

    public int? AddressId { get; set; }

    public int? ProductId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Product? Product { get; set; }
}
