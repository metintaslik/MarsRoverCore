using MarsRover.Service.Interfaces;
using MarsRoverModels.Enums;
using MarsRoverModels.Models;
using System;
using System.Collections.Generic;

namespace MarsRover.Service.Repositories
{
    public class Repository : IService
    {
        /// <summary>
        /// Initilaze Method
        /// </summary>
        /// <returns></returns>
        public List<RoverVehicle> Initialize() =>
            new List<RoverVehicle>
            {
                new RoverVehicle(new Coordinate(1, 2), Poles.North),
                new RoverVehicle(new Coordinate(3, 3), Poles.East)
            };

        public string CurrentPosition(RoverVehicle rover) =>
            $"{rover.Coordinate.X} {rover.Coordinate.Y} {Enum.GetName(typeof(Poles), rover.Route)[0]}";


        /// <summary>
        /// Send Command list Rover Vehicle
        /// </summary>
        /// <param name="rover">Rover Vehicle param</param>
        /// <param name="command">Send command list</param>
        public void SendCommand(RoverVehicle rover, string command)
        {
            foreach (char cmd in command)
                switch (cmd)
                {
                    case 'L':
                        Spinner(rover);
                        break;
                    case 'R':
                        Spinner(rover);
                        break;
                    case 'M':
                        Mover(rover);
                        break;
                    default:
                        new Exception("It's not valid command.");
                        break;
                }
        }

        /// <summary>
        /// Move in the direction.
        /// </summary>
        /// <param name="rover">Rover Vehicle param</param>
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

        /// <summary>
        /// Turn left/right 90 degrees.
        /// </summary>
        /// <param name="rover">Rover Vehicle param</param>
        public void Spinner(RoverVehicle rover)
        {
            switch (rover.Route)
            {
                case Poles.North:
                    rover.Route = Poles.East;
                    break;
                case Poles.East:
                    rover.Route = Poles.South;
                    break;
                case Poles.South:
                    rover.Route = Poles.West;
                    break;
                case Poles.West:
                    rover.Route = Poles.North;
                    break;
                default:
                    break;
            }
        }
    }
}