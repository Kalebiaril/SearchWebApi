using Microsoft.AspNetCore.Mvc;
using SearchWebApi.Interfaces;
using System.Threading.Tasks;

namespace SearchWebApi.Clients
{
    public class BingSearchClient : IBingSearchClient
    {
        public Task<JsonResult> SearchAsync(string searchString)
        {
            throw new System.NotImplementedException();
        }
    }
}
