// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Domain.Entities
{
    using System;
    using Lanre.Infrastructure.Entities;

    public class User : Entity<Guid>
    {
        public User(Guid id, string name, string surname)
            : base(id)
        {
            this.Name = name;
            this.Surname = surname;
        }

        private User()
            : base()
        {
        }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}