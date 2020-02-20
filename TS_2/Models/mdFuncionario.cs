using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TS_2.Models
{
    public class mdFuncionario
    {
        int IdFunc;
        string NomeFunc;
        int RT;
        string CPF;
        string RG;
        string TEL;
        string Email;
        int Id_User;
        int Id_End;

        public int IdFunc1 { get => IdFunc; set => IdFunc = value; }

        [Display(Name = "Nome Completo")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Este campo não pode estar vazio!")]        
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

        public int Id_User1 { get => Id_User; set => Id_User = value; }
        public int Id_End1 { get => Id_End; set => Id_End = value; }
    }
}
