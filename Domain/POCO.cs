using System;
using System.Collections.Generic;

namespace Domain
{
    public class POCO: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
            { 
                return FirstName + " " + LastName;
            }
        }
        public byte[] Password { get; set; }
        public byte[] Photo { get; set; }
        // o(Link to file system)
        public string CV { get; set; }
        // o Date of Birth
        public DateTime DateofBirth { get; set; }
        // o Married* (Boolean)
        public bool Married { get; set; }


        public Guid? SupervisorID { get; set; }
        public POCO Supervisor { get; set; }
        public IEnumerable<POCOLanguage> POCOLanguages { get; set; }

    }

}
