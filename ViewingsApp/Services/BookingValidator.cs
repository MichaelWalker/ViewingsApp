﻿using System.Collections.Generic;
using System.Linq;
using ViewingsApp.Models.Database;
using ViewingsApp.Models.Request;
using ViewingsApp.Models.ViewModel;

namespace ViewingsApp.Services
{
    public interface IBookingValidator
    {
        BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties);
    }
    
    public class BookingValidator : IBookingValidator
    {
        public BookingValidation ValidateBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents, IEnumerable<Property> allProperties)
        {
            
            if (string.IsNullOrEmpty(bookingRequest.Name))
            {
                return BookingValidation.InValid("You must provide a name");
            }

            if (string.IsNullOrEmpty(bookingRequest.EmailAddress))
            {
                return BookingValidation.InValid("You must provide an email address");
            }

            var agent = FindAgentForBooking(bookingRequest, allAgents);
            if (agent == null)
            {
                return BookingValidation.InValid("Sorry - we couldn't find a matching agent.");
            }

            var property = FindPropertyForBooking(bookingRequest, allProperties);
            if (property == null)
            {
                return BookingValidation.InValid("Sorry - we couldn't find a matching property.");
            }
            
            return BookingValidation.Valid();
        }

        private Agent FindAgentForBooking(BookingRequest bookingRequest, IEnumerable<Agent> allAgents)
        {
            return allAgents.FirstOrDefault(agent => agent.Id == bookingRequest.AgentId);
        }

        private Property FindPropertyForBooking(BookingRequest bookingRequest, IEnumerable<Property> allProperties)
        {
            return allProperties.FirstOrDefault(property => property.Id == bookingRequest.PropertyId);
        }
    }
}