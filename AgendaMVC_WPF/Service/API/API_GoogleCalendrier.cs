using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMVC_WPF.Service;
using AgendaMVC_WPF.Modèle;
using AgendaMVC_WPF.Vue;

namespace AgendaMVC_WPF.Service.API
{
    public class API_GoogleCalendrier
    {
        public string client_id { get; set; }
        public string project_id { get; set; }
        public string auth_uri { get; set; }
        public string token_uri { get; set; }
        public string auth_provider_x509_cert_url { get; set; }
        public string client_secret { get; set; }
        public List<string> redirect_uris { get; set; }
    }

    public class Root
    {
        public API_GoogleCalendrier googleCalendrier { get; set; }
    }


}
}
