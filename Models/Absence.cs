using System;

namespace MilitaryWebsite.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public string ServicemanName { get; set; }
        public int ServicemanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
    }
}