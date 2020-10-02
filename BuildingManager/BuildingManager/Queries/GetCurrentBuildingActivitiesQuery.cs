using BuildingManager.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class GetCurrentBuildingActivitiesQuery : IRequest<List<BuildingActivityViewModel>>
    {
    }
}
