using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class IsUserInBuildingQuery : IRequest<bool>
    {
        public string UserIdNr { get; }

        public IsUserInBuildingQuery(string userIdNr)
        {
            UserIdNr = userIdNr;
        }
    }
}
