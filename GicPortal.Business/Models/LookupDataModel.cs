using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GicPortal.Business.Models
{
    public class LookupDataModel
    {
        public List<TeamModel> Teams { get; set; }
        public List<SupervisorModel> Supervisor { get; set; }
    }

    public class TeamModel
    {
        public long TeamIntId { get; set; }
        public string Team { get; set; }
    }

    public class SupervisorModel
    {
        public long SupervisorIntId { get; set; }
        public string SupervisorName { get; set; }
    }
}