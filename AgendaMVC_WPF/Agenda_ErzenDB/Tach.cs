using System;
using System.Collections.Generic;

namespace AgendaMVC_WPF.Agenda_ErzenDB;

public partial class Tach
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Tips { get; set; }

    public string? Check { get; set; }

    public int ToDoListId { get; set; }

    public int ToDoListContactsId { get; set; }

    public virtual ToDoList ToDoList { get; set; } = null!;
}
