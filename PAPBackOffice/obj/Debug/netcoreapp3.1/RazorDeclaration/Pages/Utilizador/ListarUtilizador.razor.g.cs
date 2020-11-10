#pragma checksum "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Pages\Utilizador\ListarUtilizador.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09d82aeeab23d9caf3a4f5786b35102378644822"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PAPBackOffice.Pages.Utilizador
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Data.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Pages\Utilizador\ListarUtilizador.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Pages\Utilizador\ListarUtilizador.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Utilizador/ListarUtilizador")]
    public partial class ListarUtilizador : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 51 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Pages\Utilizador\ListarUtilizador.razor"
       
    private List<Utilizador> utilizadores;
    private int NumUtilizadores;

    protected override void OnInitialized()
    {
        utilizadores = Repository.List<Utilizador>();
        //forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }

    async Task OnReadData(DataGridReadDataEventArgs<Utilizador> e)
    {
        // this can be call to anything, in this case we're calling a fictional api
        var response = Repository.Query<Utilizador>()
                .Skip(e.Page * e.PageSize)
                .Take(e.PageSize)
                .ToList();

        //($"some-api/employees?page={e.Page}&pageSize={e.PageSize}");

        utilizadores = response; // an actual data for the current page
        NumUtilizadores = response.Count;
        // always call StateHasChanged!
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IToastService toastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IRepository Repository { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
