using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models.Join
{
    public class mdJoinGetServico
    {
        //Servico
        int IdServico;
        string StatusServico;
        int Id_Emp;
        int Id_Contrato;
        int Id_Func;

        //Empresa
        int IdEmpresa;
        string NomeEmpresa;
        string CNPJ;
        int Id_End;

        //Contrato
        int IdContrato;
        long Numero;
        string Descricao;
        string DataContrato;
        int Id_EmpContrato;

        //Servico
        public int IdServico1 { get => IdServico; set => IdServico = value; }
        public string StatusServico1 { get => StatusServico; set => StatusServico = value; }
        public int Id_Emp1 { get => Id_Emp; set => Id_Emp = value; }
        public int Id_Contrato1 { get => Id_Contrato; set => Id_Contrato = value; }
        public int Id_Func1 { get => Id_Func; set => Id_Func = value; }

        //Empresa
        public int IdEmpresa1 { get => IdEmpresa; set => IdEmpresa = value; }
        public string NomeEmpresa1 { get => NomeEmpresa; set => NomeEmpresa = value; }
        public string CNPJ1 { get => CNPJ; set => CNPJ = value; }
        public int Id_End1 { get => Id_End; set => Id_End = value; }

        //Contrato
        public int IdContrato1 { get => IdContrato; set => IdContrato = value; }
        public long Numero1 { get => Numero; set => Numero = value; }
        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public string DataContrato1 { get => DataContrato; set => DataContrato = value; }
        public int Id_EmpContrato1 { get => Id_EmpContrato; set => Id_EmpContrato = value; }
        
    }
}
