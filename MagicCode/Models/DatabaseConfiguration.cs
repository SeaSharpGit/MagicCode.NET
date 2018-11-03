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

        [XmlAttribute("BaseFields")]
        public string BaseFields { get; set; }

        public List<Table> Tables { get; set; } = new List<Table>();

        public void LoadTables()
        {
            if (ProviderName.IsNullOrWhiteSpace() || ConnectionString.IsNullOrWhiteSpace())
            {
                throw new Exception($"数据库{Name}配置ProviderName/ConnectionString错误");
            }

            var service = GetDatabaseService(ConnectionString);

            var filterTables = FilterTables.IsNullOrEmpty() ? new List<string>() : FilterTables.Split(new char[] { ',', '，' }).ToList();
            var baseFields = BaseFields.IsNullOrEmpty() ? new List<string>() : BaseFields.Split(new char[] { ',', '，' }).ToList();
            var tables = service.GetTableModels(filterTables, baseFields);
            Tables.AddRange(tables);
        }

        private IDatabaseService GetDatabaseService(string connectionString)
        {
            switch (ProviderName)
            {
                case "System.Data.SqlClient"://SQL Server
                    return new SQLServerService(connectionString);
                case "MySql.Data.MySqlClient"://MySQL
                    return new MySQLService(connectionString);
                case "System.Data.SQLite"://SQLite
                case "System.Data.OracleClient"://Oracle
                case "System.Data.OleDb"://Aceess
                default:
                    throw new Exception($"数据库{Name}配置ProviderName错误");
            }
        }
    }

}
