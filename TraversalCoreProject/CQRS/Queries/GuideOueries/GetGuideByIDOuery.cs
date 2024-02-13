using MediatR;
using TraversalCoreProject.CQRS.Result.GuideResults;

namespace TraversalCoreProject.CQRS.Queries.GuideOueries
{
    public class GetGuideByIDOuery : IRequest<GetGuideByIDOueryResult>
    {
        public GetGuideByIDOuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
