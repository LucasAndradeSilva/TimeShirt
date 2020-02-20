using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdRelatorio
    {
        int IdRelatorio;
        string DataRelatorio;
        string HorasInicial;
        string HorasTermino;
        string Descricao;
        string AcompanhanteNome;
        string LocalAssinatura;
        int Id_Servico;

        public int IdRelatorio1 { get => IdRelatorio; set => IdRelatorio = value; }
        public string DataRelatorio1 { get => DataRelatorio; set => DataRelatorio = value; }
        public string HorasInicial1 { get => HorasInicial; set => HorasInicial = value; }
        public string HorasTermino1 { get => HorasTermino; set => HorasTermino = value; }
        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public string AcompanhanteNome1 { get => AcompanhanteNome; set => AcompanhanteNome = value; }
        public string LocalAssinatura1 { get => LocalAssinatura; set => LocalAssinatura = value; }
        public int Id_Servico1 { get => Id_Servico; set => Id_Servico = value; }
    }
}
