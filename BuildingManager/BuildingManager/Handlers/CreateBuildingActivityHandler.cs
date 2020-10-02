using AutoMapper;
using BuildingManager.Models;
using BuildingManager.Queries;
using BuildingManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class CreateBuildingActivityHandler
    {

        private readonly IBuildingActivityRepository _buildingActivityRepository;
        private readonly IMapper _mapper;

        public CreateBuildingActivityHandler(IBuildingActivityRepository buildingActivityRepository, IMapper mapper)
        {
            _buildingActivityRepository = buildingActivityRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateBuildingActivityQuery request, CancellationToken cancellationToken)
        {
            var buildingActivity = _mapper.Map<BuildingActivity>(request.buildingActivity);
            buildingActivity.IdentificationNumber = request.currentUser;
            buildingActivity.ArrivalDate = DateTime.Now;
            return await _buildingActivityRepository.CreateBuildingActivity(buildingActivity);
        }
    }
}
