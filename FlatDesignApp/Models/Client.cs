using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class Client
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public string Name { get; set; } = null!;

    public int? AddressId { get; set; }

    public string? IdentityDocument { get; set; }

    public int? BankDetailId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual BankDetail? BankDetail { get; set; }

    public virtual ICollection<DeliveryNote> DeliveryNotes { get; set; } = new List<DeliveryNote>();

    public virtual ClientType? Type { get; set; }
}
