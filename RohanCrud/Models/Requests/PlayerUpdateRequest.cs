using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RohanCrud.Models.Requests
{
    public class PlayerUpdateRequest : PlayerRequest
    {
        [Required]
        public int Id { set; get; }
    }
}