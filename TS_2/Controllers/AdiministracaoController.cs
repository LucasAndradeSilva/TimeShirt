using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS_2.Data;
using TS_2.Models;
using TS_2.Models.Join;

namespace TS_2.Controllers
{
    public class AdiministracaoController : Controller
    {

        public static string Name = "";
        public static int IdFunc = 0;

        //======================
        //=== EXECUTA A VIEW ===
        //======================
        public IActionResult HomeAdm()
        {            
            return View();
        }

        //=============================
        //=== CHAMA A VIEW CADASTRO ===
        //=============================
        public IActionResult Cadastro()
        {
            return View();
        }

        //============================================
        //=== CHAMA A VIEW CADASTRO DO FUNCIONARIO ===
        //=============================================
        public IActionResult CadastroFuncionario()
        {
            return View();
        }

        //===================================================
        //=== EVENTO POST DA VIEW CADASTRO DO FUNCIONARIO ===
        //===================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroFuncionario(mdJoinCadFuncionario collection)
        {
            try
            {                
                string Retorno = dtCadastro.SetCadastroFuncionario(collection);
                if (Retorno == "True")
                {
                    ViewBag.Sucess = "Funcionário Cadastrado com Sucesso!";
                    return View();
                }
                else
                {
                    ViewBag.MessageError = "Erro Desconhecido, volte mais tarde.";
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

        //========================================
        //=== CHAMA A VIEW CADASTRO DA EMPRESA ===
        //========================================
        public IActionResult CadastroEmpresa()
        {
            return View();
        }

        //===============================================
        //=== EVENTO POST DA VIEW CADASTRO DA EMPRESA ===
        //===============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroEmpresa(mdJoinCadEmpresa collection)
        {
            try
            {
                string Retorno = dtCadastro.SetCadastroEmpresa(collection);
                if (Retorno == "True")
                {
                    ViewBag.Sucess = "Empresa Cadastrada com Sucesso!";
                    return View();
                }
                else
                {
                    ViewBag.MessageError = "Erro Desconhecido, volte mais tarde.";
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

        //=====================================
        //=== LISTA AS EMPRESAS CADASTRADAS ===
        //=====================================
        public IActionResult ListEmpresas()
        {
            IEnumerable<mdEmpresa> ListEmpresas = dtDataBase.GetAllEmpresas();
            if (ListEmpresas  != null)
            {
                return View(ListEmpresas);
            }
            else
            {
                return null;
            }            
        }

        //===========================
        //=== DETALHES DA EMPERSA ===
        //===========================
        public IActionResult DetalhesEmpresa(int idEmp)
        {
            ViewBag.DadosEmpresa = dtDataBase.GetAllDataEmp(idEmp);
            mdEndereco Endereco = dtDataBase.GetAllDataEmpEndereco(idEmp);
            string End = Endereco.Rua1 + "  Nº " + Endereco.Numero1 + " - " + Endereco.Bairro1 + " - " + Endereco.Estado1 + " - " + Endereco.Pais1 + " | CEP: " + Endereco.CEP1;
            ViewBag.DadosEndereco = End;
            ViewBag.IdEmp = idEmp;
            return View(dtDataBase.GetAllDataEmpListContrato(idEmp));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetalhesEmpresa(IFormCollection frm)
        {
            mdJoinDadosContrato dadosContrato = new mdJoinDadosContrato();
            dadosContrato.DataContrato1 = frm["txtData"];
            dadosContrato.Descricao1 = frm["txtDesc"];
            dadosContrato.Numero1 = frm["txtNumContrato"];
            dadosContrato.EmailFunc = frm["txtEmail"];
            dadosContrato.IdEmpresa = Convert.ToInt32(frm["txtId"]);
            return View();
        }


        //=======================
        //=== DELETAR EMPERSA ===
        //=======================
        public IActionResult DeletarEmpresa(int IdEmp)
        {
            if (dtDataBase.DeletarEmpresa(IdEmp))
            {
                return RedirectToAction("ListEmpresas", "Adiministracao");
            }
            else
            {
                return Cadastro();
            }            
        }
    }
}