using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Queries.GuideOueries;
using TraversalCoreProject.CQRS.Result.GuideResults;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDOueryHandler : IRequestHandler<GetGuideByIDOuery, GetGuideByIDOueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDOueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDOueryResult> Handle(GetGuideByIDOuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDOueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Name = values.Name
            };
        }
    }
}
