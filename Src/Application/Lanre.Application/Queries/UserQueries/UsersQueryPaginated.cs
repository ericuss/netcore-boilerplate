// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Application.Queries.UserQueries
{
    using System.Collections.Generic;
    using Lanre.Infrastructure.Entities;
    using MediatR;

    public class UsersQueryPaginated : PaginatedRequest, IRequest<IEnumerable<UserQueryResponse>>
    {
    }
}