﻿using BuildingManager.Queries;
using BuildingManager.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class EndActivityHandler
    {

        private readonly IBuildingActivityRepository _buildingActivityRepository;

        public EndActivityHandler(IBuildingActivityRepository buildingActivityRepository)
        {
            _buildingActivityRepository = buildingActivityRepository;
        }

        public async Task<bool> Handle(EndActivityQuery request, CancellationToken cancellationToken)
        {
            return _buildingActivityRepository.EndActivity(request.UserIdNr);
        }
    }
}
