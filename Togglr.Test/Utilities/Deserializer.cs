using Togglr.Models;
using Togglr.Utilities;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace Togglr.Test.Utilities
{
    [TestFixture]
    public class DeserializerTests
    {
        // [SetUp]
        // public void Setup(){}
        Mock<IStreamReaderUtility> mockStreamReaderUtility;
        Mock<IDeserializer> mockDeserializer;
        
        [Test]
        public void JsonLoaderFromFile_LoadJsonFromFile_ReturnsCorrectType(string path = "./TogglData/Projects.json")
        {
            // arrange
            // var streamReaderUtility = new StreamReaderUtility();
            // var deserializer = new Deserializer();
            // var jsonLoaderFromFile = new JsonLoaderFromFile<Project>(streamReaderUtility, deserializer);
            
            mockStreamReaderUtility = new Mock<IStreamReaderUtility>();
            mockStreamReaderUtility.Setup(x => x.ReadStreamToEnd(path));
            mockDeserializer = new Mock<IDeserializer>();
            mockDeserializer.Setup(x => x.DeserializeList<Project>(path));

            var jsonLoaderFromFile = new JsonLoaderFromFile<TimeEntry>(mockStreamReaderUtility.Object, mockDeserializer.Object);

            // act
            var projects = jsonLoaderFromFile.LoadJsonFromFile(path);

            // assert
            Assert.AreEqual(typeof(List<Project>), projects.GetType());

            mockStreamReaderUtility.VerifyAll();
            mockDeserializer.VerifyAll();
        }
    }    
}
