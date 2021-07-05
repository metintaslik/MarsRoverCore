using MarsRoverModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Interfaces
{
    public interface IService
    {
        List<RoverVehicle> Initialize();
        string CurrentPosition(RoverVehicle rover);
        void SendCommand(RoverVehicle rover, string command);
        void Mover(RoverVehicle rover);
        void Spinner(RoverVehicle rover);
    }
}
