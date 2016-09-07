﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScotlandsMountains.Domain
{
    public interface IDomainRoot
    {
        IList<Classification> Classifications { get; }
        IList<Section> Sections { get; }
        Maps Maps { get; }
        IList<Mountain> Mountains { get; }
        IList<Country> Countries { get; }
    }

    public class DomainRoot : IDomainRoot
    {
        public IList<Classification> Classifications { get; set; }
        public IList<Section> Sections { get; set; }
        public Maps Maps { get; set; }
        public IList<Mountain> Mountains { get; set; }
        public IList<Country> Countries { get; set; }

        public static DomainRoot Load()
        {
            var json = Resources.Load.ScotlandsMountains.DomainJson;
            return JsonConvert.DeserializeObject<DomainRoot>(json, JsonSerializerSettings);
        } 

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, JsonSerializerSettings);
            Resources.Save.ScotlandsMountains.DomainJson(json);
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
