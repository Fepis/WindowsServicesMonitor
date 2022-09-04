using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AtualizadorServico.Classes
{
    /// <summary>
    /// Classe de consulta no banco de dados
    /// </summary>
    class Consultas
    {

        /// <summary>
        /// Retorna uma lista de servidores
        /// </summary>
        /// <param name="filtro">nome do servidor</param>
        /// <param name="tipos">Tipo de servidor</param>
        /// <returns>Retorna a lista d eservidores</returns>
        public static List<string> RetornarMaquinasFiliais(string filtro, bool nota, bool windows)
        {
            List<string> servidores = new List<string>();

            using (SqlConnection conn = new SqlConnection(Conexao.StringConexao))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select cod_maq from gerk_maq ";
                    cmd.CommandText += "where cod_maq like '%' + @cod_maq + '%' ";

                    if (nota && windows)
                    {
                        cmd.CommandText += "and stt_amb in ('W','N') ";
                    }
                    else if (nota)
                    {
                        cmd.CommandText += "and stt_amb = 'N' ";
                    }
                    else if (windows)
                    {
                        cmd.CommandText += "and stt_amb = 'W' ";
                    }

                    cmd.Parameters.Add("@cod_maq", SqlDbType.VarChar, 10).Value = filtro;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            servidores.Add(reader["cod_maq"].ToString());
                        }
                    }
                    conn.Close();
                }
            }

            return servidores;
        }

        /// <summary>
        /// Retorna a filial do servidor
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>Retorna o nome da filail</returns>
        public static string RetornaFilialServidor(string servidor)
        {
            string filial = string.Empty;

            using (SqlConnection conn = new SqlConnection(Conexao.StringConexao))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText += "select raz_resu from gerk_maq_fil ";
                    cmd.CommandText += "inner join gerk_emp ";
                    cmd.CommandText += "on gerk_emp.cod_grp_emp = gerk_maq_fil.cod_grp_emp ";
                    cmd.CommandText += "and gerk_emp.cod_emp = gerk_maq_fil.cod_emp ";
                    cmd.CommandText += "where cod_maq = @cod_maq ";

                    cmd.Parameters.Add("@cod_maq", SqlDbType.VarChar, 10).Value = servidor;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            filial = reader["raz_resu"] != DBNull.Value ? reader["raz_resu"].ToString() : string.Empty;
                        }
                    }
                    conn.Close();
                }
            }
            return filial;
        }
    }
}
