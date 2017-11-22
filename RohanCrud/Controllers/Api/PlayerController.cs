using HtmlAgilityPack;
using RohanCrud.Models.Domain;
using RohanCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RohanCrud.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/Player")]
    public class PlayerController : ApiController
    {
        IPlayerService _playerService;
        
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService; 
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAllPlayers()
        {
            try
            {
                IEnumerable<PlayerResponse> players = _playerService.GetAllPlayers();
                return Request.CreateResponse(HttpStatusCode.OK, players);
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
                PlayerResponse player = _playerService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, player);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(Player model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                int id = _playerService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("{Id:int}"), HttpPut]
        public HttpResponseMessage Update(Player model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                _playerService.UpdateById(model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("{Id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _playerService.DeleteById(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("Teams"), HttpGet]
        public HttpResponseMessage GetTeams()
        {
            try
            {
                IEnumerable<Team> team = _playerService.GetTeams();
                return Request.CreateResponse(HttpStatusCode.OK, team);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("News"), HttpPost]
        public HttpResponseMessage GetMarinersNews(Team selectedTeam)
        {
            string teamName = ""; 
            if(selectedTeam != null)
            {
                teamName = selectedTeam.City + " " + selectedTeam.Name;
                teamName = teamName.Replace(" ", "-");
            }
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString("https://www.mlbtraderumors.com/"+ teamName));
            var root = html.DocumentNode;

            IEnumerable<HtmlAgilityPack.HtmlNode> myList = new List<HtmlAgilityPack.HtmlNode>(); 
            myList = ((root.Descendants()
                .Where(n => n.GetAttributeValue("class", "").Equals("site-inner"))
                .Single()
                .Descendants("h2")));

            List<string> newList = new List<string>(); 

            foreach(HtmlNode itm in myList)
            {
                newList.Add(itm.InnerHtml);
            }

            return Request.CreateResponse(HttpStatusCode.OK, newList);
        }

    }
}
