using System;
using System.Web;
using Google.GData.Apps;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Calendar;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;

namespace Seadragon
{
    public class Google
    {
        private static string DOMAIN = "sou.edu";
        private static string USERNAME = WebConfigurationManager.OpenWebConfiguration("~/").AppSettings.Settings["googleUser"].Value;
        private static string PASSWORD = WebConfigurationManager.OpenWebConfiguration("~/").AppSettings.Settings["googlePass"].Value;

        public static void setPw(string username, string password)
        {
            try
            {                                
                AppsService service = new AppsService(DOMAIN, USERNAME, PASSWORD);
                UserEntry entry = service.RetrieveUser(username);
                entry.Login.Password = password;
                service.UpdateUser(entry);
            }
            catch (AppsException ex)
            {
                // Probably don't have a Google Apps account yet, do nothing
                if (ex.Reason == "EntityDoesNotExist") { }
                else { throw ex; }
            }
        }

        // Validates a username/pass by attempting to login to calendar
        public static bool checkPw(string username, string password)
        {
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("cl", "Seadragon");
            authFactory.AccountType = "HOSTED";

            CalendarService client = new CalendarService(authFactory.ApplicationName);
            client.RequestFactory = authFactory;
            client.setUserCredentials(username + "@" + DOMAIN, password);

            try
            {
                client.QueryClientLoginToken(); // Authenticate the user immediately
            }
            catch (WebException)     // Invalid login
            {
                return false;
            }

            return true;
        }       
    }
}