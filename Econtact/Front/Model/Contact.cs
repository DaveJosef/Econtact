using Econtact.Front.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.Front.Model
{
    class Contact
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        //public Gender Gender { get; set; }
        public string Gender { get; set; }
    }
}
