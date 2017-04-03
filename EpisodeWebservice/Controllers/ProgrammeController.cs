using EpisodeWebservice.BL;
using EpisodeWebservice.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static EpisodeWebservice.BL.IShowManager;
using EpisodeWebservice.Exception;
namespace EpisodeWebservice.Controllers
{
    
    public class ProgrammeController : ApiController
    {
        public iShowManager _ShowManager;
        public ProgrammeController(iShowManager ShowManager)

        { _ShowManager = ShowManager; }

        /*This function accepts the posted payload for data manupulation*/
        [Route("api/shows")]
        [System.Web.Http.HttpPost]
        [GlobalExceptionHandler]
        public HttpResponseMessage GetShowsWithDrm(RootObject inputPayload)
        {
            iShowManager sh = new ShowManager();
            var shows = sh.GetShows(inputPayload);
            return Request.CreateResponse(HttpStatusCode.OK, shows); 
        }
    }
}