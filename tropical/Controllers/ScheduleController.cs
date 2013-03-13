using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using tropical.Models.ViewModels;

namespace tropical.Controllers
{
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            var schedule = GetSchedule();
            return View(schedule);
        }

        public ActionResult EventDetail(int eventId)
        {
            var scheduledEvent = new ScheduleView();
            return View(scheduledEvent);
        }

        private IEnumerable<ScheduleView> GetSchedule()
        {
            var xmlDoc = new XmlDocument();
            var scheduleList = new List<ScheduleView>();
            var path = Server.MapPath("/Xml/Schedule.xml");
            xmlDoc.Load(path);
            var playerDocItems = xmlDoc.GetElementsByTagName("Event");
            foreach (XmlNode item in playerDocItems)
            {
                var scheduledEvent = new ScheduleView();
                scheduledEvent.Id = item["Id"] != null ? int.Parse(item["Id"].InnerText) : 0;
                scheduledEvent.Dates = item["Dates"] != null ? item["Dates"].InnerText : "";
                scheduledEvent.Tournament = item["Tournament"] != null ? item["Tournament"].InnerText : "";
                scheduledEvent.Location = item["Location"] != null ? item["Location"].InnerText : "";
                scheduleList.Add(scheduledEvent);
            }
            return scheduleList;
        }
    }
}
