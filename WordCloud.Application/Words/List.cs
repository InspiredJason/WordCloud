using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCloud.Persistence;

namespace WordCloud.Application.Words
{
    public class List
    {
        // Specifies that this query returns a WordCountDto
        public class Query : IRequest<WordCountDto> { }
        public class Handler : IRequestHandler<Query, WordCountDto>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<WordCountDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var words = await _dataContext.Words.OrderByDescending(w => w.Count).ToListAsync();
                return new WordCountDto { Words = words };
            }
        }
    }
}