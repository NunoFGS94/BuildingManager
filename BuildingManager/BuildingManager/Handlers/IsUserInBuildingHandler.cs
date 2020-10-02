using AutoMapper;
using BuildingManager.Queries;
using BuildingManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class IsUserInBuildingHandler
    {

        private readonly IBuildingActivityRepository _buildingActivityRepository;

        public IsUserInBuildingHandler(IBuildingActivityRepository buildingActivityRepository)
        {
            _buildingActivityRepository = buildingActivityRepository;
        }

        public async Task<bool> Handle(IsUserInBuildingQuery request, CancellationToken cancellationToken)
        {
            return _buildingActivityRepository.IsUserInBuilding(request.UserIdNr);
        }
    }
}
