using CodersLinkProjectWebApp.Models;
using CodersLinkProjectWebApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodersLinkProjectWebApp.Repository
{
    public class UsrDataRepo : Repo<UsrDataModel>, IUsrDataRepo
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsrDataRepo(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
    }
}
