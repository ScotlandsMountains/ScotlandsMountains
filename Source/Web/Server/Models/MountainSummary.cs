﻿using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Models
{
    public class MountainSummary
    {
        public static MountainSummary Build(Mountain mountain)
        {
            return new MountainSummary(mountain);
        }

        public MountainSummary(Mountain mountain)
        {
            Id = mountain.Id;
            Name = mountain.Name;
            Height = $"{mountain.Height.Metres.ToString("#,##0")}m ({mountain.Height.Feet.ToString("#,##0")}ft)";
            Latitude = mountain.Location.Latitude;
            Longitude = mountain.Location.Longitude;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Height { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}