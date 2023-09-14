using AutoMapper;
using InnoloftAPI.Controllers;
using InnoloftAPI.Core.Interface;
using InnoloftAPI.Core.Model;
using InnoloftAPI.Core.Resources;
using InnoloftAPI.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InnoloftAPI.Test
{
    [TestClass]
    public class EventTest
    {
        private Mock<IEventService> _eventServiceMock;
        private Mock<IMapper> _mapper;
        private EventController _eventController;

        [TestInitialize]
        public void Init()
        {
            _eventServiceMock = new Mock<IEventService>();
            _mapper = new Mock<IMapper>();
            _eventController = new EventController(_eventServiceMock.Object, _mapper.Object);
        }

        /// <summary>
        /// Model Validation For Event.
        /// Case: Send Sample event data and verify it.
        /// Send Event details only include EventTitle.
        /// Expected result: Event not saved because Event Start,EndDate is missing, ownerId also missing.
        /// </summary>
        [TestMethod]
        public async Task CheckEventModelValidation()
        {
            var eventData = new EventViewModel
            {
                EventTitle = "Test Event",
            };
            var result = await _eventController.AddEvents(eventData) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse((bool?)result.Value);
        }

        /// <summary>
        /// Create a Event, GetEvent details and verify event data.
        /// </summary>
        [TestMethod]
        public async Task AddEvent()
        {
            var eventData = new EventViewModel
            {
                EventTitle = "Test Event",
                StartDate = DateTime.UtcNow.Date.AddDays(3),
                EndDate = DateTime.UtcNow.Date.AddDays(7),
                EventDescription = "Get Together Event.",
                OwnerId = 1,
                Timezone = "Mountain Standard Time"
            };

            var result = await _eventController.AddEvents(eventData) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsTrue((bool?)result.Value, message: "Error while Adding Event.");

            ///Get Event details and Verify data.
            var eventResult = await _eventController.GetEventById(5) as OkObjectResult;
            EventViewModel eventDetail = (EventViewModel)eventResult.Value;
            Assert.IsNotNull(eventDetail, "Evnt details not found.");

            Assert.AreEqual(expected: eventData.StartDate, eventDetail.StartDate, "Event StartDate not matched.");
            Assert.AreEqual(expected: eventData.EndDate, eventDetail.EndDate, "Event EndDate not matched.");
            Assert.AreEqual(expected: eventData.EventTitle, eventDetail.EventTitle, "Event title not matched.");
            Assert.AreEqual(expected: eventData.Timezone, eventDetail.Timezone, "Event timezone not matched");
        }

        /// <summary>
        /// Create Event, Get Event details, verify event data.
        /// Update Event and Verify data.
        /// </summary>
        [TestMethod]
        public async Task UpdateEvent()
        {
            var eventData = new EventViewModel
            {
                EventTitle = "Test Event",
                StartDate = DateTime.UtcNow.Date.AddDays(3),
                EndDate = DateTime.UtcNow.Date.AddDays(7),
                EventDescription = "Get Together Event.",
                OwnerId = 1,
                Timezone = "Mountain Standard Time"
            };

            var result = await _eventController.AddEvents(eventData) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsTrue((bool?)result.Value, message: "Error while Adding Event.");

            ///Get Event details and Verify data.
            var eventResult = await _eventController.GetEventById(5) as OkObjectResult;
            EventViewModel eventDetail = (EventViewModel)eventResult.Value;
            Assert.IsNotNull(eventDetail, "Evnt details not found.");

            Assert.AreEqual(expected: eventData.StartDate, eventDetail.StartDate, "Event StartDate not matched.");
            Assert.AreEqual(expected: eventData.EndDate, eventDetail.EndDate, "Event EndDate not matched.");
            Assert.AreEqual(expected: eventData.EventTitle, eventDetail.EventTitle, "Event title not matched.");
            Assert.AreEqual(expected: eventData.Timezone, eventDetail.Timezone, "Event timezone not matched");


            ///Update Event details.
            eventDetail.StartDate = eventDetail.StartDate.AddDays(4).AddHours(2);

            var updatedEventResult = await _eventController.EditEvents(eventDetail) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsTrue((bool?)result.Value, message: "Error while Updating Event.");
        }

    }
}