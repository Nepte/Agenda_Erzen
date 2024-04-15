using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMVC_WPF;
using AgendaMVC_WPF.Agenda_ErzenDB;
using Microsoft.EntityFrameworkCore;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace AgendaMVC_WPF.Service.DAO
{


    public class dao_Contact
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var Context = new AgendaErzenContext())
            {
                return Context.Contacts.ToList();
            }
        }

        public string AddContact(Contact contact)
        {
            using (var Context = new AgendaErzenContext())
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
            return "L'artiste a été ajouté avec succès !";
        }

        public IEnumerable<Contact> GetAllContactsbyName(string nom)
        {

            using (var Context = new AgendaErzenContext())
            {
                return Context.Contacts.Where(c => c.Name == nom).ToList();
            }

        }

        public string UpdateContact(Contact contact)
        {
            using (var Context = new AgendaErzenContext())
            {
                Context.Entry(contact).State = EntityState.Modified;
                Context.SaveChanges();
                return "L'artiste a été mis à jour avec succès !";
            }
        }


        public string DeleteContact(Contact contact)
        {
            using (var context = new AgendaErzenContext())
            {
                var itemToRemove = context.Contacts.FirstOrDefault(c => c.Id == contact.Id);
                if (itemToRemove != null)
                {
                    context.Contacts.Remove(itemToRemove);
                    context.SaveChanges();
                    return "Le contact a bien été supprimé !";
                }
                else
                {
                    return "Le contact spécifié n'a pas été trouvé dans la base de données.";
                }
            }
        }

    }
}