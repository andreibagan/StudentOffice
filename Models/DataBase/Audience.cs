using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    public class Audience
    {
        public int AudienceId { get; set; }
        public int AudienceNumber { get; set; }
        public string AudienceName { get; set; }

        public virtual ICollection<Couple> Couples { get; set; }
    }
}