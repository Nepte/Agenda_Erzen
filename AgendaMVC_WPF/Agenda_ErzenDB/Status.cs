using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class Status
{
    public int Id { get; set; }

    public string? Status1 { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
