﻿using System.Collections.Generic;

namespace ScotlandsMountains.Domain
{
    public class DomainRoot
    {
        public IList<Mountain> Mountains { get; set; }
        public IList<Map> Maps { get; set; }
    }
}
