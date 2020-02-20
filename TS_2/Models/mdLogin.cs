using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TS_2.Models
{
    public class mdLogin
    {
        string Usuario;
        string Senha;
        int IdUser;
        
        public string Usuario1 { get => Usuario; set => Usuario = value; }        
        public string Senha1 { get => Senha; set => Senha = value; }
        public int IdUser1 { get => IdUser; set => IdUser = value; }
    }
}
