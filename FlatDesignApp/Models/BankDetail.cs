using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class BankDetail
{
    public int Id { get; set; }

    public int? BankId { get; set; }

    public string Number { get; set; } = null!;

    public virtual Bank? Bank { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
