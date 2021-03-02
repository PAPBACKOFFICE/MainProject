using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace PAPBackOffice.Pages.Common.Base
{
    public class PageSizeBase : ComponentBase
    {
        #region Parameters

        [Parameter] public PagedResultBase PagingData { get; set; }
        [Parameter] public EventCallback<PagedResultBase> PagingDataChanged { get; set; }
        [Parameter] public EventCallback PageSizeChanged { get; set; }

        #endregion

        #region Events

        public async Task PagerSize_OnChange(int pageSize)
        {
            PagingData.PageSize = pageSize;

            await PageSizeChanged.InvokeAsync(null);
        }

        #endregion
    }
}
