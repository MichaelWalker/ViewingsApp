﻿using System;
using FluentAssertions;
using NUnit.Framework;
using ViewingsApp.Models.Database;

namespace ViewingsApp.Tests
{
    public class AgentTests
    {
        [Test]
        public void IsFreeForViewingsDuringWorkingHours()
        {
            // arrange
            var agent = new Agent { StartTime = 9, EndTime = 17};
            var viewingStartTime = new DateTime(2020, 7, 22, 9, 0, 0);
            var viewingEndTime = new DateTime(2020, 7, 22, 10, 0, 0);
            
            // act
            var isFree = agent.IsFreeForViewing(viewingStartTime, viewingEndTime);
            
            // assert
            isFree.Should().BeTrue();
        }
        
        [Test]
        public void IsFreeForViewingsEndingAtTheEndOfTheDay()
        {
            // arrange
            var agent = new Agent { StartTime = 9, EndTime = 17};
            var viewingStartTime = new DateTime(2020, 7, 22, 16, 0, 0);
            var viewingEndTime = new DateTime(2020, 7, 22, 17, 0, 0);
            
            // act
            var isFree = agent.IsFreeForViewing(viewingStartTime, viewingEndTime);
            
            // assert
            isFree.Should().BeTrue();
        }
        
        [Test]
        public void IsNotFreeForViewingsBeforeWorkingHours()
        {
            // arrange
            var agent = new Agent { StartTime = 9, EndTime = 17};
            var viewingStartTime = new DateTime(2020, 7, 22, 8, 30, 0);
            var viewingEndTime = new DateTime(2020, 7, 22, 9, 30, 0);
            
            // act
            var isFree = agent.IsFreeForViewing(viewingStartTime, viewingEndTime);
            
            // assert
            isFree.Should().BeFalse();
        }
        
        [Test]
        public void IsNotFreeForViewingsAfterWorkingHours()
        {
            // arrange
            var agent = new Agent { StartTime = 9, EndTime = 17};
            var viewingStartTime = new DateTime(2020, 7, 22, 16, 30, 0);
            var viewingEndTime = new DateTime(2020, 7, 22, 17, 30, 0);
            
            // act
            var isFree = agent.IsFreeForViewing(viewingStartTime, viewingEndTime);
            
            // assert
            isFree.Should().BeFalse();
        }
    }
}