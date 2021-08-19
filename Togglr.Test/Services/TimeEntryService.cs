// using System;
// using Moq;
// using NUnit.Framework;
// using Togglr.Models;
// using Togglr.Utilities;

// namespace Togglr.Services
// {
//     [TestFixture]
//     public class TimeEntryServiceTests
//     {
//         // IPostUtility<TimeEntry> _postUtility;
//         // IJsonLoaderFromWeb<TimeEntry> _jsonLoaderFromWeb;
//         // IDeserializer _deserializer;
//         [SetUp]
//         public void Setup(){}
//         // (IPostUtility<TimeEntry> postUtility, IJsonLoaderFromWeb<TimeEntry> jsonLoaderFromWeb, IDeserializer deserializer){
            
//             // _postUtility = new PostUtility<TimeEntry>();
//             // _jsonLoaderFromWeb = jsonLoaderFromWeb;
//             // _deserializer = deserializer;
//         // }
//         [Test]
//         public void TimeEntryService_CreateNewTimeEntry_ReturnsValidTimeEntry()
//         {
//             var postUtility = new Mock<IPostUtility<TimeEntry>>();
//             postUtility.SetupGet(p => p.PostAsync(It.IsAny<>()));
//             var jsonLoaderFromWeb = new Mock<IJsonLoaderFromWeb<TimeEntry>>();
//             var deserializer = new Mock<IDeserializer>();
//             var testBody = "{\"Created_With\": \"Snowball\", \"pid\": 157025838, \"tid\": 27896544, \"billable\": true, \"start\": \"2021/07/06T16:00:00\", \"stop\": \"2021/07/06T17:00:00\", \"description\": \"Slack user reporting\", \"tags\": [\"ALPINE\"], \"uid\": 5400208, \"wid\": 2500287}";

//             // arrange
//             var timeEntryService = new TimeEntryService(postUtility, jsonLoaderFromWeb, deserializer);

//             // act
//             var timeEntry = timeEntryService.CreateNewTimeEntry(testBody);

//             Console.WriteLine(timeEntry);

//             // assert
//             Assert.AreEqual("Slack user reporting", timeEntry.Description);
//         }
//     }
// }