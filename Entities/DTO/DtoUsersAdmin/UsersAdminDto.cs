﻿using Core.Entitiess.Abstract;


namespace Entities.DTO
{
	public class UsersAdminDto : IDTO
    {
        public int Id { get; set; }
        public string NameSurName { get; set; }
        public string EPosta { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Roles { get; set; }
    }
}
