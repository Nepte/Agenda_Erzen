using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public int CodePostal { get; set; }

    public string Ville { get; set; } = null!;

    public string DateOfBirth { get; set; } = null!;

    public string Sexe { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual ICollection<ProfilSocial> ProfilSocials { get; set; } = new List<ProfilSocial>();

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
}
