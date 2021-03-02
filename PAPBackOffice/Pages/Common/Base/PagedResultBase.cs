using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Pages.Common.Base
{
    public class PagedResultBase
    {
        #region Defaults

        public int[] PageSizeValues => new int[] { 15, 30, 50, 100 };
        public int FirstPage { get; private set; } = 1;
        public int MaxPageCount { get; private set; } = 9;

        #endregion

        public int StartIndex { get; set; } = 0;
        public int FinishIndex { get; set; } = 0;
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int FilteredCount { get; set; }
        public int TotalCount { get; set; }

        public PagedResultBase()
        {
            CurrentPage = 1;
            PageSize = PageSizeValues[0];
        }

        public void SetPages()
        {
            if (PageSize > 0)
                PageCount = (int)Math.Ceiling((decimal)((FilteredCount * 1.0) / (PageSize * 1.0)));
        }
    }
}
