using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS_2.Data;
using TS_2.Models;

namespace TS_2.Controllers
{
    public class HomeController : Controller
    {
        //======================
        //=== EXECUTA A VIEW ===
        //======================
        public IActionResult Index()
        {            
            return View();
        }

        //=====================
        //=== POST DO LOGIN ===
        //=====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(mdLogin Colletion)
        {
            try
            {
                mdLogin mdLogin = new mdLogin();                
                mdLogin.Usuario1 = Colletion.Usuario1;
                mdLogin.Senha1 = Colletion.Senha1;
                mdDadosUserLogado mdDataUser = dtLogin.Logar(mdLogin);
                if (dtLogin.RetorneMessage == "Logado com sucesso!")
                {
                    //Passar algum parametro para emitir a notificação de logado e verificar o tipo do usuario                    
                    string TipoLog = mdDataUser.logadoTipo.Cargo1;
                    if (TipoLog == "Adm")
                    {
                        HttpContext.Session.Set(mdDataUser);//Loga os dados do Usuario nos Cookis                        
                        return RedirectToAction("HomeAdm", "Adiministracao");
                    }
                    else if (TipoLog == "Func")
                    {
                        HttpContext.Session.Set(mdDataUser);
                        return RedirectToAction("Home", "Funcionario");
                    }
                    else if (TipoLog == "Geral")
                    {
                        return RedirectToAction("Home", "Geral");
                    }
                    else
                    {
                        ViewBag.MessageError = "Erro Interno, volte mais tarde.";
                        ErrorViewModel.logHelper = -1;
                        return View();
                    }
                }
                else
                {         
                    ViewBag.MessageError = dtLogin.RetorneMessage;
                    ErrorViewModel.logHelper = -1;
                    return View();
                }                
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = "Erro Desconhecido, volte mais tarde.";
                ErrorViewModel.logHelper = -1;
                ErrorViewModel errorView = new ErrorViewModel();
                errorView.RequestId = ex.Message;
                return View();
            }            
        }

        //==========================
        //=== VALIDAÇÃO DE ERROS ===
        //==========================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
