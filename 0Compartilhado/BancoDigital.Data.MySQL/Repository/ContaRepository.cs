using BancoUtils.Entidade;
using MySql.Data.MySqlClient.Memcached;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BancoDigital.Data.MySQL.Repository
{
    public class ContaRepository
    {
        private BancoContext _bancoContext;
        public ContaRepository()
        {
            _bancoContext = new BancoContext();
        }

        public ContaBancaria Get(int id)
        {
            try
            {
                using (var cn = _bancoContext.CriarConexao())
                {
                    var cmd = _bancoContext.CriarCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT ID, PessoaID, Agencia, Conta, Tipo, Valor
                                    FROM Conta WHERE ID = @ID";

                    cmd.Parameters.AddWithValue("ID", id);

                    MySqlDataReader dr;
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    var conta = new ContaPoupanca();
                    dr.Read();
                    conta.ID = (int)dr["ID"];
                    conta.Pessoa.ID = (int)dr["PessoaId"];
                    conta.Agencia = (int)dr["Agencia"];
                    conta.Conta = (int)dr["Conta"];
                    conta.Tipo = (int)dr["Tipo"];
                    conta.Valor = (decimal)dr["Valor"];
                    cn.Close();

                    return conta;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ContaBancaria> GetAll()
        {
            try
            {
                using (var cn = _bancoContext.CriarConexao())
                {
                    var cmd = _bancoContext.CriarCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT ID, PessoaID, Agencia, Conta, Tipo, Valor
                                    FROM Conta";

                    MySqlDataReader dr;
                    cn.Open();
                    dr = cmd.ExecuteReader();

                    var lista = new List<ContaBancaria>();
                    while (dr.Read())
                    {
                        var conta = new ContaPoupanca();
                        conta.ID = (int)dr["ID"];
                        conta.Pessoa.ID = (int)dr["PessoaId"];
                        conta.Agencia = (int)dr["Agencia"];
                        conta.Conta = (int)dr["Conta"];
                        conta.Tipo = (int)dr["Tipo"];
                        conta.Valor = (decimal)dr["Valor"];
                        lista.Add(conta);
                    }
                    cn.Close();

                    return lista;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(ContaBancaria conta)
        {
            try
            {
                using (var cn = _bancoContext.CriarConexao())
                {
                    var cmd = _bancoContext.CriarCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO CONTA
                (PessoaID, Agencia, Conta, Tipo, Valor)
                VALUES(@PessoaID, @Agencia, @Conta, @Tipo, @Valor)";

                    cmd.Parameters.AddWithValue("PessoaID", conta.Pessoa.ID);
                    cmd.Parameters.AddWithValue("Agencia", conta.Agencia);
                    cmd.Parameters.AddWithValue("Conta", conta.Conta);
                    cmd.Parameters.AddWithValue("Tipo", conta.Tipo);
                    cmd.Parameters.AddWithValue("Valor", conta.Valor);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                using (var cn = _bancoContext.CriarConexao())
                {
                    var cmd = _bancoContext.CriarCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"DELETE FROM CONTA
                WHERE ID = @ID";

                    cmd.Parameters.AddWithValue("ID", id);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
