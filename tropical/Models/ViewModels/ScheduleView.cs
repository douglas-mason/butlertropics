using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tropical.Models.ViewModels
{
    public class ScheduleView
    {
        public int Id { get; set; }
        public string Dates { get; set; }
        public string Tournament { get; set; }
        public string Location { get; set; }
    }
}