using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdContrato
    {
        int IdContrato;
        string Numero;
        string Descricao;
        string DataContrato;
        int Id_Emp;

        public int IdContrato1 { get => IdContrato; set => IdContrato = value; }
        public string Numero1 { get => Numero; set => Numero = value; }
        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public int Id_Emp1 { get => Id_Emp; set => Id_Emp = value; }
        public string DataContrato1 { get => DataContrato; set => DataContrato = value; }
    }
}
