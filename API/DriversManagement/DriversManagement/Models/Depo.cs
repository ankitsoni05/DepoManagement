using System.Collections.Generic;

namespace DriversManagement.Models
{
    public class Depo
    {
        public int DepoId { get; set; }
        public string DepoName { get; set; }
        public int DivisionId { get; set; }
        public Division division { get; set; }
    }
}
