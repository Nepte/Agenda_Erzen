using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class ToDoList
{
    public int Id { get; set; }

    public string? Titre { get; set; }

    public string? Date { get; set; }

    public string? DateFin { get; set; }

    public string? Description { get; set; }

    public int ContactsId { get; set; }

    public virtual Contact Contacts { get; set; } = null!;

    public virtual ICollection<Tach> Taches { get; set; } = new List<Tach>();
}
