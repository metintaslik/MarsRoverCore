using MarsRover.Service.Interfaces;
using MarsRoverModels.Enums;
using MarsRoverModels.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.UnitTest
{
    public class MarsRoverTest
    {

        Mock<IService> mock;

        public MarsRoverTest()
        {
            mock = new Mock<IService>();
        }

        [Fact]
        public void InitializeTest()
        {
            //Arrange
            List<RoverVehicle> vehicles = new List<RoverVehicle>
            {
                new RoverVehicle(new Coordinate(1, 2), Poles.North),
                new RoverVehicle(new Coordinate(3, 3), Poles.East)
            };
            mock.Setup(s => s.Initialize()).Returns(vehicles).Verifiable();

            //Act
            vehicles = mock.Object.Initialize();

            //Asserts
            Assert.NotEmpty(vehicles);
            Assert.NotNull(vehicles);
            Assert.Equal(1, vehicles[0].Coordinate.X);
            Assert.Equal(2, vehicles[0].Coordinate.Y);
            Assert.Equal(Poles.North, vehicles[0].Route);
            Assert.Equal(3, vehicles[1].Coordinate.X);
            Assert.Equal(3, vehicles[1].Coordinate.Y);
            Assert.Equal(Poles.East, vehicles[1].Route);
        }

        [Fact]
        public void CurrentPositionTest()
        {
            //Arrange
            List<RoverVehicle> vehicles = new List<RoverVehicle>
            {
                new RoverVehicle(new Coordinate(1, 2), Poles.North),
                new RoverVehicle(new Coordinate(3, 3), Poles.East)
            };
            string message = string.Empty;
            string message1 = string.Empty;
            mock.Setup(s => s.CurrentPosition(vehicles[0])).Returns(message).Verifiable();
            mock.Setup(s => s.CurrentPosition(vehicles[1])).Returns(message1).Verifiable();

            //Act
            message = mock.Object.CurrentPosition(vehicles[0]);
            mock.Object.SendCommand(vehicles[0], "LMLMLMLMM");
            vehicles[0].Coordinate.Y = 3;
            message = $"{vehicles[0].Coordinate.X} {vehicles[0].Coordinate.Y} {Enum.GetName(typeof(Poles), vehicles[0].Route)[0]}";

            mock.Object.SendCommand(vehicles[1], "MMRMMRMRRM");
            vehicles[1].Coordinate.X = 5;
            vehicles[1].Coordinate.Y = 1;
            message1 = $"{vehicles[1].Coordinate.X} {vehicles[1].Coordinate.Y} {Enum.GetName(typeof(Poles), vehicles[1].Route)[0]}";

            //Asserts
            Assert.NotNull(vehicles);
            Assert.NotEmpty(vehicles);
            Assert.NotEmpty(message);
            Assert.NotEmpty(message1);
            Assert.Equal("1 3 N", message);
            Assert.Equal("5 1 E", message1);
        }
    }
}
