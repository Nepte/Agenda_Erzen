using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Net.NetworkInformation;
using Google.Apis.Util.Store;
using System.Threading;
using AgendaMVC_WPF.Service.DAO;



namespace AgendaMVC_WPF.Vue
{
    public partial class Page_Calendrier : UserControl
    {
        private string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private string ApplicationName = "Google Calendar API .NET Quickstart";


        public Page_Calendrier()
        {
            InitializeComponent();
            Loaded += Page_Calendrier_Loaded;
         

        }

        private async void Page_Calendrier_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGoogleCalendar();
        }

        public bool CheckInternetConnection()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private async Task LoadGoogleCalendar()
        {
            try
            {
                if (!CheckInternetConnection())
                {
                    Console.WriteLine("Aucune connexion Internet.");
                    return;
                }

                // Charger les informations d'identification à partir de client_secret.json
                UserCredential credential;
                using (var stream = new FileStream("C:\\Users\\SLAB67\\Desktop\\AgendaMVC_WPF\\AgendaMVC_WPF\\AgendaMVC_WPF\\Credentials\\client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));

                }

                // Récupérer les événements
                await RetrieveEvents(credential);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }

        // Test de récupération des événements
        private async Task RetrieveEvents(UserCredential credential)
        {
            try
            {
                // Récupération du service Google Calendar
                var service = new CalendarService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });

                // Définition des paramètres de la requête.
                EventsResource.ListRequest request = service.Events.List("primary");
                request.TimeMinDateTimeOffset = DateTimeOffset.Now;
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = await request.ExecuteAsync();
                Console.WriteLine("Upcoming events:");
                if (events.Items == null || events.Items.Count == 0)
                {
                    Console.WriteLine("No upcoming events found.");
                    return;
                }
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTimeDateTimeOffset.HasValue ? eventItem.Start.DateTimeDateTimeOffset.ToString() : "N/A";
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, affichez un message d'erreur
                Console.WriteLine($"Erreur lors de la récupération des événements : {ex.Message}");
            }
        }
    }
}
