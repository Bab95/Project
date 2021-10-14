using Domain;
using MediatR;
using Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Details
    {
        public class Query: IRequest<Activity>
        {
            public Guid id;
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            async Task<Activity> IRequestHandler<Query, Activity>.Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.FindAsync(request.id);
            }

        }
    }
}