namespace AnimalHope.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class StatisticsViewModel
    {
        public int HomelessCount { get; set; }

        public int VetCount { get; set; }

        public int TempCount { get; set; }

        public int AdoptedCount { get; set; }
    }
}