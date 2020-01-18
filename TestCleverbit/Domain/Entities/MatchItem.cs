using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCleverbit.Domain.Entities
{
    public class MatchItem
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public string email { get; set; }
        public int Number { get; set; }
    }
}
