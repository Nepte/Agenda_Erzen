using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class ProfilSocial
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Lien { get; set; }

    public int ContactsId { get; set; }

    public virtual Contact Contacts { get; set; } = null!;

    public virtual ICollection<ReseauxSociaux> ReseauxSociauxes { get; set; } = new List<ReseauxSociaux>();
}
