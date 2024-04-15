using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMVC_WPF;
using AgendaMVC_WPF.Agenda_ErzenDB;
using Microsoft.EntityFrameworkCore;

namespace AgendaMVC_WPF.Service.DAO
{
    public class dao_ToDoList
    {

        public IEnumerable<ToDoList> GetAllToDoLists() // Retourne une liste de ToDoList IEnumerable sert à parcourir une collection d'objets
        {
            using (var context = new AgendaErzenContext())
            {
                return context.ToDoLists.Include(t => t.Taches).ToList();
            }
        }

        public string AddToDoList(ToDoList toDoList)
        {
            using (var context = new AgendaErzenContext())
            {
                context.ToDoLists.Add(toDoList);
                context.SaveChanges();
            }
            return "La liste de tâches a été ajoutée avec succès !";
        }

        public string UpdateToDoList(ToDoList toDoList) // Prend en paramètres un objet de type ToDoList
        {
            using (var context = new AgendaErzenContext()) // Crée une nouvelle instance de la classe AgendaErzenContext
            {
                context.Entry(toDoList).State = EntityState.Modified; // Modifie l'état de l'objet toDoList pour qu'il soit modifié
                context.SaveChanges();
            }
            return "La liste de tâches a été mise à jour avec succès !";
        }

        public string DeleteToDoList(int id)
        {
            using (var context = new AgendaErzenContext())
            {
                var toDoList = context.ToDoLists.FirstOrDefault(t => t.Id == id);
                if (toDoList != null)
                {
                    context.ToDoLists.Remove(toDoList);
                    context.SaveChanges();
                    return "La liste de tâches a été supprimée avec succès !";
                }
                else
                {
                    return "La liste de tâches avec l'ID spécifié n'a pas été trouvée.";
                }
            }
        }
    }
}