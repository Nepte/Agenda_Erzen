using AgendaMVC_WPF.Agenda_ErzenDB;
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

namespace AgendaMVC_WPF.Vue
{
    /// <summary>
    /// Logique d'interaction pour Page_ToDoList.xaml
    /// </summary>
    public partial class Page_ToDoList : UserControl
    {

        public dao_ToDoList _daoToDoList; // Déclaration de la variable _daoToDoList

        public Page_ToDoList()
        {
            InitializeComponent();
            _daoToDoList = new dao_ToDoList();
            ChargerToDoLists();

        }

        private void ChargerToDoLists()
        {
            try
            {
                IEnumerable<ToDoList> toDoLists = _daoToDoList.GetAllToDoLists();
                ToDoListDataGrid.ItemsSource = toDoLists;
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors du chargement des listes de tâches
                Console.WriteLine("Une erreur s'est produite lors du chargement des listes de tâches : " + ex.Message);
            }
        }

        private void Ajouter_BTN_ToDoList(object sender, RoutedEventArgs e)
        {
            Page_Ajout_ToDoList page_Ajout_ToDoList = new Page_Ajout_ToDoList();
            ParentGrid.Children.Clear();
            ParentGrid.Children.Add(page_Ajout_ToDoList);
        }

        private void Supprimer_BTN_ToDoList(object sender, RoutedEventArgs e)
        {
            if (ToDoListDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une liste de tâches à supprimer !");
                return;
            }

            ToDoList toDoList = (ToDoList)ToDoListDataGrid.SelectedItem;
            string result = _daoToDoList.DeleteToDoList(toDoList.Id);
            MessageBox.Show(result);
            ChargerToDoLists();
        }



    }
}