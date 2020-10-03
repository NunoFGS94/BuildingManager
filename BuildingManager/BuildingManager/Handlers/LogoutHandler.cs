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
    public class LogoutHandler : IRequestHandler<LogoutQuery, bool>
    {
        private readonly IBuildingUserRepository _userRepository;

        public LogoutHandler(IBuildingUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            _userRepository.LogoutUser();

            return true;
        }
    }
}
