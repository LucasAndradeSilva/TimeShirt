using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdEmpresa
    {
        int IdEmpresa;
        string NomeEmpresa;
        string CNPJ;
        int Id_End;

        public int IdEmpresa1 { get => IdEmpresa; set => IdEmpresa = value; }
        public string NomeEmpresa1 { get => NomeEmpresa; set => NomeEmpresa = value; }
        public string CNPJ1 { get => CNPJ; set => CNPJ = value; }
        public int Id_End1 { get => Id_End; set => Id_End = value; }
    }
}
