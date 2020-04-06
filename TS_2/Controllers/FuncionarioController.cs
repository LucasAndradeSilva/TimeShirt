using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TS_2.Data;
using TS_2.Models;
using TS_2.Models.Join;

namespace TS_2.Controllers
{
    public class FuncionarioController : Controller
    {

        //================================
        //=== EXECUTA A PAGINA INICIAL ===
        //===============================
        public IActionResult Home()
        {
            return View();
        }
        
        //==============================
        //=== EXECUTA A VIEW SERVIÇO ===
        //==============================
        public IActionResult Servicos()
        {            
            List<mdJoinGetServico> ListServicos = dtServico.GetAllServicos(GetDadosLogado.mdDadosUserLogado.logadoFuncionario.IdFunc1);
            if (ListServicos != null)
            {
                return View(ListServicos);
            }
            else
            {                
                ErrorViewModel.logHelper = -1;
                return RedirectToAction("Home", "Home");
            }            
        }

        //=========================
        //=== EXECUTA A INICIAL ===
        //=========================
        public IActionResult Registro_de_Horas()
        {
            return View();
        }

        //=======================================
        //=== EXECUTA A VIEW DETALHES SERVICO ===
        //=======================================
        //public IActionResult DetalhesServicos(int IdServico)
        //{
        //   // List<mdJoinGetServico> ListServicos = dtServico.GetAllServicos(GetDadosLogado.mdDadosUserLogado.logadoFuncionario.IdFunc1);
        //    if (ListServicos != null)
        //    {
        //        return View(ListServicos);
        //    }
        //    else
        //    {
        //        ErrorViewModel.logHelper = -1;
        //        return RedirectToAction("Home", "Home");
        //    }
        //}

        //============================
        //=== CASO OCORRA UMA ERRO ===
        //============================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
