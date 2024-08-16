using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class ClientType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
