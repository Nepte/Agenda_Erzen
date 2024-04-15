using AgendaMVC_WPF.Service.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AgendaMVC_WPF;
using AgendaMVC_WPF.Agenda_ErzenDB;
using Microsoft.EntityFrameworkCore;
using MahApps.Metro.Controls;

namespace AgendaMVC_WPF.Vue
{

    public partial class Page_Contact : UserControl
    {
        dao_Contact _dao_Contact;  
        public Page_Contact() //
        {
            InitializeComponent();
            _dao_Contact = new dao_Contact();
            ChargerContacts();
            // Appeler la méthode ChargerContacts lors du chargement de la page
        }


        private void ChargerContacts()
        {
            try
            {
                // Récupérer la liste des contacts depuis le DAO
                var contacts = _dao_Contact.GetAllContacts();

                // Affecter la liste des contacts à la source de données du DataGrid
                Contact_DataGrid.ItemsSource = contacts;
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors du chargement des contacts
                MessageBox.Show("Une erreur s'est produite lors du chargement des contacts : " + ex.Message);
            }
        }




        private void Ajouter_BTN_Contacts(object sender, RoutedEventArgs e)
        {
            Page_Ajout page_Ajout = new Page_Ajout();
            // Supprimer tous les enfants du Grid parent
            ParentGrid.Children.Clear();
            // Ajouter la page_Ajout au Grid parent
            ParentGrid.Children.Add(page_Ajout);
        }


        private void Supprimer_BTN_Contacts(object sender, RoutedEventArgs e)
        {

            if (Contact_DataGrid.SelectedItem != null)
            {
                // Récupérer le contact sélectionné
                Contact contact = (Contact)Contact_DataGrid.SelectedItem;
                // Supprimer le contact
                dao_Contact _dao_Contact = new dao_Contact();
               string resultat = _dao_Contact.DeleteContact(contact);
                // Actualiser la liste des contacts
                ChargerContacts();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un contact à supprimer !");
            }
            
        }


        private void Modifier_BTN_Contacts(object sender, RoutedEventArgs e)
        {
            if (Contact_DataGrid.SelectedItem != null)
            {
                // Récupérer le contact sélectionné
                Contact contact = (Contact)Contact_DataGrid.SelectedItem;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un contact à modifier !");
            }
        }
    }
}