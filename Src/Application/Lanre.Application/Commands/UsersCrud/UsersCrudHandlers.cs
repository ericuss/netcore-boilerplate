// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Application.Commands.UsersCrud
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Lanre.Domain.Entities;
    using Lanre.Infrastructure.Repository;
    using MediatR;

    public class UsersCrudHandlers : IRequestHandler<UserCreateCommand, Unit>,
                                     IRequestHandler<UserUpdateCommand, Unit>,
                                     IRequestHandler<UserDeleteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User, Guid> _userRepository;

        public UsersCrudHandlers(IUnitOfWork unitOfWork, IRepository<User, Guid> userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public async Task<Unit> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Surname);
            this._userRepository.Add(user);
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetByIdAsync(request.Id);
            user.Update(request.Name, request.Surname);
            this._userRepository.Update(user);
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetByIdAsync(request.Id);
            this._userRepository.Remove(user);
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
