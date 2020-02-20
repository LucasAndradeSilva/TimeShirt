using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS_2.Models.Join;

namespace TS_2.Data
{
    public class dtCadastro
    {
        //============================
        //=== CADASTRO FUNCIONARIO ===
        //============================
        public static string SetCadastroFuncionario(mdJoinCadFuncionario Colletion)
        {
            try
            {
                if (dtDataBase.SetCadFuncionario(Colletion)) return "True";
                else return "Erro ao realizar o Cadastro!";
            }
            catch (Exception ex)
            {
                return "False, "+ex.Message;
            }            
        }

        //========================
        //=== CADASTRO EMPRESA ===
        //========================
        public static string SetCadastroEmpresa(mdJoinCadEmpresa Colletion)
        {
            try
            {
                if (dtDataBase.SetCadEmpresa(Colletion)) return "True";
                else return "Erro ao realizar o Cadastro!";
            }
            catch (Exception ex)
            {
                return "False, " + ex.Message;
            }
        }

        //========================
        //=== CADASTRO SERVIÇO ===
        //========================
        public static string SetServico(mdJoinCadEmpresa Colletion)
        {
            try
            {
                //if (dtDataBase.SetCadEmpresa(Colletion)) return "True";
                //else return "Erro ao realizar o Cadastro!";
                return null;
            }
            catch (Exception ex)
            {
                return "False, " + ex.Message;
            }
        }

    }
}
