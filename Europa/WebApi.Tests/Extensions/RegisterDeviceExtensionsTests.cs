using NUnit.Framework;
using System.Collections.Generic;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Tests.Extensions
{
    [TestFixture]
    public class RegisterDeviceExtensionsTests
    {
        [Test]
        public void DontReturnError_When_RegisterDeviceObjectIsValid()
        {
            // Arrange
            var registerDevice = new RegisterDevice
            {
                Name = "Test Name",
                Description = "Test Description",
                Owner = "Test Owner",
                Weight = 10
            };

            // Act
            var errors = registerDevice.Validate();

            // Assert
            Assert.IsEmpty(errors);
        }

        [TestCaseSource(nameof(RegisterDeviceData))]
        public void ReturnErrors_When_RegisterDeviceObjectIsValid(RegisterDevice registerDevice, IReadOnlyCollection<string> expectedErrors)
        {
            // Act
            var errors = registerDevice.Validate();

            // Assert
            Assert.That(errors, Is.EqualTo(expectedErrors));
        }

        static TestCaseData[] RegisterDeviceData =
        {
            new TestCaseData(
                new RegisterDevice 
                { 
                    Description = "Test Description", 
                    Owner = "Test Owner", 
                    Weight = 10 
                }, 
                new List<string> { 
                    "Name cannot be Null or Empty"
                }),
            new TestCaseData(
                new RegisterDevice 
                { 
                    Name = "Test Name", 
                    Owner = "Test Owner", 
                    Weight = 10 
                },
                new List<string> { 
                    "Description cannot be Null or Empty"
                }),
            new TestCaseData(
                new RegisterDevice 
                {
                    Owner = "Test Owner", 
                    Weight = 10 
                },
                new List<string> { 
                    "Name cannot be Null or Empty", 
                    "Description cannot be Null or Empty" 
                })
        };
    }
}