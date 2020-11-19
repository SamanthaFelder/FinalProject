using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public DateTime SignUpTime { get; set; }

        public Member()
        {

        }

        public Member(int id, string name, string username, string password, string email, int type, DateTime signUpTime)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            Type = type;
            SignUpTime = signUpTime;
        }
    }
}
