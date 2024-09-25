using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez06_Task_edicola.Models.DAL
{
    internal interface IDaoLettura <T>
    {
        List<T> GetAll();
        T GetById (int id);
    }
}
