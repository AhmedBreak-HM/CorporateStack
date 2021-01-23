using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class POCOLanguage: EntityBase
    {
        public Guid POCOIdFK { get; set; }
        public Guid LanguageIdFK { get; set; }

        [ForeignKey(nameof(POCOIdFK))]
        public POCO POCO { get; set; }
        [ForeignKey(nameof(LanguageIdFK))]
        public Language Language { get; set; }
    }
}
