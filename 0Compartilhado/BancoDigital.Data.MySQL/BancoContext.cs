using Auxiliar.Helper;
using BancoUtils.Entidade;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BancoDigital.Data.MySQL
{
    public class BancoContext
    {
        private string _conexao { get; set; }

        public BancoContext(string conexao = "")
        {
            if (string.IsNullOrEmpty(conexao))
                _conexao = ConfigurationManager.AppSetting["conexaoMySQL"];
            _conexao = conexao;
        }

        public MySqlConnection CriarConexao()
        {
            return  new MySqlConnection(_conexao);
        }

        public MySqlCommand CriarCommand()
        {
            return new MySqlCommand();
        }
    }
}
