using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez06_Task_edicola.Models
{
    internal class Giocattolo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public int  EtaMin { get; set; }

        public string? CodUniGio {  get; set; }


        public override string ToString()
        {
            return $"[GIOCATOLO] {Id} {Nome} {EtaMin} {CodUniGio}";
        }
    }
}
