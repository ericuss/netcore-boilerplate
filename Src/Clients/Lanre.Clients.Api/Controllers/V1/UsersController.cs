// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Clients.Api.Controllers.V1
{
    using System;
    using System.Threading.Tasks;
    using Lanre.Application.Commands.UsersCrud;
    using Lanre.Application.Queries.GetUsers;
    using Lanre.Infrastructure.ControllersCore;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class UsersController : ControllerCore
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await this._mediator.Send(new GetUsersQuery());

            return this.Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateCommand command)
        {
            await this._mediator.Send(command);

            return this.Ok(new { });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateCommand command)
        {
            command.Id = id;
            await this._mediator.Send(command);

            return this.Ok(new { });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(Guid id)
        {
            var command = new UserDeleteCommand()
            {
                Id = id,
            };

            await this._mediator.Send(command);

            return this.Ok(new { });
        }

    }
}