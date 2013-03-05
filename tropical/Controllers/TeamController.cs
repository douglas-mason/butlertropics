using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Web;
using System.Web.Mvc;
using tropical.Models.ViewModels;

namespace tropical.Controllers
{
    public class TeamController : Controller
    {
        //
        // GET: /Team/

        public ActionResult Index()
        {
            var players = GetTeamPlayers();

            return View(players);
        }

        private IEnumerable<PlayerView> GetTeamPlayers()
        {
            var xmlDoc = new XmlDocument();
            var playerList = new List<PlayerView>();
            var path = Server.MapPath("/Xml/Team.xml");
            xmlDoc.Load(path);
            var playerDocItems = xmlDoc.GetElementsByTagName("Player");
            foreach (XmlNode item in playerDocItems)
            {
                var player = new PlayerView();
                player.FirstName = item["FirstName"] != null ? item["FirstName"].InnerText : "";
                player.LastName = item["LastName"] != null ? item["LastName"].InnerText : "";
                player.Grade = item["Grade"] != null ? item["Grade"].InnerText : "";
                player.Position = item["Position"] != null ? item["Position"].InnerText : "";
                player.Height = item["Height"] != null ? item["Height"].InnerText : "";
                player.Quote = item["Quote"] != null ? item["Quote"].InnerText : "";
                player.JerseyNumber = item["JerseyNumber"] != null ? Int32.Parse(item["JerseyNumber"].InnerText) : 0;
                playerList.Add(player);
            }
            return playerList;
        }
    }
}
