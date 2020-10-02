using BuildingManager.Queries;
using BuildingManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingManager.Handlers
{
    public class LoginUserHandler
    {
        private readonly BuildingUserRepository _userRepository;

        public LoginUserHandler(BuildingUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.LoginUser(request.buildingUser);
        }
    }



}
