using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace HaliSaham.Web.Admin.Code.Rest
{
    [Area("Admin")]
    public class UserRestClient
    {
        private string BASE_API_URI = "http://localhost:5085/api";

        public dynamic Login(string ePosta,string sifre)
        {
            RestClient restClient = new RestClient(BASE_API_URI, configureSerialization: s => s.UseSystemTextJson (new JsonSerializerOptions { PropertyNamingPolicy = null }));
            RestRequest req = new RestRequest("/Auth/Login", Method.Post);
            req.AddJsonBody(new
            { EPosta = ePosta, Sifre = sifre});
            RestResponse resp = restClient.Post(req);
            string msg = resp.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
