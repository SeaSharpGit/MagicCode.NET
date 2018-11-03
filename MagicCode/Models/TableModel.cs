using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCode
{
    public class Table
    {
        public string TableName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public List<Column> Columns { get; private set; } = new List<Column>();
    }

    public class Column
    {
        public bool IsKey { get; set; } = false;
        public string DatabaseName { get; set; } = string.Empty;
        public string NetName { get; set; } = string.Empty;
        public bool IsIdentity { get; set; } = false;
        public bool IsBaseField { get; set; } = false;
        public TypeMapping TypeMapping { get; set; } = new TypeMapping("int", "int", "0");
    }

    public class TypeMapping
    {
        public string DatabaseTypeName { get; set; } = string.Empty;
        public string NetTypeName { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;

        public TypeMapping(string databaseTypeName, string netTypeName, string defaultValue)
        {
            DatabaseTypeName = databaseTypeName;
            NetTypeName = netTypeName;
            DefaultValue = defaultValue;
        }

        public TypeMapping()
        {

        }
    }


}
