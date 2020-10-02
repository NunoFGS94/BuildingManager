using BuildingManager.Queries;
using BuildingManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class LogoutHandler
    {
        private readonly BuildingUserRepository _userRepository;


        public async Task<bool> Handle(LogoutQuery request, CancellationToken cancellationToken)
        {
            _userRepository.LogoutUser();

            return true;
        }
    }
}
