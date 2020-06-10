using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCloud.Application.Services;
using WordCloud.Persistence;

namespace WordCloud.Application.Words
{
    public class ListWords
    {
        // Specifies that this query returns a WordCloudDto
        public class Query : IRequest<WordCloudDto>
        {
            public string Url { get; set; }
            public int Count { get; set; }
        }
        public class Handler : IRequestHandler<Query, WordCloudDto>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<WordCloudDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var service = new WordService();
                var results = await service.GetWordsFromSite(request.Url, request.Count);
                return results;
            }
        }
    }
}