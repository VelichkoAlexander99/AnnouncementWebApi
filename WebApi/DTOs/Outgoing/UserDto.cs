﻿namespace WebApi.DTOs.Outgoing
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
