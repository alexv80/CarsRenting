#pragma checksum "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6f72c6ac6b34ed57699f0ef242741d7c05f6284"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_List), @"mvc.1.0.view", @"/Views/Shared/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Repos\RentCar\RentCar\Views\_ViewImports.cshtml"
using RentCar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repos\RentCar\RentCar\Views\_ViewImports.cshtml"
using RentCar.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6f72c6ac6b34ed57699f0ef242741d7c05f6284", @"/Views/Shared/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ca368d678ecb10c96cc8f6b1a660616f0d960bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentCar.Core.Models.CarsCollection>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
  
    ViewData["Title"] = "Rent cars";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n");
#nullable restore
#line 8 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
     foreach (var c in Model.Cars)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <h3>");
#nullable restore
#line 11 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
           Write(c.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                    Write(c.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <h4>Price: ");
#nullable restore
#line 12 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                  Write(c.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <h5>Transmission: ");
#nullable restore
#line 13 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                         Write(c.Transmission);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5>EngineType: ");
#nullable restore
#line 14 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                       Write(c.TypeEngine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5>Engine: ");
#nullable restore
#line 15 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                   Write(c.Engine);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h5>Passengers: ");
#nullable restore
#line 16 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
                       Write(c.Passengers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            ------------------------------------------\r\n</div>\r\n");
#nullable restore
#line 19 "C:\Repos\RentCar\RentCar\Views\Shared\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentCar.Core.Models.CarsCollection> Html { get; private set; }
    }
}
#pragma warning restore 1591
