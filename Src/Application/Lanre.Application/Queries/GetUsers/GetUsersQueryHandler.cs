// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Application.Queries.GetUsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Lanre.Domain.Entities;
    using Lanre.Infrastructure.Repository;
    using MediatR;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUserResponse>>
    {
        private readonly IRepositoryReadOnly<User, Guid> userRepository;

        public GetUsersQueryHandler(IRepositoryReadOnly<User, Guid> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await this.userRepository.GetAsync();
            var usersMapped = users.Select(u => new GetUserResponse(u.Id, u.Name, u.Surname));
            return usersMapped;
        }
    }
}