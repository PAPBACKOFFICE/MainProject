#pragma checksum "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adb33f371c4acaf3db749be8e23071a40a2a1431"
// <auto-generated/>
#pragma warning disable 1591
namespace PAPBackOffice.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Data.Repository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using PAPBackOffice.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Blazorise.Carousel>(0);
            __builder.AddAttribute(1, "SelectedSlide", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 3 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\Pages\Index.razor"
                                selectedSlide

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "SelectedSlideChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => selectedSlide = __value, selectedSlide))));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "\r\n    ");
                __builder2.OpenComponent<Blazorise.CarouselSlide>(5);
                __builder2.AddAttribute(6, "Name", "1");
                __builder2.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(8, "\r\n        <img src=\"/Imagens/Tresamigos.jpeg\" Text=\"City Skyline\" Display=\"Display.Block\" Style=\"width: 100%;\">\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n    ");
                __builder2.OpenComponent<Blazorise.CarouselSlide>(10);
                __builder2.AddAttribute(11, "Name", "2");
                __builder2.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(13, "\r\n        <img src=\"/Imagens/outrostresamigos.jpeg\" Text=\"Coffee\" Display=\"Display.Block\" Style=\"width: 100%;\">\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(14, "\r\n    ");
                __builder2.OpenComponent<Blazorise.CarouselSlide>(15);
                __builder2.AddAttribute(16, "Name", "3");
                __builder2.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(18, "\r\n        <img src=\"/Imagens/dubai.jpg\" Text=\"Mountain\" Display=\"Display.Block\" Style=\"width: 100%;\">\r\n    ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(19, "\r\n");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 14 "C:\Users\ricar\source\repos\MainProject\PAPBackOffice\Pages\Index.razor"
      
    private string selectedSlide = "1";

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
