using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        // Facilement utiliser la connection string Default
        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        //methode pour charger nos infos
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            //On se connecte a notre DB SQL
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //On va envoyer une query a notre DB avec en parametre notre requete SQL et nos paramètres puis recuperer un IEnumerable de type T  
                var data = await connection.QueryAsync<T>(sql, parameters);

                //on va transformer notre IEnumerable en List 
                return data.ToList();
            }
        }

        //Method pour sauvegarder mes infos
        public async Task SaveDate<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);


            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //Va nous permettre d'utiliser des requetes de type update, delete, etc sans retourner aucune info sauf que la tache a été réalisé
                await connection.ExecuteAsync(sql, parameters);
            }
        }

    }
}
