using AutoMapper;
using BuildingManager.Models;
using BuildingManager.Queries;
using BuildingManager.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class GetCurrentBuildingActivitiesHandler : IRequestHandler<GetCurrentBuildingActivitiesQuery, List<BuildingActivityViewModel>>
    {

        private readonly IBuildingActivityRepository _buildingActivityRepository;
        private readonly IMapper _mapper;

        public GetCurrentBuildingActivitiesHandler(IBuildingActivityRepository buildingActivityRepository, IMapper mapper)
        {
            _buildingActivityRepository = buildingActivityRepository;
            _mapper = mapper;
        }

        public async Task<List<BuildingActivityViewModel>> Handle(GetCurrentBuildingActivitiesQuery request, CancellationToken cancellationToken)
        {
            var activities = await _buildingActivityRepository.GetCurrentBuildingActivities();

            return _mapper.Map<List<BuildingActivity>, List<BuildingActivityViewModel>>(activities);            
        }
    }
}
