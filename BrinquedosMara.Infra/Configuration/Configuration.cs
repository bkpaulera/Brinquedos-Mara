using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrinquedosMara.Repository.Configuration
{
    public class Configuration
    {
        public const int DefaultStatusCode = 200;
        public static string ConnectionString { get; set; } = string.Empty;
    }
}
