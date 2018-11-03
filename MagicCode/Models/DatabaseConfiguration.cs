using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicCode
{
    [XmlRoot("DatabaseConfiguration")]
    public class DatabaseConfiguration
    {
        [XmlArray("Connections")]
        [XmlArrayItem("Connection", typeof(Connection))]
        public List<Connection> Connections { get; set; } = new List<Connection>();

        public static DatabaseConfiguration Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"找不到文件：{filePath}");
            }
            var config = filePath.XmlToObject<DatabaseConfiguration>();
            var tables = new List<Table>();
            foreach (var connection in config.Connections)
            {
                connection.LoadTables();
            }
            return config;
        }
    }

    public class Connection
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("ProviderName")]
        public string ProviderName { get; set; }

        [XmlAttribute("ConnectionString")]
        public string ConnectionString { get; set; }

        [XmlAttribute("FilterTables")]
        public string FilterTables { get; set; }

        public List<Table> Tables { get; set; } = new List<Table>();

        public void LoadTables()
        {
            if (ProviderName.IsNullOrWhiteSpace() || ConnectionString.IsNullOrWhiteSpace())
            {
                throw new Exception($"数据库{Name}配置ProviderName/ConnectionString错误");
            }

            var service = GetDatabaseService(ConnectionString);
            var tables = service.GetTableModels();
            Tables.AddRange(tables);
        }

        private IDatabaseService GetDatabaseService(string connectionString)
        {
            IDatabaseService service = null;
            switch (ProviderName)
            {
                case "System.Data.SqlClient"://SQL Server
                    service = new SQLServerService(connectionString);
                    break;
                case "MySql.Data.MySqlClient"://MySQL
                    service = new MySQLService(connectionString);
                    break;
                case "System.Data.SQLite"://SQLite
                case "System.Data.OracleClient"://Oracle
                case "System.Data.OleDb"://Aceess
                default:
                    throw new Exception($"数据库{Name}配置ProviderName错误");
            }

            service.FilterTables = FilterTables.IsNullOrEmpty() ? new List<string>() : FilterTables.Split(',').ToList();
            return service;
        }
    }

}
