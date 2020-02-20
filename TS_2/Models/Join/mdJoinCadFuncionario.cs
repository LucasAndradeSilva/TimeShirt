using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models.Join
{
    public class mdJoinCadFuncionario
    {
        //========================
        //=== DADOS DE USUARIO ===
        //========================
        string Usuario;
        string Senha;
        //=========================
        //=== DADOS FUNCIONARIO ===
        //=========================
        string NomeFunc;
        int RT;
        string CPF;
        string RG;
        string TEL;
        string Email;
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

        //Usuario
        [Display(Name = "USUARIO")]        
        public string Usuario1 { get => Usuario; set => Usuario = value; }

        [Display(Name = "SENHA")]        
        [DataType(dataType: DataType.Password)]
        public string Senha1 { get => Senha; set => Senha = value; }        

        //Funcionario        
        [Display(Name = "Nome Completo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string NomeFunc1 { get => NomeFunc; set => NomeFunc = value; }

        [Display(Name = "Registro trabalhador (RT)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public int RT1 { get => RT; set => RT = value; }

        [Display(Name = "CPF")]        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string CPF1 { get => CPF; set => CPF = value; }

        [Display(Name = "RG")]        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string RG1 { get => RG; set => RG = value; }

        [Display(Name = "Celular")]        
        [DataType(dataType: DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string TEL1 { get => TEL; set => TEL = value; }

        [Display(Name = "Email")]
        [DataType(dataType: DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo não pode estar vazio!")]
        public string Email1 { get => Email; set => Email = value; }
     
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
        
    }
}
