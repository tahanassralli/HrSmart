using Hrsmart.Domain.Entites;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HrSmart.Service
{
    public class RefferingService : IRefferingService
    {
         private readonly RestClient _client;
         private readonly string _url = "http://localhost:22905/";

        public RefferingService()
        {
            _client = new RestClient(_url);
        }

        public IEnumerable<RefferingEmployee> GetAll()
        {
            var request = new RestRequest("api/RefferingEmployees", Method.GET) { RequestFormat = DataFormat.Json };

            var response = _client.Execute<List<RefferingEmployee>>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public RefferingEmployee GetById(int id)
        {
            var request = new RestRequest("api/RefferingEmployees/{id}", Method.GET) { RequestFormat = DataFormat.Json };

            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<RefferingEmployee>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }





        public void Add(RefferingEmployee serverData)
        {
            var request = new RestRequest("api/RefferingEmployees", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(serverData);

            var response = _client.Execute<RefferingEmployee>(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception(response.ErrorMessage);
        }

        public void Update(RefferingEmployee serverData)
        {
            var request = new RestRequest("api/RefferingEmployees/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", serverData.Id, ParameterType.UrlSegment);
            request.AddBody(serverData);

            var response = _client.Execute<RefferingEmployee>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception(response.ErrorMessage);
        }

        public void Delete(int id)
        {
            var request = new RestRequest("api/RefferingEmployees/{id}", Method.DELETE);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            var response = _client.Execute<RefferingEmployee>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception(response.ErrorMessage);
        }
    }
}
