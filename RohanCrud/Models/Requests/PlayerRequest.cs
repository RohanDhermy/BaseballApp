using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RohanCrud.Models.Requests
{
    public class PlayerRequest
    {
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public int TeamId { set; get; }
        [Required]
        public double BattingAverage { set; get; }
        [Required]
        public double OPS { set; get; }
    }
}