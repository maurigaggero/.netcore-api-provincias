using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_crud.Data.Entities
{
    public class Pais
    {
        public int Id { get; set; }
        public string CodPais { get; set; }
        public string NomPais { get; set; }
    }
}
