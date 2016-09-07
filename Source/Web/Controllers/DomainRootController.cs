﻿using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Controllers
{
    public abstract class DomainRootController : Controller
    {
        protected readonly IDomainRoot DomainRoot;

        protected DomainRootController(IDomainRoot domainRoot)
        {
            DomainRoot = domainRoot;
        }
    }
}
