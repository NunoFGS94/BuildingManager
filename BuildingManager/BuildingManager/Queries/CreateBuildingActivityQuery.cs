using BuildingManager.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class CreateBuildingActivityQuery : IRequest<bool>
    {
        public BuildingActivityViewModel buildingActivity;
        public string currentUser;

        public CreateBuildingActivityQuery(BuildingActivityViewModel buildingActivity, string currentUser)
        {
            this.buildingActivity = buildingActivity;
            this.currentUser = currentUser;
        }
    }
}
