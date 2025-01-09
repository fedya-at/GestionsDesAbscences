using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AbsenceSummaryDto
    {
        public int CodeClasse { get; set; }
        public string NomClasse { get; set; }
        public int TotalAbsences { get; set; }
    }

}
