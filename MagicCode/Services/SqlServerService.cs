using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCode
{
    public class SQLServerService : IDatabaseService
    {
        public string ConnectionString { get; set; } = string.Empty;

        #region Constructor
        public SQLServerService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Public Methods
        public List<Table> GetTableModels(List<string> filterTables, List<string> baseFields)
        {
            var dic = new Dictionary<string, Table>();
            var dt = GetDataTable(_GetTableModelSql);
            foreach (DataRow item in dt.Rows)
            {
                var tableName = item["TableName"].ToString();
                var columnName = item["ColumnName"].ToString();
                var typeName = item["TypeName"].ToString();
                var isKey = Convert.ToBoolean(item["IsKey"]);
                var isIdentity = Convert.ToBoolean(item["IsIdentity"]);

                if (filterTables.Count > 0 && filterTables.Contains(tableName))
                {
                    continue;
                }

                if (!dic.ContainsKey(tableName))
                {
                    dic[tableName] = new Table
                    {
                        TableName = tableName,
                        ClassName = tableName.ToUpperFirst()
                    };
                }

                var column = new Column
                {
                    DatabaseName = columnName,
                    NetName = columnName.ToUpperFirst(),
                    IsKey = isKey,
                    IsIdentity = isIdentity,
                    TypeMapping = GetTypeModel(typeName),
                    IsBaseField= baseFields.Count > 0 && baseFields.Contains(columnName)
                };
                dic[tableName].Columns.Add(column);
            }
            return dic.Values.ToList();
        }
        #endregion

        #region Private Methods
        private static readonly string _GetTableModelSql =
            @"SELECT [ColumnName]=sc.name,[TableName]=so.name,[TypeName]=st.name
            ,[IsKey] = CASE WHEN kcu.TABLE_NAME IS NULL THEN 0 ELSE 1 END
            ,[IsIdentity]=COLUMNPROPERTY(so.id,sc.name,'IsIdentity')
            FROM syscolumns sc
            JOIN sysobjects so ON so.id = sc.id
            JOIN systypes st ON st.xusertype = sc.xusertype
            LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu ON kcu.TABLE_NAME = so.name AND kcu.COLUMN_NAME = sc.name
            WHERE so.xtype = 'U'
            ORDER BY so.name,sc.colid";

        private DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            var result = new DataTable();
            using (var sda = new SqlDataAdapter(sql, ConnectionString))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    sda.SelectCommand.Parameters.AddRange(parameters);
                }
                sda.Fill(result);
            }
            return result;
        }

        private static readonly Dictionary<string, TypeMapping> _TypeMappings = new Dictionary<string, TypeMapping>
        {
            {"int",new TypeMapping("int","int","0") },
            {"bigint",new TypeMapping("bigint","long","0") },
            {"float",new TypeMapping("float","double","0") },
            {"money",new TypeMapping("money","decimal","0") },
            {"decimal",new TypeMapping("decimal","decimal","0") },

            {"bit",new TypeMapping("bit","bool","false") },

            {"date",new TypeMapping("date","DateTime","DateTime.Now") },
            {"datetime",new TypeMapping("date","DateTime","DateTime.Now") },
            {"timestamp",new TypeMapping("timestamp","DateTime","DateTime.Now") },

            {"char",new TypeMapping("char","string","string.Empty") },
            {"varchar",new TypeMapping("varchar","string","string.Empty") },
            {"nvarchar",new TypeMapping("nvarchar","string","string.Empty") },
            {"nchar",new TypeMapping("nchar","string","string.Empty") },
            {"text",new TypeMapping("text","string","string.Empty") },
            {"longtext",new TypeMapping("longtext","string","string.Empty") },
            {"xml",new TypeMapping("xml","string","string.Empty") },
        };

        private static TypeMapping GetTypeModel(string databaseTypeName)
        {
            if (_TypeMappings.TryGetValue(databaseTypeName, out TypeMapping typeMapping))
            {
                return typeMapping;
            }
            else
            {
                throw new Exception($"没有找到对应类型的映射：{databaseTypeName}");
            }
        }
        #endregion




    }
}
