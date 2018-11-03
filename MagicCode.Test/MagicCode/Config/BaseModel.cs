using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCode
{
    public class BaseModel
    {
        public bool IsValid { get; set; } = false;
        public int CreateUser { get; set; } = 0;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int UpdateUser { get; set; } = 0;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
