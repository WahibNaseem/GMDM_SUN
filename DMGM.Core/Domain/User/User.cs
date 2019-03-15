using System;
using System.Collections.Generic;
using System.Text;

namespace DMGM.Core.Domain.User
{
   public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
