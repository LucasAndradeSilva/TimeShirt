using System;
using TS_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Data
{
    public class dtLogin
    {

        public static string RetorneMessage = "";

        //=================
        //=== TRY LOGIN ===
        //=================
        public static mdDadosUserLogado Logar(mdLogin Login)
        {
            try
            {
                if (!string.IsNullOrEmpty(Login.Usuario1))
                {
                    var mdLogin = dtDataBase.GetLogin(Login.Usuario1);
                    if (mdLogin != null)
                    {
                        if (Login.Senha1 == mdLogin.Senha1)
                        {
                            //Pega todos os dados desse usuario a joga em uma Class                            
                            RetorneMessage = "Logado com sucesso!";
                            return GetAllData(mdLogin.IdUser1); ; //Logado com sucesso!
                        }
                        else
                        {
                            RetorneMessage = "Senha incorreta!!";
                            return null; //Senha incorreta!
                        }
                    }
                    else
                    {
                        RetorneMessage = "Usuario não existe ou incorreto";
                        return null; //Usuario não existe ou incorreto
                    }                    
                }
                else
                {
                    RetorneMessage = "Todo os campos são obrigatórios!";
                    return null;
                }
            }            
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtLogin: "+ex.Message;
                return null;
            }
        }

        //=========================
        //=== GET ALL DATA USER ===
        //=========================
        private static mdDadosUserLogado GetAllData(int IdUser)
        {
            try
            {               
                return dtDataBase.GetDadosUserLogado(IdUser);
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtLogin GetAllData: " + ex.Message;
                return null;
            }
        }

        //============================
        //=== DESLOGAR DO SISTEMAS ===
        //============================
        //public static void Deslogar()
        //{           
        //    GetDadosLogado.mdDadosUserLogado.logadoContrato.Clear();
        //    GetDadosLogado.mdDadosUserLogado.logadoDadosLogin = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoEmpresa = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoEndereco = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoFuncionario = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoRelatorio = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoServico = null;
        //    GetDadosLogado.mdDadosUserLogado.logadoTipo = null;                     
        //}

    }
}
