using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class ReseauxSociaux
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lien { get; set; }

    public int ProfilSocialId { get; set; }

    public int ProfilSocialContactsId { get; set; }

    public virtual ProfilSocial ProfilSocial { get; set; } = null!;
}
