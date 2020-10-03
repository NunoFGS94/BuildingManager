using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Queries
{
    public class EndActivityQuery : IRequest<bool>
    {
        public string UserIdNr { get; }

        public EndActivityQuery(string userIdNr)
        {
            UserIdNr = userIdNr;
        }
    }
}
