using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TS_2.Models;
using TS_2.Models.Join;

namespace TS_2.Data
{
    public static class dtDataBase
    {
        private static MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=1234567;database=dbts");//Casa   
        
        //=======================
        //=== OPEN CONNECTION ===
        //=======================
        public static void OpenConection()
        {
            try
            {
                connection.Open();      
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtDataBase: "+ex.Message;
            }
        }

        //========================
        //=== CLOSE CONNECTION ===
        //========================
        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtDataBase: " + ex.Message;
            }
        }

        //================================
        //=== GET USUARIO AND PASSWORD ===
        //================================
        public static mdLogin GetLogin(string Usuario)
        {
            try
            {
                OpenConection();
                MySqlCommand cmd = new MySqlCommand("call sp_GetLogin(@User)", connection);
                cmd.Parameters.AddWithValue("@User", Usuario);

                MySqlDataReader rd = cmd.ExecuteReader();
                mdLogin mdLogin = new mdLogin();

                if(rd.Read())
                {
                    mdLogin.Usuario1 = rd[0].ToString();
                    mdLogin.Senha1 = rd[1].ToString();
                    mdLogin.IdUser1 = int.Parse(rd[2].ToString());
                }
                CloseConnection();
                return mdLogin;
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtDataBase getLogar: " + ex.Message;
                CloseConnection();
                return null;
            }
        }

        //=========================
        //=== GET ALL DATA USER ===
        //=========================
        public static mdDadosUserLogado GetDadosUserLogado(int IdUser)
        {
            try
            {
                OpenConection();
                MySqlCommand cmd = new MySqlCommand("call sp_GetDadosLogado(@IdUser)", connection);
                cmd.Parameters.AddWithValue("@IdUser", IdUser);

                MySqlDataReader rd = cmd.ExecuteReader();
                
                if (rd.Read())
                {
                    mdFuncionario mdFuncionario = new mdFuncionario();
                    mdFuncionario.IdFunc1 = int.Parse(rd[0].ToString());
                    mdFuncionario.NomeFunc1 = rd[1].ToString();
                    mdFuncionario.RT1 = int.Parse(rd[2].ToString());
                    mdFuncionario.CPF1 = rd[3].ToString();
                    mdFuncionario.RG1 = rd[4].ToString();
                    mdFuncionario.TEL1 = rd[5].ToString();
                    mdFuncionario.Email1 = rd[6].ToString();
                    mdFuncionario.Id_User1 = int.Parse(rd[7].ToString());

                    mdEndereco mdEndereco = new mdEndereco();
                    mdEndereco.IdEndereco1 = int.Parse(rd[9].ToString());
                    mdEndereco.CEP1 = rd[10].ToString();
                    mdEndereco.Rua1 = rd[11].ToString();
                    mdEndereco.Numero1 = rd[12].ToString();
                    mdEndereco.Bairro1 = rd[13].ToString();
                    mdEndereco.Logradouro1 = rd[14].ToString();
                    mdEndereco.Estado1 = rd[15].ToString();
                    mdEndereco.Pais1 = rd[16].ToString();

                    mdLogin mdLogin = new mdLogin();
                    mdLogin.Usuario1 = rd[18].ToString();
                    mdLogin.Senha1 = rd[19].ToString();
                    mdLogin.IdUser1 = int.Parse(rd[20].ToString());

                    mdUsuario mdUsuario = new mdUsuario();
                    mdUsuario.IdUsuario1 = int.Parse(rd[21].ToString());
                    mdUsuario.Cargo1 = rd[22].ToString();

                    GetDadosLogado.mdDadosUserLogado.logadoFuncionario = mdFuncionario;
                    GetDadosLogado.mdDadosUserLogado.logadoEndereco = mdEndereco;
                    GetDadosLogado.mdDadosUserLogado.logadoDadosLogin = mdLogin;
                    GetDadosLogado.mdDadosUserLogado.logadoTipo = mdUsuario;
                    
                }
                rd.Close();
                CloseConnection();
                return GetDadosLogado.mdDadosUserLogado;
            }
            catch (Exception ex)
            {
                ErrorViewModel error = new ErrorViewModel();
                error.RequestId = "Error at Class dtDataBase GetAllData: " + ex.Message;
                CloseConnection();
                return null;
            }
        }

        //================================
        //=== SET CADASTRO FUNCIONARIO ===
        //================================
        public static bool SetCadFuncionario(mdJoinCadFuncionario Colletion)
        {
            try
            {
                OpenConection();
                MySqlCommand cmd = new MySqlCommand("call sp_CadastroFuncionario(@SetUsuario, @SetSenha, @SetRua, @SetNum ,@SetBairro, @SetLogradouro, @SetEstado, @SetPais, @SetNome, @SetRT, @SetCPF, @SetRG, @SetTEL, @SetCEP, @SetEmail)", connection);
                //Login
                cmd.Parameters.AddWithValue("@SetUsuario", Colletion.Usuario1);
                cmd.Parameters.AddWithValue("@SetSenha", Colletion.Senha1);
                //Endereço
                cmd.Parameters.AddWithValue("@SetCEP", Colletion.Cep1);
                cmd.Parameters.AddWithValue("@SetRua", Colletion.Rua1);
                cmd.Parameters.AddWithValue("@SetNum", Colletion.Numero1);
                cmd.Parameters.AddWithValue("@SetBairro", Colletion.Bairro1);
                cmd.Parameters.AddWithValue("@SetLogradouro", Colletion.Logradouro1);
                cmd.Parameters.AddWithValue("@SetEstado", Colletion.Estado1);
                cmd.Parameters.AddWithValue("@SetPais", Colletion.Pais1);
                //Funcionario
                cmd.Parameters.AddWithValue("@SetNome", Colletion.NomeFunc1);
                cmd.Parameters.AddWithValue("@SetRT", Colletion.RT1);
                cmd.Parameters.AddWithValue("@SetCPF", Colletion.CPF1);
                cmd.Parameters.AddWithValue("@SetRG", Colletion.RG1);
                cmd.Parameters.AddWithValue("@SetTEL", Colletion.TEL1);
                cmd.Parameters.AddWithValue("@SetEmail", Colletion.Email1);

                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                CloseConnection();
                return false;
            }
        }

        //============================
        //=== SET CADASTRO EMPRESA ===
        //============================
        public static bool SetCadEmpresa(mdJoinCadEmpresa Colletion)
        {
            try
            {
                OpenConection();
                MySqlCommand cmd = new MySqlCommand("call sp_CadastroEmpresa(@SetEmpresaNome, @SetCNPJ, @SetCEP, @SetRua, @SetNum ,@SetBairro, @SetLogradouro, @SetEstado, @SetPais)", connection);

                //Empresa
                cmd.Parameters.AddWithValue("@SetEmpresaNome", Colletion.NomeEmpresa1);
                cmd.Parameters.AddWithValue("@SetCNPJ", Colletion.CNPJ1);

                //Endereço
                cmd.Parameters.AddWithValue("@SetCEP", Colletion.Cep1);
                cmd.Parameters.AddWithValue("@SetRua", Colletion.Rua1);
                cmd.Parameters.AddWithValue("@SetNum", Colletion.Numero1);
                cmd.Parameters.AddWithValue("@SetBairro", Colletion.Bairro1);
                cmd.Parameters.AddWithValue("@SetLogradouro", Colletion.Logradouro1);
                cmd.Parameters.AddWithValue("@SetEstado", Colletion.Estado1);
                cmd.Parameters.AddWithValue("@SetPais", Colletion.Pais1);
                cmd.ExecuteNonQuery();

                if (Colletion.NumeroContrato1 != 0)
                {
                               
                }
                
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                CloseConnection();
                return false;
            }
        }

        //===================
        //=== SET SERVIÇO ===
        //===================
        public static bool SetServico(mdJoinDadosContrato Contrato)
        {
            connection.Open();
            MySqlCommand cmd1 = new MySqlCommand("call sp_SetServicosFunc(@SetEmailFunc, @SetIDEmp, @SetNumContrato, @SetDescricao,  @SetDataContrato)", connection);
            try
            {                
                cmd1.Parameters.AddWithValue("@SetNumContrato", Contrato.Numero1);
                cmd1.Parameters.AddWithValue("@SetDescricao", Contrato.Descricao1);
                cmd1.Parameters.AddWithValue("@SetDataContrato", Contrato.DataContrato1);
                cmd1.Parameters.AddWithValue("@SetEmailFunc", Contrato.EmailFunc);
                cmd1.Parameters.AddWithValue("@SetIDEmp", Contrato.IdEmpresa);

                cmd1.ExecuteNonQuery();
                connection.Clone();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd1.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        //========================
        //=== GET ALL SERVIÇOS ===
        //========================
        public static List<mdJoinGetServico> GetAllServicos(int IdFunc)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_GetServicosFunc(@GetIdFunc)", connection);
                cmd.Parameters.AddWithValue("@GetIdFunc", IdFunc);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<mdJoinGetServico> ListServicos = new List<mdJoinGetServico>();
                while (reader.Read())
                {
                    mdJoinGetServico joinGetServico = new mdJoinGetServico();

                    //Servico
                    joinGetServico.IdServico1 = Convert.ToInt32(reader[0]);
                    joinGetServico.StatusServico1 = reader[1].ToString();
                    joinGetServico.Id_Emp1 = Convert.ToInt32(reader[2]);
                    joinGetServico.Id_Contrato1 = Convert.ToInt32(reader[3]);
                    joinGetServico.Id_Func1 = Convert.ToInt32(reader[4]);

                    //Contrato
                    joinGetServico.IdContrato1 = Convert.ToInt32(reader[5]);
                    joinGetServico.Numero1 = Convert.ToInt32(reader[6]);
                    joinGetServico.Descricao1 = reader[7].ToString();
                    joinGetServico.DataContrato1 = reader[8].ToString();
                    joinGetServico.Id_EmpContrato1 = Convert.ToInt32(reader[9]);

                    //Empresa
                    joinGetServico.IdEmpresa1 = Convert.ToInt32(reader[10]);
                    joinGetServico.NomeEmpresa1 = reader[11].ToString();
                    joinGetServico.CNPJ1 = reader[12].ToString();
                    joinGetServico.Id_End1 = Convert.ToInt32(reader[13]);

                    ListServicos.Add(joinGetServico);
                }
                reader.Close();
                connection.Close();
                return ListServicos;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;                
            }
        }


        //========================
        //=== GET ALL EMPRESAS ===
        //========================
        public static IEnumerable<mdEmpresa> GetAllEmpresas()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbempresa", connection);

                IEnumerable<mdEmpresa> ListEmpresa = null;
                List<mdEmpresa> ListEmp = new List<mdEmpresa>();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mdEmpresa mdEmpresa = new mdEmpresa();

                    mdEmpresa.IdEmpresa1 = Convert.ToInt32(reader[0]);
                    mdEmpresa.NomeEmpresa1 = reader[1].ToString();
                    mdEmpresa.CNPJ1 = reader[2].ToString();
                    mdEmpresa.Id_End1 = Convert.ToInt32(reader[3]);

                    ListEmp.Add(mdEmpresa);
                }

                ListEmpresa = ListEmp;
                connection.Close();
                return ListEmpresa;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;   
            }            
        }    
        public static mdEndereco GetAllDataEmpEndereco(int idEmpresa)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_GetAllDataEmpresa(@IdEMP)", connection);
                cmd.Parameters.AddWithValue("@IdEMP", idEmpresa);

                MySqlDataReader rd1 = cmd.ExecuteReader();

                while (rd1.Read())
                {
                    mdEndereco endereco = new mdEndereco();
                    endereco.IdEndereco1 = Convert.ToInt32(rd1[4]);
                    endereco.CEP1 = rd1[5].ToString();
                    endereco.Rua1 = rd1[6].ToString();
                    endereco.Numero1 = rd1[7].ToString();
                    endereco.Bairro1 = rd1[8].ToString();
                    endereco.Estado1 = rd1[10].ToString();
                    endereco.Pais1 = rd1[11].ToString();
                    
                    connection.Close();
                    return endereco;
                }
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return null;
            }
            catch (Exception ex)
            {
                connection.Close();
                throw;
            }
        }    
        public static IEnumerable<mdJoinDadosContrato> GetAllDataEmpListContrato(int idEmpresa)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand("call sp_GetAllContratoEmpresa(@IdEMP)", connection);
                cmd1.Parameters.AddWithValue("@IdEMP", idEmpresa);

                MySqlDataReader rd2 = cmd1.ExecuteReader();

                IEnumerable<mdJoinDadosContrato> IEnuListContratos;
                List<mdJoinDadosContrato> ListContratos = new List<mdJoinDadosContrato>();
                while (rd2.Read())
                {
                    mdJoinDadosContrato mdContra = new mdJoinDadosContrato();
                    
                    mdContra.IdServico1= Convert.ToInt32(rd2[0]);
                    mdContra.StatusServico1 = rd2[1].ToString();

                    mdContra.IdContrato1 = Convert.ToInt32(rd2[3]);
                    mdContra.Numero1 = rd2[6].ToString();
                    mdContra.Descricao1 = rd2[7].ToString();
                    mdContra.DataContrato1 = rd2[8].ToString();                    

                    ListContratos.Add(mdContra);
                }

                IEnuListContratos = ListContratos;
                connection.Close();
                return IEnuListContratos;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
        public static mdEmpresa GetAllDataEmp(int idEmpresa)
        {
            try
            {                
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_GetAllDataEmpresa(@IdEMP)", connection);
                cmd.Parameters.AddWithValue("@IdEMP", idEmpresa);

                MySqlDataReader rd1 = cmd.ExecuteReader();

                while (rd1.Read())
                {
                    mdEmpresa empresa = new mdEmpresa();
                    empresa.IdEmpresa1 = Convert.ToInt32(rd1[0]);
                    empresa.NomeEmpresa1 = rd1[1].ToString();
                    empresa.CNPJ1 = rd1[2].ToString();                    

                    connection.Close();
                    return empresa;
                }

                connection.Close();
                return null;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }            
        }

        //=======================
        //=== DELETAR EMPRESA ===
        //=======================
        public static bool DeletarEmpresa(int IdEmpresa)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_DeletarEmpresa(@IdEmp)", connection);
                cmd.Parameters.AddWithValue("@IdEmp", IdEmpresa);
                cmd.ExecuteNonQuery();
                connection.Clone();
                return true;
            }
            catch (Exception ex)
            {
                connection.Clone();
                return false;
            }
        }

        //======================
        //=== BUSCAR EMPRESA ===
        //======================
        public static List<mdEmpresa> GetEmpresa(string NomeEmpresa)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbempresa where NomeEmpresa like '%"+NomeEmpresa+"%'", connection);                
                MySqlDataReader rd1 = cmd.ExecuteReader();

                List<mdEmpresa> ListEmpresas = new List<mdEmpresa>();

                while (rd1.Read())
                {
                    mdEmpresa empresa = new mdEmpresa();
                    empresa.IdEmpresa1 = Convert.ToInt32(rd1[0]);
                    empresa.NomeEmpresa1 = rd1[1].ToString();
                    empresa.CNPJ1 = rd1[2].ToString();
                    empresa.Id_End1 = Convert.ToInt32(rd1[3]);

                    ListEmpresas.Add(empresa);
                }                
                cmd.Dispose();                
                connection.Clone();

                return ListEmpresas;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Dispose();
            }
        }

        //===========================
        //=== BUSCAR FUNCIONARIOS ===
        //===========================
        public static List<mdFuncionario> GetAllFuncionarios()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed) connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbfuncionario", connection);
   
                List<mdFuncionario> ListFuncionarios = new List<mdFuncionario>();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mdFuncionario funcionario = new mdFuncionario();

                    funcionario.IdFunc1 = Convert.ToInt32(reader[0]);
                    funcionario.NomeFunc1 = reader[1].ToString();
                    funcionario.RT1 = Convert.ToInt32(reader[2]);
                    funcionario.CPF1 = reader[3].ToString();
                    funcionario.RG1 = reader[4].ToString();
                    funcionario.TEL1 = reader[5].ToString();
                    funcionario.Email1 = reader[6].ToString();

                    ListFuncionarios.Add(funcionario);
                }
                reader.Close();
                connection.Close();
                return ListFuncionarios;
            }
            catch (Exception ex)
            {
                connection.Close();
                return null;
            }
            
        }

        //===========================
        //=== DELETAR FUNCIONARIO ===
        //===========================
        public static bool DeletarFuncionario(int IdFunc)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_DeletarFuncionario(@IdFunc)", connection);
                cmd.Parameters.AddWithValue("@IdFunc", IdFunc);
                cmd.ExecuteNonQuery();
                connection.Clone();
                return true;
            }
            catch (Exception ex)
            {
                connection.Clone();
                return false;
            }
        }

        //=============================
        //=== BUSCA O ID DO USUARIO ===
        //=============================
        public static int GetIdUsuario(int IdFunc)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("call sp_GetIdUser(@IdFunc)", connection);
                cmd.Parameters.AddWithValue("@IdFunc", IdFunc);
                MySqlDataReader reader = cmd.ExecuteReader();
                int IdUsuario = reader.Read() ? Convert.ToInt32(reader[0]) : 0;
                reader.Close();
                connection.Clone();
                return IdUsuario;
            }
            catch (Exception ex)
            {                
                connection.Clone();
                return 0;
            }
        }

        //=====================================
        //=== BUSCAR FUNCIONARIO ESPECIFICO ===
        //=====================================
        public static List<mdFuncionario> GetFuncionario(string NomeFunc)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbfuncionario where NomeFunc like '%" + NomeFunc + "%'", connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<mdFuncionario> ListFuncionarios = new List<mdFuncionario>();

                while (reader.Read())
                {
                    mdFuncionario funcionario = new mdFuncionario();

                    funcionario.IdFunc1 = Convert.ToInt32(reader[0]);
                    funcionario.NomeFunc1 = reader[1].ToString();
                    funcionario.RT1 = Convert.ToInt32(reader[2]);
                    funcionario.CPF1 = reader[3].ToString();
                    funcionario.RG1 = reader[4].ToString();
                    funcionario.TEL1 = reader[5].ToString();
                    funcionario.Email1 = reader[6].ToString();

                    ListFuncionarios.Add(funcionario);
                }
                cmd.Dispose();
                connection.Clone();

                return ListFuncionarios;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
