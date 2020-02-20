using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models.Join
{
    public class mdJoinCadEmpresa
    {
        //=====================
        //=== DADOS EMPRESA ===
        //=====================        
        string NomeEmpresa;
        string CNPJ;        
        //======================
        //=== DADOS ENDEREÇO ===
        //======================        
        string Cep;
        string Rua;
        string Numero;
        string Bairro;
        string Logradouro;
        string Estado;
        string Pais;

        //=====================
        //=== DADOS SERVIÇO ===
        //=====================        
        string StatusServico;
        int Id_Func;        

        //======================
        //=== DADOS CONTRATO ===
        //======================        
        long NumeroContrato;
        string Descricao;
        string DataContrato;

        //=========================
        //=== DADOS FUNCIONARIO ===
        //=========================
        string EmailFunc;

        //Empresa     
        [Display(Name = "NOME EMPRESA")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string NomeEmpresa1 { get => NomeEmpresa; set => NomeEmpresa = value; }

        [Display(Name = "CNPJ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string CNPJ1 { get => CNPJ; set => CNPJ = value; }        

        //Endereço
        [Display(Name = "CEP")]
        [DataType(dataType: DataType.PostalCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Cep1 { get => Cep; set => Cep = value; }

        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Rua1 { get => Rua; set => Rua = value; }

        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Numero1 { get => Numero; set => Numero = value; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Bairro1 { get => Bairro; set => Bairro = value; }

        [Display(Name = "Logradouro")]
        public string Logradouro1 { get => Logradouro; set => Logradouro = value; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Estado1 { get => Estado; set => Estado = value; }

        [Display(Name = "Pais")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Pais1 { get => Pais; set => Pais = value; }

        //Serviço        
        public string StatusServico1 { get => StatusServico; set => StatusServico = value; }
        public int Id_Func1 { get => Id_Func; set => Id_Func = value; }

        //Contrato
        [Display(Name = "Número de Contrato")]        
        public long NumeroContrato1 { get => NumeroContrato; set => NumeroContrato = value; }

        [Display(Name = "Descrição de Serviço a prestar")]        
        public string Descricao1 { get => Descricao; set => Descricao = value; }

        [Display(Name = "Data Contrato")]        
        [DataType(dataType: DataType.Date)]
        public string DataContrato1 { get => DataContrato; set => DataContrato = value; }

        //Funcionario
        [Display(Name = "Email do Funcionario")]
        public string EmailFunc1 { get => EmailFunc; set => EmailFunc = value; }

    }

}
