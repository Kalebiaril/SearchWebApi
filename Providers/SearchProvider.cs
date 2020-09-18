using AutoMapper;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities.Collections;
using SearchWebApi.DB;
using SearchWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebApi.Providers
{
    public class SearchProvider : ISearchProvider
    {
        private readonly IBingSearchClient _bingSearchClient;
        private readonly IGoogleSearchClient _googleSearchClient;
        private readonly IMapper _mapper;
        private readonly SearchApiDbContext _dbContext;
        private readonly ILogger<SearchProvider> _logger;

        public SearchProvider(IBingSearchClient bingSearchClient, 
            IGoogleSearchClient googleSearchClient,
            IMapper mapper,
            SearchApiDbContext dbContext,
            ILogger<SearchProvider> logger)
        {
            _bingSearchClient = bingSearchClient;
            _googleSearchClient = googleSearchClient;
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<SearchDataModel>> SearchAsync(string seachPhrase)
        {
            var bingSearchTask = _bingSearchClient.SearchAsync(seachPhrase);
            var googleSearchTask = _googleSearchClient.SearchAsync(seachPhrase);
            var bingResult = await bingSearchTask;
            var googleResult = await googleSearchTask;
            return Enumerable.Empty<SearchDataModel>();
            //TODO add to db
        }
    }
}
