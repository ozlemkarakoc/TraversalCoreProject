using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProject.CQRS.Queries.DestinationQueries;
using TraversalCoreProject.CQRS.Result.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle(GetDestinationByIDQuery getDestinationByIDQuery)
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();
            return values;
        }

        internal object Handle()
        {
            throw new NotImplementedException();
        }
    }
}
