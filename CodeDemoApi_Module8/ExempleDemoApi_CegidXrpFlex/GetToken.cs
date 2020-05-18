using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ExempleDemoApi_CegidXrpFlex
{
    class GetToken
    {
        public static string GetOauthToken(string username, string password, string scope, string client_id, string client_secret, string authUrl)
        {
            var client = new RestClient(authUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            string formUrlEncoding = string.Format("grant_type=password&username={0}&password={1}&scope={2}&client_id={3}&client_secret={4}", 
                username, password, scope, client_id, client_secret);
            request.AddParameter("application/x-www-form-urlencoded", formUrlEncoding, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            JObject json = JObject.Parse(response.Content);
            JToken token = json.SelectToken("access_token");
            return (string)token;

        }
    }
}
