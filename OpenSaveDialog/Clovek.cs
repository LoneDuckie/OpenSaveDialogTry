using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenSaveDialog
{
    internal class Clovek
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }

        public Clovek(string firstName, string lastName, int id, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            Email = email;
        }
        
    }
}
