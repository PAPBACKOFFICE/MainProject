#pragma checksum "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Shared\LoginDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "814f0bbac7c10b44d1f16b1ff256a0695c7842dc"
// <auto-generated/>
#pragma warning disable 1591
namespace PAPBackOffice.Shared
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
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    public partial class LoginDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        ");
                __builder2.OpenElement(3, "a");
                __builder2.AddAttribute(4, "href", "Identity/Account/Manage");
                __builder2.AddContent(5, "Hello, ");
                __builder2.AddContent(6, 
#nullable restore
#line 3 "C:\Users\andre\source\repos\MainProject\PAPBackOffice\Shared\LoginDisplay.razor"
                                                  context.User.Identity.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(7, "!");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(8, "\r\n        ");
                __builder2.AddMarkupContent(9, "<form method=\"post\" action=\"Identity/Account/LogOut\">\r\n            <button type=\"submit\" class=\"nav-link btn btn-link\">Log out</button>\r\n        </form>\r\n    ");
            }
            ));
            __builder.AddAttribute(10, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(11, "\r\n         ");
                __builder2.AddMarkupContent(12, "<a href=\"Identity/Account/Register\">Register</a> \r\n         ");
                __builder2.AddMarkupContent(13, "<a href=\"Identity/Account/Login\">Log in</a> \r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
