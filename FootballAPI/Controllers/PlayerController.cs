﻿using FootballAPI.DataLayer;
using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("api/Player")]
    public class PlayerController : ApiController
    {


        [Route("api/Player/{playerid}")]
        public Object GetPlayer(string playerid)
        {
            Player player = new Player(new PlayerInfo(playerid));
            PlayerService service = new PlayerService(player);
            try
            {
                service.GetInfo();
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("api/Player/SeasonStats/{playerid}")]
        public Object GetSeasonStats(string playerid)
        {
            Player player = new Player(new PlayerInfo(playerid));
            PlayerService service = new PlayerService(player);
            try
            {                         
                service.GetInfo();
                service.GetSeasonLog();
            }
            catch(Exception e)
            {             
                return e;
            }
            return player;
        }
        [Route("api/Player/GameStats/{playerid}/{gameid}")]
        public Object GetGame(string playerid,string gameid)
        {
            Player player = new Player(new PlayerInfo(playerid));
            PlayerService service = new PlayerService(player);
            try
            {
                service.GetInfo();
                service.GetGame(gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("api/Player/GameLogs/{playerid}")]
        public Object GetGameLogs(string playerid)
        {
            Player player = new Player(new PlayerInfo(playerid));
            PlayerService service = new PlayerService(player);
            try
            {
                service.GetInfo();
                service.GetGameLogs();
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("api/Player/AllLogs/{playerid}")]
        public Object GetPlayerAll(string playerid)
        {
            Player player = new Player(new PlayerInfo(playerid));
            PlayerService service = new PlayerService(player);
            try
            {
                service.Fetch();
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("api/Player/Test/{player}")]
        public Object GetTest(string player)
        {
            try
            {

                PlayerRequest request = new PlayerRequest(new Season("2018", false));
                PlayerService service = new PlayerService();
                service.player = request.GetPlayerGameStats(player);
                Effected effected = new Effected(service.PostGameLogs());
                return effected;
            }
            catch(Exception e)
            {
                return e;
            }
        }


    }
}
