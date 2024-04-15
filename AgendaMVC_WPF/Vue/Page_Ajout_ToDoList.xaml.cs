using AgendaMVC_WPF.Agenda_ErzenDB;
using AgendaMVC_WPF.Service.DAO;
using System.Windows;
using System.Windows.Controls;

namespace AgendaMVC_WPF.Vue
{
    public partial class Page_Ajout_ToDoList : UserControl
    {
        private dao_ToDoList _dao_ToDoList;

        public Page_Ajout_ToDoList()
        {
            InitializeComponent();
            _dao_ToDoList = new dao_ToDoList();
        }

        private void Ajouter_BTN_ToDoList(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitre.Text) || string.IsNullOrEmpty(txt_Description.Text) || string.IsNullOrEmpty(txtIDContact.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs !");
                return;
            }

            // Conversion du texte en entier
            if (!int.TryParse(txtIDContact.Text, out int contactsId))
            {
                MessageBox.Show("Veuillez saisir un ID de contact valide !");
                return;
            }

            ToDoList toDoList = new ToDoList();
            toDoList.Titre = txtTitre.Text;
            toDoList.Description = txt_Description.Text;
            toDoList.Date = txtDate.Text;
            toDoList.DateFin = txtDate_fin.Text;

            // Attribution de la valeur de ContactsId
            toDoList.ContactsId = contactsId;

            string result = _dao_ToDoList.AddToDoList(toDoList);
            MessageBox.Show(result);
        }

    }

}