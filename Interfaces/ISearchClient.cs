using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SearchWebApi.Interfaces
{
    public interface ISearchClient
    {
        Task<JsonResult> SearchAsync(string searchString);
    }
}
