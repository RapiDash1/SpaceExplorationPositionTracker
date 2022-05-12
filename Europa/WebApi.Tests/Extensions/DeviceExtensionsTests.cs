using NUnit.Framework;
using System.Collections.Generic;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Tests.Extensions
{
    [TestFixture]
    public class DeviceExtensionsTests
    {
        [Test]
        public void DontReturnError_When_RegisterDeviceObjectIsValid()
        {
            // Arrange
            var registerDevice = new Device
            {
                Name = "Test Name",
                Description = "Test Description",
                Owner = "Test Owner",
                Weight = 10,
                Height = 1,
                Width = 1,
                Depth = 1,
                IsActive = true,
                IsMobile = true
            };

            // Act
            var errors = registerDevice.Validate();

            // Assert
            Assert.IsEmpty(errors);
        }

        [TestCaseSource(nameof(RegisterDeviceData))]
        public void ReturnErrors_When_RegisterDeviceObjectIsValid(Device registerDevice, IReadOnlyCollection<string> expectedErrors)
        {
            // Act
            var errors = registerDevice.Validate();

            // Assert
            Assert.That(errors, Is.EqualTo(expectedErrors));
        }

        static TestCaseData[] RegisterDeviceData =
        {
            new TestCaseData(
                new Device 
                { 
                    Description = "Test Description", 
                    Owner = "Test Owner", 
                    Weight = 10,
                    Height = 1,
                    Width = 1,
                    Depth = 1
                }, 
                new List<string> { 
                    "Name cannot be Null or Empty"
                }),
            new TestCaseData(
                new Device 
                { 
                    Name = "Test Name", 
                    Owner = "Test Owner", 
                    Weight = 10,
                    Height = 1,
                    Width = 1,
                    Depth = 1
                },
                new List<string> { 
                    "Description cannot be Null or Empty"
                }),
            new TestCaseData(
                new Device 
                {
                    Owner = "Test Owner", 
                    Weight = 10,
                    Height = 1,
                    Width = 1,
                    Depth = 1
                },
                new List<string> { 
                    "Name cannot be Null or Empty", 
                    "Description cannot be Null or Empty" 
                }),

            new TestCaseData(
                new Device
                {
                    Name = "Test Name",
                    Description = "Test Description",
                    Owner = "Test Owner",
                    Weight = 10,
                },
                new List<string> {
                    "Device dimensions(Height, Width, Depth) cannot be 0"
                })
        };
    }
}