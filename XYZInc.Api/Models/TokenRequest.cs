﻿using System.ComponentModel.DataAnnotations;

namespace XYZInc.Api.Models
{
    public class TokenRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
