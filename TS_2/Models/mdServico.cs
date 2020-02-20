using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdServico
    {
        int IdServico;
        string StatusServico;
        int Id_Emp;
        int Id_Contrato;
        int Id_Func;

        public int IdServico1 { get => IdServico; set => IdServico = value; }
        public string StatusServico1 { get => StatusServico; set => StatusServico = value; }
        public int Id_Emp1 { get => Id_Emp; set => Id_Emp = value; }
        public int Id_Contrato1 { get => Id_Contrato; set => Id_Contrato = value; }
        public int Id_Func1 { get => Id_Func; set => Id_Func = value; }
    }
}
