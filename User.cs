using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlowMate
{
    internal class User
    {
        // Properties for User class
        public int Id { get; set; } // Optional, if you use UserID as a primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor
        public User(string firstName, string lastName, string contactNumber, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Username = username;
            Password = password;
        }

    }
}
