// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Application.Queries.GetUsers
{
    using System;

    public class GetUserResponse
    {
        public GetUserResponse(Guid id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}