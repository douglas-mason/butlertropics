using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tropical.Models.ViewModels
{
    public class PlayerView
    {
        public int JerseyNumber { get; set; }  // Will also serve as jersey number which is unique
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Grade { get; set; }
        public string Height { get; set; }
        public string Quote { get; set; }
    }
}