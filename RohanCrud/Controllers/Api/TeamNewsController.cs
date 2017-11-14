using RohanCrud.Models.Domain;
using RohanCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RohanCrud.Controllers.Api
{
    [RoutePrefix("api/teamnews")]
    public class TeamNewsController : ApiController
    {
        ITeamNewsService _teamNewsService;

        public TeamNewsController(ITeamNewsService teamNewsService)
        {
            _teamNewsService = teamNewsService;
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllNews()
        {
            try
            {
                IEnumerable<TeamNews> teamNews = _teamNewsService.GetAllNews();
                return Request.CreateResponse(HttpStatusCode.OK, teamNews);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                IEnumerable<TeamNews> teamNews = _teamNewsService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, teamNews);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}