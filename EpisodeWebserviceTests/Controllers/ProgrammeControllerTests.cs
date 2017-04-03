using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpisodeWebservice.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpisodeWebservice.DTO.ViewModels;
using System.Web.Script.Serialization;
using System.Net.Http;

using Moq;
using System.Web.Http.Hosting;
using System.Web.Http;

namespace EpisodeWebservice.Controllers.Tests
{

    [TestClass()]
    public class ProgrammeControllerTests
    {
        public ProgrammeController controller;
        public ProgrammeControllerTests()
        {
            var mockIShowManager = new Mock<BL.IShowManager.iShowManager>();
            controller = new ProgrammeController(mockIShowManager.Object);
            controller.Request = new HttpRequestMessage
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };
        }
        [TestMethod()]
        public void GetShowsWithDrmTest_ShouldReturn_StatusCodeOK_ForValidJson()
        {
            //Arrange
            var oRootObject = MockPayLoad();
            //Act
            var result = controller.GetShowsWithDrm(oRootObject);
            //Assert
            Assert.IsTrue(result.StatusCode.ToString().Equals("OK"));
        }
        [TestMethod()]
        public void GetShowsWithDrmTest_ShouldThrowException_ForInvalidJson()
        {
            try
            {
                
                //Act
                var result = controller.GetShowsWithDrm(null);
                //Assert
                Assert.Fail();
            }
            catch (NullReferenceException ex)
            {
                Assert.IsTrue(true);
            }
        }

        private RootObject MockPayLoad()
        {
            var json = @"{
           ""payload"": [
        {
            ""country"": ""UK"",
            ""description"": ""desc"",
            ""drm"": true,
            ""episodeCount"": 3,
            ""genre"": ""Reality"",
            ""image"": {
                ""showImage"": ""http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg""
            },
            ""language"": ""English"",
            ""nextEpisode"": null,
            ""primaryColour"": ""#ff7800"",
            ""seasons"": [
                {
                    ""slug"": ""show/16kidsandcounting/season/1""
                }
            ],
            ""slug"": ""show/16kidsandcounting"",
            ""title"": ""16 Kids and Counting"",
            ""tvChannel"": ""GEM""
        }
        
    ],
    ""skip"": 0,
    ""take"": 10,
    ""totalRecords"": 75
}";
            var oJS = new JavaScriptSerializer();
            RootObject oRootObject = new RootObject();
            oRootObject = oJS.Deserialize<RootObject>(json);
            return oRootObject;
        }



    }
}