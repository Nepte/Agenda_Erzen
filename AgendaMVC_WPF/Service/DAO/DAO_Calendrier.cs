using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaMVC_WPF.Service.DAO
{
    public class DAO_Calendrier
    {
        private CalendarService _calendarService; 

        public DAO_Calendrier(string clientId, string clientSecret) 
        {
            // Initialisation du service Calendar avec les identifiants OAuth 2.0
            _calendarService = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredential(clientId, clientSecret),
                ApplicationName = "AgendaMVC_WPF"
            });
        }

        private UserCredential GetCredential(string clientId, string clientSecret)
        {
            // Code pour récupérer l'objet UserCredential à partir des identifiants OAuth 2.0
            // Cela peut être implémenté en utilisant GoogleWebAuthorizationBroker.AuthorizeAsync
            // ou toute autre méthode de votre choix pour obtenir les informations d'authentification.
            throw new NotImplementedException();
        }

        public async Task<IList<Event>> GetEventsAsync(string calendarId, DateTime startDate, DateTime endDate)
        {
            // Définition de la requête pour récupérer les événements dans une plage de dates
            EventsResource.ListRequest request = _calendarService.Events.List(calendarId);
            request.TimeMinDateTimeOffset = DateTimeOffset.Now;
            request.TimeMaxDateTimeOffset = DateTimeOffset.Now;
            request.ShowDeleted = false;

            // Exécution de la requête pour récupérer les événements
            Events events = await request.ExecuteAsync();

            return events.Items;
        }

        public async Task<string> AddEventAsync(string calendarId, Event newEvent)
        {
            try
            {
                // Ajout d'un nouvel événement au calendrier spécifié
                Event createdEvent = await _calendarService.Events.Insert(newEvent, calendarId).ExecuteAsync();
                return "Événement ajouté avec succès.";
            }
            catch (Exception ex)
            {
                return "Erreur lors de l'ajout de l'événement : " + ex.Message;
            }
        }

        public async Task<string> DeleteEventAsync(string calendarId, string eventId)
        {
            try
            {
                // Suppression de l'événement spécifié du calendrier
                await _calendarService.Events.Delete(calendarId, eventId).ExecuteAsync();
                return "Événement supprimé avec succès.";
            }
            catch (Exception ex)
            {
                return "Erreur lors de la suppression de l'événement : " + ex.Message;
            }
        }
    }
}
