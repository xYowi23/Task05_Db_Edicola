using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez06_Task_edicola.Models
{
    internal class Rivista
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public string? CasaEditrice { get; set; }
        public string? CodUniRiv { get; set; }

        public override string ToString()
        {
            return $"[RIVISTA] {Id} {Titolo} {CasaEditrice} {CodUniRiv}";
        }

    }
}
