using AgendaMVC_WPF.Agenda_ErzenDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMVC_WPF.Service.DAO
{
    public class DAO_Taches
    {
        public IEnumerable<Tach> GetAllTaches()
        {
            using (var context = new AgendaErzenContext())
            {
                return context.Taches.ToList();
            }
        }

        public string AddTach(Tach tach)
        {
            using (var context = new AgendaErzenContext())
            {
                context.Taches.Add(tach);
                context.SaveChanges();
            }
            return "La tâche a été ajoutée avec succès !";
        }

        public string UpdateTach(Tach tach)
        {
            using (var context = new AgendaErzenContext())
            {
                context.Entry(tach).State = EntityState.Modified;
                context.SaveChanges();
            }
            return "La tâche a été mise à jour avec succès !";
        }

        public string DeleteTach(int id)
        {
            using (var context = new AgendaErzenContext())
            {
                var tach = context.Taches.Find(id);
                if (tach != null)
                {
                    context.Taches.Remove(tach);
                    context.SaveChanges();
                }
            }
            return "La tâche a été supprimée avec succès !";
        }
    }
}