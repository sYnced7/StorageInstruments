﻿using StorageInstruments.Model;

namespace StorageInstruments.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual UserType UserType { get; set; }
        public bool Logged { get; set; }
    }
}
