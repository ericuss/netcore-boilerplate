// Copyright (c) Lanre. All rights reserved.

namespace Lanre.Infrastructure.ControllersCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Lanre.Infrastructure.Constants;
    using Lanre.Infrastructure.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ValidateModel]
    public abstract class ControllerCore : ControllerBase
    {
    }
}