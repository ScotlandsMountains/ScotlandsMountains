﻿using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using ScotlandsMountains.Domain;
using System.Linq;

namespace ScotlandsMountains.Web.Controllers
{
    [Route("api/[controller]")]
    public class MountainController : Controller
    {
        private readonly DomainRoot _domainRoot;

        public MountainController(DomainRoot domainRoot)
        {
            _domainRoot = domainRoot;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain);
        }

        [HttpGet("search/{term?}/{page:int?}/{pageSize:int?}")]
        public IActionResult Search(string term = "", int page = 1, int pageSize = 50)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 1 ? 1 : pageSize;
            pageSize = pageSize > 100 ? 100 : pageSize;

            Func<Mountain,bool> isMatch = x => CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Name, term, CompareOptions.IgnoreCase) >= 0;

            var count = _domainRoot.Mountains.Where(isMatch).Count();
            var pages = (count / pageSize) + 1;

            page = page > pages ? pages : page;

            var results = _domainRoot.Mountains
                .Where(isMatch)
                .OrderByDescending(x => x.Height)
                .Skip((page-1) * pageSize)
                .Take(pageSize);

            return new ObjectResult(new { page, pageSize, pages, count, results });
        }

        [HttpGet("{id}/Maps")]
        public IActionResult GetMaps(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.MapIds.Select(x => _domainRoot.Maps.GetById(x)));
        }

        [HttpGet("{id}/Classifications")]
        public IActionResult GetClassifications(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(mountain.ClassificationIds.Select(x => _domainRoot.Classifications.GetById(x)));
        }

        [HttpGet("{id}/Section")]
        public IActionResult GetSection(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(_domainRoot.Sections.GetById(mountain.SectionId));
        }

        [HttpGet("{id}/Country")]
        public IActionResult GetCountry(string id)
        {
            var mountain = _domainRoot.Mountains.GetById(id);

            if (mountain == null)
                return NotFound();

            return new ObjectResult(_domainRoot.Countries.GetById(mountain.CountryId));
        }
    }
}
