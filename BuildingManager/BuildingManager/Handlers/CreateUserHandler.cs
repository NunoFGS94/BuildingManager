using BuildingManager.Queries;
using BuildingManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class CreateUserHandler
    {
        private readonly BuildingUserRepository _userRepository;

        public CreateUserHandler(BuildingUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateUser(request.buildingUser);
        }
    }
}
