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
    public class DAO_ToDoList

    {

        public IEnumerable<ReseauxSociaux> GetAllReseauxSociaux()
        {

            using (var Context = new AgendaErzenContext())
            {
                return Context.ReseauxSociauxes.ToList();
            }

        }

        public void AddReseauxSociaux(ReseauxSociaux reseauxSociaux)
        {

            using (var Context = new AgendaErzenContext())
            {
                Context.ReseauxSociauxes.Add(reseauxSociaux);
                Context.SaveChanges();
            }

        }

        public void DeleteReseauxSociaux(ReseauxSociaux reseauxSociaux)
        {

            using (var Context = new AgendaErzenContext())
            {

                Context.ReseauxSociauxes.Remove(reseauxSociaux);
                Context.SaveChanges();
            }

        }


        public IEnumerable<ReseauxSociaux> GetAllReseauxSociauxbyName(string nom)
        {

            using (var Context = new AgendaErzenContext())
            {
                return Context.ReseauxSociauxes.Where(c => c.Name == nom).ToList();
            }

        }
    }
}