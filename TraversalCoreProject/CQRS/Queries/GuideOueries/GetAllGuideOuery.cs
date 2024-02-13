using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using System.Collections.Generic;
using TraversalCoreProject.CQRS.Result.GuideResults;

namespace TraversalCoreProject.CQRS.Queries.GuideOueries
{
    public class GetAllGuideOuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
