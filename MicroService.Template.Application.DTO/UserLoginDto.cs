﻿using System.ComponentModel.DataAnnotations;

namespace MicroService.Template.Application.DTO
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
