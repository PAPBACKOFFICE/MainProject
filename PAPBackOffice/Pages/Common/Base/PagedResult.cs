using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Pages.Common.Base
{
    public class PagedResult<T> where T : class
    {
        public PagedResultBase PagingData { get; set; } = new PagedResultBase();

        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public PagedResult(List<T> Results)
        {
            this.Results = Results;
        }
    }
}
