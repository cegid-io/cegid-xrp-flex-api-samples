using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace ExempleDemoApi_CegidXrpFlex
{
    class XrpFlexConnection
    {
        public string baseURL = "";
        public string token = "";

        public XrpFlexConnection(string _baseURL, string _token)
        {
            this.baseURL = _baseURL;
            this.token = _token;
        }

        public string executeGetRequest(string param)
        {
            var client = new RestClient(this.baseURL + "/" + param);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; 
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + this.token);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string executePutRequest(string req, string param)
        {
            var client = new RestClient(this.baseURL + "/" + req);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; 
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + this.token);
            request.AddParameter("application/json", param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
   
        public string executeDeleteRequest(string param)
        {
            var client = new RestClient(this.baseURL + "/" + param);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true; 
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + this.token);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
