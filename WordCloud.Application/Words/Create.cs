using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordCloud.Domain;
using WordCloud.Persistence;

namespace WordCloud.Application.Words
{
    public class Create
    {
        public class Command : IRequest
        {
            public List<WordCount> Words { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                foreach (var result in request.Words)
                {
                    await _dataContext
                        .Upsert(new WordCount
                        {
                            Id = result.Id,
                            Word = result.Word,
                            Count = result.Count
                        })
                        .On(v => new { v.Word })
                        .WhenMatched(v => new WordCount
                        {
                            Count = v.Count + 1,
                        })
                        .RunAsync();
                }
                return Unit.Value;
            }
        }
    }
}
