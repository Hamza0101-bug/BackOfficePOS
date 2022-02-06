using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Specification.EntitySpecifications
{
    public class CommonSpecParams
    {
        private const int MaxPageSize = 15;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 15;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string? Sort { get; set; }

        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

        private bool _active = true;
        public bool Active 
        { get => _active; 
         set=> _active=value; 
        }
        private bool _allrecord = true;
        public bool AllRecord 
        { get=> _allrecord;
          set=> _allrecord =value; 
        }

    }
}
