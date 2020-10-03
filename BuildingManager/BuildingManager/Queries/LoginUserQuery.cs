using BuildingManager.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class LoginUserQuery : IRequest<bool>
    {
        public BuildingUserView BuildingUser { get; }

        public LoginUserQuery(BuildingUserView buildingUser)
        {
            this.BuildingUser =  buildingUser;
        }
    }
}
