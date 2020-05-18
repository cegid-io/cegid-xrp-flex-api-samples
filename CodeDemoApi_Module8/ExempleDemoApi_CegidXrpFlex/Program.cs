using System;
using System.IO;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ExempleDemoApi_CegidXrpFlex
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            string readText = File.ReadAllText(path);
            JObject json = JObject.Parse(readText);

            string apiUrl = (string)json.SelectToken("url");
            string tokenUrl = (string)json.SelectToken("tokenUrl");
            string username = (string)json.SelectToken("username");
            string password = (string)json.SelectToken("password");
            string scope = (string)json.SelectToken("scope");
            string client_id = (string)json.SelectToken("client_id");
            string client_secret = (string)json.SelectToken("client_secret");

            string token = GetToken.GetOauthToken(username, password, scope, client_id, client_secret, tokenUrl);

            XrpFlexConnection flex = new XrpFlexConnection(apiUrl, token);

            // Requete 1
            const string req1 = "Customer?$expand=MainContact,MainContact/Address,BillingContact&$select=CustomerID,CustomerName,CustomerClass,StatementCycleID,MainContact/Email,MainContact/Phone1,MainContact/Address/AddressLine1,MainContact/Address/AddressLine2,MainContact/Address/City,MainContact/Address/State,MainContact/Address/PostalCode,MainContact/DisplayName&$filter=CustomerName eq 'Hotel du Lac'";
            Console.WriteLine(flex.executeGetRequest(req1));

            // Requete 2
            const string req2 = "Customer?$select=CustomerID,CustomerName,MainContact/Email&$expand=MainContact&$filter=CustomerID eq 'C000000004'";
            Console.WriteLine(flex.executeGetRequest(req2));

            /*// Requete 3
            const string req3 = "Customer?$select=CustomerID,MainContact/Email&$expand=MainContact&$filter=MainContact/Email eq 'ghrum@ghrum.bis'";
            const string param3 = "{\"CustomerName\":{\"value\":\"Gupp info\"}}";
            Console.WriteLine(flex.executePutRequest(req3, param3));*/

            Console.ReadLine();
        }
    }
}
