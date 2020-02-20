using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS_2.Models.Join;

namespace TS_2.Data
{
    public class dtServico
    {

        //====================
        //=== GET SERVICOS ===
        //====================
        public static List<mdJoinGetServico> GetAllServicos(int IdFunc)
        {
            try
            {
                return dtDataBase.GetAllServicos(IdFunc);
            }
            catch (Exception)
            {
                return null;               
            }

        }


    }
}
