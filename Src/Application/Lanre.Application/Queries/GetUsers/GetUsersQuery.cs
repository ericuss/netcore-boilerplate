// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Application.Queries.GetUsers
{
    using System.Collections.Generic;
    using MediatR;

    public class GetUsersQuery : IRequest<IEnumerable<GetUserResponse>>
    {
    }
}