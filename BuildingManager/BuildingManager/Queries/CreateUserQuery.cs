using BuildingManager.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class CreateUserQuery : IRequest<bool>
    {
        public BuildingUserView buildingUser { get; }

        public CreateUserQuery(BuildingUserView buildingUser)
        {
            this.buildingUser = buildingUser;
        }
    }
}
