using MarsRover.Service.Interfaces;
using MarsRoverModels.Enums;
using MarsRoverModels.Models;
using System;
using System.Collections.Generic;

namespace MarsRover.Service.Repositories
{
    public class Repository : IService
    {
        public List<RoverVehicle> Initialize() =>
           new List<RoverVehicle>
           {
                new RoverVehicle(new Coordinate(1, 2), Poles.North),
                new RoverVehicle(new Coordinate(3, 3), Poles.East)
           };

        public string CurrentPosition(RoverVehicle rover) =>
            $"{rover.Coordinate.X} {rover.Coordinate.Y} {Enum.GetName(typeof(Poles), rover.Route)}";

        public void SendCommand(RoverVehicle rover, string command)
        {
            foreach (char cmd in command)
                switch (cmd)
                {
                    case 'L':
                        Spinner(rover, -1);
                        break;
                    case 'R':
                        Spinner(rover, +1);
                        break;
                    case 'M':
                        break;
                    default:
                        new Exception("It's not valid command.");
                        break;
                }
        }

        public void Mover(RoverVehicle rover)
        {
            switch (rover.Route)
            {
                case Poles.North:
                    rover.Coordinate.Y += 1;
                    break;
                case Poles.East:
                    rover.Coordinate.X += 1;
                    break;
                case Poles.South:
                    rover.Coordinate.Y -= 1;
                    break;
                case Poles.West:
                    rover.Coordinate.X -= 1;
                    break;
            }
        }

        public void Spinner(RoverVehicle rover, int move)
        {
            rover.Route = (int)rover.Route + move < (int)Poles.North ? Poles.West : (Poles)(int)rover.Route + move;
        }
    }
}