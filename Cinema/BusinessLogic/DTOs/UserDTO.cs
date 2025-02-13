﻿namespace BusinessLogic.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
