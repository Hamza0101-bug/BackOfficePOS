using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EntitySpecifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 3;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 2;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? BrandId { get; set; }
        public int? CategoryID { get; set; }
        public string? Sort { get; set; }

        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
