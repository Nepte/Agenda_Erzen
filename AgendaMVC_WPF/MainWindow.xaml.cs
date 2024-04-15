using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AgendaMVC_WPF.Vue;



namespace AgendaMVC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ToDoList_BTN_Click(object sender, RoutedEventArgs e)
        {

            Page_ToDoList page_ToDoList = new Page_ToDoList();
            window_container.Children.Clear();
            window_container.Children.Add(page_ToDoList);



        }


        private void Accueil_BTN_Click(object sender, RoutedEventArgs e)
        {

            Page_Accueil page_Accueil = new Page_Accueil();
            window_container.Children.Clear();
            window_container.Children.Add(page_Accueil);




        }

        private void Contacts_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Mettre à jour le Foreground du bouton "Contacts"
            //((Button)sender).Foreground = Brushes.White;
            //Bouton_Accueil.Foreground = (Brush)new BrushConverter().ZConvertFromString("#D0C0FF");


            Page_Contact page_Contact = new Page_Contact();
            window_container.Children.Clear();
            window_container.Children.Add(page_Contact);

        }

        private void Calendrier_BTN_Click(object sender, RoutedEventArgs e)
        {
            Page_Calendrier page_Calendrier = new Page_Calendrier();
            window_container.Children.Clear();
            window_container.Children.Add(page_Calendrier);
        }


    }
}
