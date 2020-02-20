using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TS_2.Models
{
    public class mdEndereco
    {
        int IdEndereco;
        string CEP;
        string Rua;
        string Numero;
        string Bairro;
        string Logradouro;
        string Estado;
        string Pais;

        public int IdEndereco1 { get => IdEndereco; set => IdEndereco = value; }
        public string Rua1 { get => Rua; set => Rua = value; }
        public string Numero1 { get => Numero; set => Numero = value; }
        public string Bairro1 { get => Bairro; set => Bairro = value; }
        public string Logradouro1 { get => Logradouro; set => Logradouro = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Pais1 { get => Pais; set => Pais = value; }
        public string CEP1 { get => CEP; set => CEP = value; }
    }
}
