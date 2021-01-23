using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Language:EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<POCOLanguage> POCOLanguages { get; set; }


    }
    
}
