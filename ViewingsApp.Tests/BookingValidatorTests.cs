using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Services;

namespace ViewingsApp.Tests
{
    public class Tests
    {
        private readonly List<Agent> _agents = new List<Agent>
        {
            new Agent
            {
                Id = 1,
                Name = "Mike",
                ImageUrl = "/images/person_01.jpg",
                StartTime = 9,
                EndTime = 17,
                Bookings = new List<Booking>(),
            }
        };
        
        private readonly List<Property> _properties = new List<Property>
        {
            new Property
            {
                Id = 3,
                Name = "Flat 1",
                Postcode = "NW5 1TL",
                Bookings = new List<Booking>(),
                ImageUrl = "/images/house_01.jpg"
            }
        };

        private BookingRequest ValidRequest()
        {
            return new BookingRequest
            {
                AgentId  = 1,
                PropertyId = 3,
                Name = "Rebecca",
                EmailAddress = "rebecca@hotmail.com",
                StartsAt = DateTime.Now.AddHours(2),
                EndsAt = DateTime.Now.AddHours(3),
                PhoneNumber = "0300 547 873"
            };
        }

        [Test]
        public void ValidBookingPassesValidation()
        {
            // Arrange
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(ValidRequest(), _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeTrue();
            bookingValidation.ErrorMessage.Should().BeEmpty();
        }

        [Test]
        public void ShouldFailIfNameIsMissing()
        {
            // Arrange
            var bookingRequest = ValidRequest();
            bookingRequest.Name = null;
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("You must provide a name");
        }
        
        [Test]
        public void ShouldFailIfEmailIsMissing()
        {
            // Arrange
            var bookingRequest = ValidRequest();
            bookingRequest.EmailAddress = null;
            var bookingValidator = new BookingValidator();

            // Act
            var bookingValidation = bookingValidator.ValidateBooking(bookingRequest, _agents, _properties);

            // Assert
            bookingValidation.IsValid.Should().BeFalse();
            bookingValidation.ErrorMessage.Should().Be("You must provide an email address");
        }
    }
}