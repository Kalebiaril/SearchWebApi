using Microsoft.AspNetCore.Mvc;
using SearchWebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchWebApi.Clients
{
    public class GoogleSearchClient : IGoogleSearchClient
    {
        public const string Key = "AIzaSyDp4hqg6RjJUnEEPzYo4gljlW_PgiEf5u8";
        public const string Sid = "1cd4545fea038af2b";
        public const string GoogleUrl = "https://www.googleapis.com/customsearch/v1";

        public async Task<JsonResult> SearchAsync(string searchPhraze) 
        {
            var url = $"{GoogleUrl}?key={Key}&cx={Sid}&q={searchPhraze}";
            using (var client = new HttpClient())
            {

                using (var response = await client.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return new JsonResult(apiResponse);
                }
            }
            
        }  
    }
}
