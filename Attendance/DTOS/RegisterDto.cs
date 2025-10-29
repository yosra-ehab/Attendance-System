﻿using System.ComponentModel.DataAnnotations;

namespace Attendance.DTOS
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; } 
        [Required]
        public string Email { get; set; }    
        [Required]
        public string Password { get; set; }
        [Required]
        public string phoneNumber { get; set; }
    }
}
