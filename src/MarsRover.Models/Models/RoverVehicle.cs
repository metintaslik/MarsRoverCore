using MarsRoverModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverModels.Models
{
    public class RoverVehicle
    {
        public RoverVehicle(Coordinate coordinate, Poles route)
        {
            Coordinate = coordinate;
            Route = route;
        }

        public Coordinate Coordinate { get; set; }
        public Poles Route { get; set; }
    }
}
