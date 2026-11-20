using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlowMate
{
    internal class Feedback
    {
        public string Name { get; set; }          // Name of the person giving feedback
        public string ContactNumber { get; set; } // Contact number (optional)
        public string Email { get; set; }         // Email address
        public string Comment { get; set; }       // Actual feedback or message

        // Constructor
        public Feedback(string name, string contact, string email, string comment)
        {
            Name = name;
            ContactNumber = contact;
            Email = email;
            Comment = comment;
        }
    }
}
