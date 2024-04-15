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
using AgendaMVC_WPF.Service.DAO;
using AgendaMVC_WPF.Agenda_ErzenDB;
using AgendaMVC_WPF.Vue;
using AgendaMVC_WPF;

namespace AgendaMVC_WPF.Vue
{
    /// <summary>
    /// Logique d'interaction pour Page_Ajout.xaml
    /// </summary>
    public partial class Page_Ajout : UserControl
    {
        private dao_Contact _dao_Contact;

        public Page_Ajout()
        {
            InitializeComponent();
            _dao_Contact = new dao_Contact();
        }

        private void Ajouter_BTN_Contacts(object sender, RoutedEventArgs e)
        {
            // Vérifier que tous les champs requis sont renseignés
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelephone.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
                return;
            }

            // Créer un nouvel objet Contact avec les données saisies
            Contact contact = new Contact();
            contact.Name = txtNom.Text;
            contact.Prenom = txtPrenom.Text;
            contact.Email = txtEmail.Text;
            contact.Phone = txtTelephone.Text;
            contact.Adresse = txtAdresse.Text;
            contact.Sexe = txtSexe.Text;
            contact.DateOfBirth = txtDateOfBirth.Text;
            contact.Ville = txtVille.Text;
            contact.StatusId = 1;


            // Ajouter le contact à la base de données
            string result = _dao_Contact.AddContact(contact);

            // Afficher un message de succès ou d'erreur
            MessageBox.Show(result);
        }
    }
}
