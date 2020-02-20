using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdDadosUserLogado
    {
        public List<mdContrato> logadoContrato = new List<mdContrato>();
        public mdEndereco logadoEndereco = new mdEndereco();
        public List<mdRelatorio> logadoRelatorio = new List<mdRelatorio>();
        public List<mdServico> logadoServico = new List<mdServico>();
        public mdUsuario logadoTipo = new mdUsuario();
        public mdLogin logadoDadosLogin = new mdLogin();
        public mdEmpresa logadoEmpresa = new mdEmpresa();
        public mdFuncionario logadoFuncionario = new mdFuncionario();
    }

    public static class GetDadosLogado
    {
        public static mdDadosUserLogado mdDadosUserLogado = new mdDadosUserLogado();
    }
}
