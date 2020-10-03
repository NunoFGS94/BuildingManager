using AutoMapper;
using BuildingManager.Models;
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
    public class CreateUserHandler : IRequestHandler<CreateUserQuery, bool>
    {
        private readonly IBuildingUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IBuildingUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateUser(_mapper.Map<BuildingUser>(request.buildingUser));
        }
    }
}
