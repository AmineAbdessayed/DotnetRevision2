using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public  class Sinistre
    {
        [Key]
        public int SinistreId { get; set; }
        public DateTime Datedeclaration { get; set; }
        public string Lieu { get; set; }
        public string Description { get; set; }

        public virtual Assurance assurance { get; set; }
        public virtual IList<Expertise> Expertises { get; set; }

        public int AssuranceFk { get; set; }

    }
}
