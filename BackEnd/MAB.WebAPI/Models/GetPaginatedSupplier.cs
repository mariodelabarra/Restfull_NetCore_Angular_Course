using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAB.WebAPI.Models
{
    public class GetPaginatedSupplier
    {
        public int Page { get; set; }
        public int Rows { get; set; }
        public string searchTerm { get; set; }
    }
}
