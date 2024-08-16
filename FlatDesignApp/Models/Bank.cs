using System;
using System.Collections.Generic;

namespace FlatDesignApp.Models;

public partial class Bank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BankDetail> BankDetails { get; set; } = new List<BankDetail>();
}
