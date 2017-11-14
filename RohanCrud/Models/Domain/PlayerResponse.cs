using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RohanCrud.Models.Domain
{
    public class PlayerResponse
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int TeamId { set; get; }
        public string Name { set; get; }
        public double BattingAverage { set; get; }
        public double OPS { set; get; }
    }
}